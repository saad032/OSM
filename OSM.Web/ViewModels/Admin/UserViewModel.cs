using System.Collections.Generic;
using OSM.Models.IdentityModels;
using OSM.Models.IdentityModels.ViewModels;
using OSM.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OSM.Web.ViewModels.Admin
{
    public class UserViewModel
    {
        /// <summary>
        /// Data
        /// </summary>
        public List<SystemUser> Data { get; set; }
        public string SelectedRoleId { get; set; }

        public List<IdentityRole> Roles { get; set; }
    }
}