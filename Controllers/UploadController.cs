using System.Collections.Generic;
using Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Api.Domain.Models;
using AutoMapper;
using Api.Resources;
using Api.Extensions;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace Api.Controllers
{
    [Route("/api/[controller]")]
    public class UploadController : Controller
    {
        private string kindOf = null;
        [HttpPost,DisableRequestSizeLimit]
        public IActionResult Upload(char kind)
        {
            #region Validate Kind
            if (kind == 'P')
            {
                kindOf = "ProfilePictures";
            }
            else if (kind == 'I')
            {
                kindOf = "Identities";
            }
            else if (kind == 'S')
            {
                kindOf = "Services";
            }
            #endregion

            try
            {
                var file = Request.Form.Files[0];
                
                var folderName = Path.Combine("Resources\\Uploads", kindOf);
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error:upload controller :{ex}");
            }
        }
        
    }

}


