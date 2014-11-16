using System.Collections.Generic;
using OSM.Models.MenuModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OSM.Web.ViewModels.RightsManagement
{
    public class RightsManagementViewModel
    {
        public List<Rights> Rights { get; set; }
        public string SelectedRoleId { get; set; }

        public List<IdentityRole> Roles { get; set; }
    }
}