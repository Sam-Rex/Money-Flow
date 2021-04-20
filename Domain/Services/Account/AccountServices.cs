using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Api.Domain.Models.Account;
using Api.Domain.Repositories;
using Api.Domain.Services.Communication;
using System;
using Api.Domain.Services.Account;
using Api.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Api.Models.Services.Account
{
    public class AccountServices : IAccountServices
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User _user;

        public AccountServices(IUnitOfWork unitOfWork,UserManager<User>usermanager,IConfiguration configuration)
        {
            _configuration = configuration;
            _userManager = usermanager;
            _unitOfWork = unitOfWork;

        }

        public async Task<string> CreateToken()
        {
            var signingCradentials = GetSigningCradentials();
            var claims = await GetClaims();
            var tokenOption = GenerateTokenOptions(signingCradentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOption);

        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCradentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JWTConfiguration");
            var tokenOptions = new JwtSecurityToken(
                    issuer: jwtSettings.GetSection("ValidIssuer").Value,
                    audience: jwtSettings.GetSection("ValidAudience").Value,
                    claims: claims,
                    expires:DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("expires").Value)),
                    signingCredentials:signingCradentials
                );
            return tokenOptions;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name,_user.UserName)};
            var roles = await _userManager.GetRolesAsync(_user);
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private  SigningCredentials GetSigningCradentials()
        {
            var key =
                Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(LoginResources loginResources)
        {
            _user = await _userManager.FindByNameAsync(loginResources.Username);
            return (_user != null && await _userManager.CheckPasswordAsync(_user, loginResources.Password));
        }
    }
}
