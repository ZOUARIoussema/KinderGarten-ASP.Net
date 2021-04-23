using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CodeVerifPass
    {
        [Required(ErrorMessage = "Code is required")]
        public string Code {get;set;}
        [Required(ErrorMessage = "Password is required")]
        [StringLength(int.MaxValue, MinimumLength = 6,ErrorMessage ="password must be at least 6 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [StringLength(int.MaxValue, MinimumLength = 6)]
        public string confirmpassword { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
         public string email { get; set; }
      
    }
}
