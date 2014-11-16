using System;
using OSM.Models.Common;

namespace OSM.Models.RequestModels
{
    public class CaseStatusSearchRequest : GetPagedListRequest
    {
        public string CaseStatusId { get; set; }

        public string CaseStatusName { get; set; }

        public string CaseStatusDescrition { get; set; }

        public Guid UserId { get; set; }

        public CaseStatusByColumn CaseStatusByColumn
        {
            get
            {
                return (CaseStatusByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
