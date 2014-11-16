using System.Collections.Generic;
using OSM.Models.RequestModels;

namespace OSM.Web.ViewModels.CaseType
{
    public class CaseTypeViewModel
    {
        public IEnumerable<OSM.Web.Models.CaseType> CaseTypeList { get; set; }

        //Take Data For Edit
        public OSM.Web.Models.CaseType CaseType { get; set; }

        public CaseTypeSearchRequest SearchRequest { get; set; }

    }
}