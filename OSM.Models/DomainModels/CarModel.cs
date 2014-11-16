using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OSM.Models.DomainModels
{
    public class CarModel
    {
        public CarModel()
        {
            Cars=new HashSet<Car>();
        }
        [Key]
        public int CarModelId { get; set; }
        //[ForeignKey("CarMaker")]
        //public int CarMakerId { get; set; }
        public string Name { get; set; }
        //public virtual CarMaker CarMaker { get; set; }//Honda
        public ICollection<Car> Cars { get; set; } 
    }
}
