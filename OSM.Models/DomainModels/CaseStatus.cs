using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSM.Models.DomainModels
{
    public class CaseStatus
    {
        public CaseStatus()
        {
            PrisonerCaseInfos = new HashSet<PrisonerCaseInfo>();
        }
        #region Persisted Properties
        /// <summary>
        /// Case Status Id
        /// </summary>
        public int CaseStatusId { get; set; }
        /// <summary>
        /// Case Status Name
        /// </summary>
        public string CaseStatusName { get; set; }
        /// <summary>
        ///  Case Status Description
        /// </summary>
        public string CaseStatusDescription { get; set; }

        public ICollection<PrisonerCaseInfo> PrisonerCaseInfos{ get; set; }

        #endregion   
    }
}
