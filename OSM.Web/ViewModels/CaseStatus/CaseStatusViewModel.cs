using System.Collections.Generic;
using OSM.Models.RequestModels;

namespace OSM.Web.ViewModels.CaseStatus
{
    public class CaseStatusViewModel
    {
        public IEnumerable<OSM.Web.Models.CaseStatus> CaseStatusList { get; set; }

        //Take Data For Edit
        public OSM.Web.Models.CaseStatus CaseStatus { get; set; }

        public CaseStatusSearchRequest SearchRequest { get; set; }
    }
}