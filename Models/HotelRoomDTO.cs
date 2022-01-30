using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HotelRoomDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vyplňte prosím jméno")]
        [Display(Name = "Jméno")]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage = "Vyplňte prosím obsazenost")]
        [Display(Name = "Obsazenost")]
        public int Occupancy { get; set; }       
        [Range(1,3000,ErrorMessage ="Běžná sazba musí být mezi 1-3000")]
        [Display(Name = "Běžná sazba")]
        public double RegularRate { get; set; }       
        [Display(Name = "Detaily")]
        public string Details { get; set; }      
        [Display(Name = "Plocha")]
        public string SqFt { get; set; }
    }
}
