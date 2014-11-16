using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSM.Models.DomainModels;

namespace OSM.Models.ResponseModels
{
    public sealed class DetentionLocationResponse
    {
        public DetentionLocationResponse()
        {
            DetentionLocations = new List<DetentionLocation>();
        }

        /// <summary>
        /// Apartments
        /// </summary>
        public IEnumerable<DetentionLocation> DetentionLocations { get; set; }

        /// <summary>
        /// Total Count
        /// </summary>
        public int TotalCount { get; set; }
    }
}
