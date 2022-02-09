using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AuthenticationDTO
    {

        [Required(ErrorMessage = "Zadejte prosím uživatelské jméno")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Neplatná e-mailová adresa")]
        [Display(Name = "Uživatelské jméno")]
        public string UserName { get; set; }

       
        [Required(ErrorMessage = "Zadejte prosím heslo")]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }
    }
}
