using System;
using OSM.Models.RequestModels;
using OSM.Models.Common;

namespace OSM.Models.RequestModels
{
    public class DetentionAuthoritySearchRequest :  GetPagedListRequest
    {
        public string DetentionAuthorityId { get; set; }

        public string DetentionAuthorityName { get; set; }

        public string DetentionAuthorityDescrition { get; set; }

        public Guid UserId { get; set; }

        public DetentionAuthorityByColumn DetentionAuthorityByColumn
        {
            get
            {
                return (DetentionAuthorityByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
