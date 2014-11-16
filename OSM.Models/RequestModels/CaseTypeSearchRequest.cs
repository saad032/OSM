﻿using System;
using OSM.Models.RequestModels;
using OSM.Models.Common;

namespace OSM.Models.RequestModels
{
    public class CaseTypeSearchRequest : GetPagedListRequest
    {
        public string CaseTypeId { get; set; }

        public string CaseTypeName { get; set; }

        public string CaseTypeDescrition { get; set; }

        public Guid UserId { get; set; }

        public CaseTypeByColumn CaseTypeByColumn
        {
            get
            {
                return (CaseTypeByColumn)SortBy;
            }
            set
            {
                SortBy = (short)value;
            }
        }
    }
}
