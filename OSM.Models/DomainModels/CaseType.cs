using System;
using System.Collections.Generic;

namespace OSM.Models.DomainModels
{
    public class CaseType
    {
        public CaseType()
        {
            PrisonerCaseInfos = new HashSet<PrisonerCaseInfo>();
        }
        #region Persisted Properties
        /// <summary>
        /// Case Type Id
        /// </summary>
        public int CaseTypeId { get; set; }
        /// <summary>
        /// Case Type Name
        /// </summary>
        public string CaseTypeName { get; set; }
        /// <summary>
        /// Case Type Description
        /// </summary>
        public string CaseTypeDescription { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Record Updated By
        /// </summary>
        public string UpdatedBy { get; set; }
        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Record Updated Date
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        public ICollection<PrisonerCaseInfo> PrisonerCaseInfos { get; set; }

        #endregion
    }
}
