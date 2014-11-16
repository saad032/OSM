﻿using System.Collections.Generic;
using OSM.Models.RequestModels;

namespace OSM.Web.ViewModels.CaseType
{
    public class CaseTypeAjaxViewModel
    {
        /// <summary>
        /// To draw table
        /// </summary>
        private int draw = 1;

        /// <summary>
        /// Total Records in DB
        /// </summary>
        public int recordsTotal;

        /// <summary>
        /// Total Records Filtered
        /// </summary>
        public int recordsFiltered;

        /// <summary>
        /// Data
        /// </summary>
        public IEnumerable<OSM.Web.Models.CaseType> data;
        /// <summary>
        /// Search Request
        /// </summary>
        public CaseTypeSearchRequest CaseTypeSearchRequest { get; set; }
    }
}