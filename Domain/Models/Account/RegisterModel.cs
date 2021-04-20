
using System.ComponentModel.DataAnnotations;
namespace Api.Domain.Models.Account
{
    public class RegisterModel
    {
        [Required(ErrorMessage="Username is required!!")]
        public string  Username { get; set; }
        [EmailAddress]
        [Required(ErrorMessage="Email is required!!")]
        public string Email { get; set; }
        [Required(ErrorMessage="First Nameis required!!")]                 
                         
        public string First_Name { get; set; }
        [Required(ErrorMessage="Last Name is required!!")]
        
        public string Last_Name { get; set; }
        [Required(ErrorMessage="Password is required!!")]

        public string Password { get; set; }
        public string Profile { get; set; }
    }
}