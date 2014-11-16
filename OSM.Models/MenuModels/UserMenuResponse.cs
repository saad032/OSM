using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OSM.Models.MenuModels
{
    public class UserMenuResponse
    {
        public IList<MenuRight> MenuRights { get; set; }

        public IList<Menu> Menus { get; set; }

        public IList<IdentityRole> Roles { get; set; }
    }
}
