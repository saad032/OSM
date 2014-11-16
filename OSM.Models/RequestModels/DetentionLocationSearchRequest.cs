using System;
using OSM.Models.RequestModels;
using OSM.Models.Common;

namespace OSM.Models.RequestModels
{
    public sealed class DetentionLocationSearchRequest : GetPagedListRequest
    {
        public string DetentionLocationId { get; set; }

        public string DetentionLocationName { get; set; }

        public string DetentionLocationDescrition { get; set; }

        public Guid UserId { get; set; }

        public DetentionLocationByColumn DetentionLocationByColumn
        {
            get
            {
                return (DetentionLocationByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
