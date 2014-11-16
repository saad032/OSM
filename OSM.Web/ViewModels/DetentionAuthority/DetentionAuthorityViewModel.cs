using System.Collections.Generic;
using OSM.Models.RequestModels;

namespace OSM.Web.ViewModels.DetentionAuthority
{
    public class DetentionAuthorityViewModel
    {
        public IEnumerable<OSM.Web.Models.DetentionAuthority> DetentionAuthorityList { get; set; }

        //Take Data For Edit
        public OSM.Web.Models.DetentionAuthority DetentionAuthority { get; set; }

        public DetentionAuthoritySearchRequest SearchRequest { get; set; }
    }
}