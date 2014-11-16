using System.Collections.Generic;
using OSM.Models.DomainModels;

namespace OSM.Models.ResponseModels
{
    public sealed class CaseStatusResponse
    {
        public CaseStatusResponse()
        {
            CaseStatuses = new List<CaseStatus>();
        }

        /// <summary>
        /// Apartments
        /// </summary>
        public IEnumerable<CaseStatus> CaseStatuses { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
