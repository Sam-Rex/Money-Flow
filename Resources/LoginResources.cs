using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Api.Resources
{
    public class LoginResources
    {
        [Required(ErrorMessage ="Username is requires ....")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is requires ....")]
        public string Password { get; set; }
    }
}
