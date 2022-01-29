using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HotelRoom
    {
        [Key]
        public int Id { get; set; }
        [Required]       
        public string Name { get; set; }
        [Required]
        public int Occupancy { get; set; }
        [Required]       
        public double RegularRate { get; set; }      
        [Display(Name = "Detaily")]
        public string Details { get; set; }       
        [Display(Name = "Plocha")]
        public string SqFt { get; set; }
        [Required(ErrorMessage = "Vyplňte autor")]
        [Display(Name = "Autor")]
        public string CreatedBy { get; set; }
        [Required(ErrorMessage = "Vyplňte datum vytvoření")]
        [Display(Name = "Datum vytvoření")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage = "Vyplňte jméno")]
        [Display(Name = "Formulář upravil:")]
        public string UpdatedBy { get; set; }
        [Required(ErrorMessage = "Vyplňte datum aktualizace")]
        [Display(Name = "Datum aktualizace")]
        public DateTime UpdatedDate { get; set; }
    }
}
