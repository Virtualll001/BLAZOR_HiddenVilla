using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserRequestDTO
    {
        [Required(ErrorMessage = "Zadejte prosím jméno")]
        [Display(Name = "Jméno")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Zadejte prosím email")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Neplatná e-mailová adresa")]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Zadejte prosím heslo")]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Potvrďte prosím heslo")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Heslo a potvrzení hesla se neshodují")]
        [Display(Name = "Potvrzení hesla")]
        public string ConfirmPassword { get; set; }

    }
}
