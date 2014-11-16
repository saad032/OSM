using System.Collections.Generic;
using OSM.Models.DomainModels;

namespace OSM.Models.ResponseModels
{
    public sealed class DetentionAuthorityResponse
    {
        public DetentionAuthorityResponse()
        {
            DetentionAuthorities = new List<DetentionAuthority>();
        }

        /// <summary>
        /// Apartments
        /// </summary>
        public IEnumerable<DetentionAuthority> DetentionAuthorities { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
