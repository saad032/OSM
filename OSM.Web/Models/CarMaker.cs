using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OSM.Models.DomainModels;

namespace OSM.Web.Models
{
    public class CarMaker
    {
        public int CarMakerId { get; set; }

        [Required(ErrorMessage = "Car Maker Name is Required")]
        [StringLength(50, ErrorMessage = "The Car Maker Name value cannot exceed 50 characters.")]
        public string Name { get; set; }

        //public IEnumerable<CarModel> CarModels { get; set; }
    }
}