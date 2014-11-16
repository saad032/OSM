using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSM.Models.DomainModels
{
    public class DetentionLocation
    {
        public DetentionLocation()
        {
            PrisonerCaseInfos =new HashSet<PrisonerCaseInfo>();
        }
        #region Persisted Properties
        /// <summary>
        /// Detention Location Id
        /// </summary>
        public int DetentionLocationId { get; set; }
        /// <summary>
        /// Detention Location Name
        /// </summary>
        public string DetentionLocationName { get; set; }
        /// <summary>
        /// Detention Location Description
        /// </summary>
        public string DetentionLocationDescription { get; set; }

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
        public virtual ICollection<PrisonerCaseInfo> PrisonerCaseInfos { get; set; } 

        #endregion
    }
}
