using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Api.Domain.Models.Account;
using Api.Domain.Services.Account;
using Api.Resources;

using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<User> _usermanager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAccountServices _accountServices;
        public AccountController(IMapper mapper, ILogger<AccountController> logger,UserManager<User>userManager,RoleManager<IdentityRole>roleManager,IAccountServices accountServices)
        {
            
            _mapper = mapper;
            
            _usermanager = userManager;
            
            _roleManager = roleManager;
            
            _accountServices = accountServices;
            _logger = logger; 
            _logger.LogDebug(1, "Nlog injected into AccountController");
        }

        [HttpPost]
        public async Task<IActionResult>RegisterUser([FromBody]AccountResources accountResource)
        {
            var user = _mapper.Map<User>(accountResource);

            var resault = await _usermanager.CreateAsync(user, accountResource.Password);
            if(!resault.Succeeded)
            {
                foreach(var error in resault.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
           
           await _usermanager.AddToRolesAsync(user, accountResource.Roles);
           
            return StatusCode(201);
            
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Authenticate([FromBody]LoginResources user)
        {
            
            if (!await _accountServices.ValidateUser(user))
            {

                _logger.LogInformation($"{nameof(Authenticate)}: Login Failed .. wrong Username or Password.");
                return Unauthorized();
            }
            return Ok(new { Token = await _accountServices.CreateToken() });

        }


        [HttpPost("Forget-Password")]
        public /*async*/ Task<IActionResult> RePassword()
        {
            return null;

        }
    }
}
