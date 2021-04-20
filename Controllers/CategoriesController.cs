using System.Collections.Generic;
using Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Api.Domain.Models;
using AutoMapper;
using Api.Resources;
using Api.Extensions;
using System;

namespace Api.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController:Controller
    {
        private readonly ICategoriesService categoryServices;
        private readonly IMapper mapper;
        
        public CategoriesController(ICategoriesService categoryService,IMapper mapper)
        {
            this.categoryServices=categoryService;
            this.mapper=mapper;
            
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryResource>>ListAsync(){
            var categories=await categoryServices.ListAsync();
            var resource = mapper.Map<IEnumerable<Categories>,IEnumerable<CategoryResource>>(categories);
            return resource;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>FindByIdAsync(Guid id)
        {
            var resault =await categoryServices.FindByIdAsync(id);
            if(!resault.Success)
                return BadRequest(resault.Message);
            var categoryResource=mapper.Map<Categories,CategoryResource>(resault.Categories);
                return Ok(categoryResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource){
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var category=mapper.Map<SaveCategoryResource,Categories>(resource);
            var resault=await categoryServices.SaveAsync(category);
            if(!resault.Success)
                return BadRequest(resault.Message);
            var categoryResource=mapper.Map<Categories,CategoryResource>(resault.Categories);
                return Ok(categoryResource);     
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>PutAsync([FromBody] SaveCategoryResource resource,Guid id){
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var category=mapper.Map<SaveCategoryResource,Categories>(resource);
            var resault =await categoryServices.UpdateAsync(id,category);
            if(!resault.Success)
                return NotFound(resault.Message);
            var categoryResource=mapper.Map<Categories,CategoryResource>(resault.Categories);
            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteAsync(Guid id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
                var resault =await categoryServices.DeleteAsync(id);
            if(!resault.Success)
                return NotFound(resault.Message);
                var categoryResource=mapper.Map<Categories,CategoryResource>(resault.Categories);
            return Ok(categoryResource);
        }
    }
}