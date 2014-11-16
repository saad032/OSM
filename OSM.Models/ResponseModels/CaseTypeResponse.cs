using System.Collections.Generic;
using OSM.Models.DomainModels;

namespace OSM.Models.ResponseModels
{
    public sealed class CaseTypeResponse
    {
        public CaseTypeResponse()
        {
            CaseTypes = new List<CaseType>();
        }

        /// <summary>
        /// Apartments
        /// </summary>
        public IEnumerable<CaseType> CaseTypes { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
