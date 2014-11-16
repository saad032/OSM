using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OSM.Models.DomainModels
{
    public class CarMaker
    {
        public CarMaker()
        {
            Cars = new HashSet<Car>();
        }
        [Key]
        public int CarMakerId { get; set; }
        public string Name { get; set; }
        ////[ForeignKey("CarModel")]
        //public int CarModelId { get; set; }
        //public virtual CarModel CarModel { get; set; }

        public ICollection<Car> Cars { get; set; }
        public ICollection<CarModel> CarModels { get; set; }
    }
}
