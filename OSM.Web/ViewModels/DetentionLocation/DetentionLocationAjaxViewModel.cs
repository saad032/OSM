﻿using System.Collections.Generic;
using OSM.Models.RequestModels;

namespace OSM.Web.ViewModels.DetentionLocation
{
    public class DetentionLocationAjaxViewModel
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
        public IEnumerable<OSM.Web.Models.DetentionLocation> data;
        /// <summary>
        /// Search Request
        /// </summary>
        public DetentionLocationSearchRequest DetentionLocationSearchRequest { get; set; }
    }
}