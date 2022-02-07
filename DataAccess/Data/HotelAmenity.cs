using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HotelAmenity
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Vyplňte prosím název vybavení")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Zadejte prosím načasování")]
        public string Timming { get; set; }
        [Required(ErrorMessage = "Zadejte prosím popis")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Zadejte prosím 'FontAwesome' ikonu")]
        public string IconStyle { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

}
