using System.Collections.Generic;
using OSM.Models.DomainModels;
using OSM.Models.RequestModels;
using CaseStatus = OSM.Web.Models.CaseStatus;
using PrisonerAddress = OSM.Web.Models.PrisonerAddress;
using PrisonerCaseInfo = OSM.Web.Models.PrisonerCaseInfo;
using PrisonerWorkInfo = OSM.Web.Models.PrisonerWorkInfo;

namespace OSM.Web.ViewModels.Prisoner
{
    public class PrisonerViewModel
    {
        //Show List On ClientSide
        public IEnumerable<OSM.Web.Models.Prisoner> PrisonerList { get; set; }
        public IEnumerable<OSM.Web.Models.Prisoner> PrisonerDetainedList { get; set; }
        public IEnumerable<OSM.Web.Models.Prisoner> PrisonerReleasedList { get; set; }

        public IEnumerable<PrisonerAddress> PrisonerAddressList { get; set; }

        public IEnumerable<PrisonerWorkInfo> PrisonerWorkInfoList { get; set; }

        public IEnumerable<PrisonerCaseInfo> PrisonerCaseInfoList { get; set; }

        public IEnumerable<OSM.Models.DomainModels.CaseType> CaseTypes { get; set; }

        public IEnumerable<OSM.Models.DomainModels.CaseStatus> CaseStatuses { get; set; }

        public IEnumerable<OSM.Models.DomainModels.DetentionAuthority> DetanAuthorities { get; set; }

        public IEnumerable<OSM.Models.DomainModels.DetentionLocation> DetanLocations { get; set; }
        public IEnumerable<OSM.Web.Models.DetentionLocation> DetentionLocations { get; set; }
        public IEnumerable<OSM.Web.Models.CaseType> CaseTypesList{ get; set; }
        public IEnumerable<Models.CaseStatus> CaseStatusesList { get; set; }

        public IEnumerable<City> Cities { get; set; }
        

        //Take Data For Edit
        public OSM.Web.Models.Prisoner Prisoner { get; set; }

        public PrisonerSearchRequest SearchRequest { get; set; }

        public int DetainedToday { get; set; }
        public int ReleasedToday { get; set; }
        public int DetainedWeek { get; set; }
        public int ReleasedWeek { get; set; }
        public int DetainedMonth { get; set; }
        public int ReleasedMonth { get; set; }
    }
}