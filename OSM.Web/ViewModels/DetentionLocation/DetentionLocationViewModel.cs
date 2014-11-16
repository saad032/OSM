using System.Collections.Generic;
using OSM.Models.RequestModels;

namespace OSM.Web.ViewModels.DetentionLocation
{
    public class DetentionLocationViewModel
    {
        public IEnumerable<OSM.Web.Models.DetentionLocation> DetentionLocationList { get; set; }

        //Take Data For Edit
        public OSM.Web.Models.DetentionLocation DetentionLocation { get; set; }

        public DetentionLocationSearchRequest SearchRequest { get; set; }
    }
}