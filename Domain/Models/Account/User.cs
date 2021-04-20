using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace Api.Domain.Models.Account
{
    public class User:IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string ProfilePict { get; set; }

    }
}