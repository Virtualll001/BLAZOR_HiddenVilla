using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HotelAmenityDTO //data transfer object
    {
        public int Id { get; set; }
        [Display(Name = "Název vybavení")]
        [Required(ErrorMessage = "Vyplňte prosím název vybavení")]
        public string Name { get; set; }
        [Display(Name = "Provozní doba")]
        [Required(ErrorMessage = "Zadejte prosím provozní dobu")]
        public string Timming { get; set; }
        [Display(Name = "Popis")]
        [Required(ErrorMessage = "Zadejte prosím popis")]
        public string Description { get; set; }
        [Display(Name = "Ikona")]
        [Required(ErrorMessage = "Zadejte prosím 'FontAwesome' ikonu")]
        public string IconStyle { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
