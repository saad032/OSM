using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSM.Models.DomainModels
{
    public class Car
    {
        [Key]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public string ManufacturingYear { get; set; }//etc 2005
        /// <summary>
        /// Car Model Contains :- 
        /// CarModel.Name = City
        /// CarModel.CarMaker = Honda
        /// </summary>
        [ForeignKey("CarModel")]
        public int CarModelId { get; set; }
        [ForeignKey("CarMaker")]
        public int CarMakerId { get; set; }
        /// <summary>
        /// Car Milage Per Km
        /// </summary>
        public int Milage { get; set; }

        public virtual CarMaker CarMaker { get; set; }
        public virtual CarModel CarModel { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
