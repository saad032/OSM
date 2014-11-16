using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSM.Models.DomainModels
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsSmsEnabled { get; set; }
        public string Address { get; set; }
        //[ForeignKey("Car")]
        //public int CarId { get; set; }
        public int CarMakerId { get; set; }
        public int CarModelId { get; set; }
        public virtual CarMaker CarMaker { get; set; }
        public virtual CarModel CarModel { get; set; }
        public virtual Car Car { get; set; }
    }
}
