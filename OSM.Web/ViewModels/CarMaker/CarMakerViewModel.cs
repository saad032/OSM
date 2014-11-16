using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OSM.Models.RequestModels;

namespace OSM.Web.ViewModels.CarMaker
{
    public class CarMakerViewModel
    {
        public IEnumerable<Models.CarMaker> CarMakersList { get; set; } 
        // take data for edit
        public Models.CarMaker CarMaker { get; set; }
        public CarMakerSearchRequest CarMakerSearchRequest { get; set; }
    }
}