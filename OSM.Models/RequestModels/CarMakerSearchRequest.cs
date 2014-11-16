using System;
using OSM.Models.Common;

namespace OSM.Models.RequestModels
{
    public class CarMakerSearchRequest : GetPagedListRequest
    {
        public int CarMakerId { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public CarMakerByColumn CaseStatusByColumn
        {
            get
            {
                return (CarMakerByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
