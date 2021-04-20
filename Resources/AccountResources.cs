using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Api.Resources
{
    public class AccountResources
    {
        
        
            
            public string FirstName { get; set; }

            public string LastName { get; set; }
            [Required(ErrorMessage = "Username is required!!")]
            public string Username { get; set; }
            public string Email { get; set; }
            [Required(ErrorMessage = "Password is required!!")]
            public string Password { get; set; }
            public string PhoneNumber{ get; set; }
           
            public ICollection<string> Roles{ get; set; }

    }
}
