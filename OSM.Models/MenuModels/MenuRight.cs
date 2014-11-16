using Microsoft.AspNet.Identity.EntityFramework;

namespace OSM.Models.MenuModels
{
    /// <summary>
    /// MenuRights class for menu assoication with role
    /// </summary>
    public class MenuRight
    {
        /// <summary>
        /// Menu Right Id
        /// </summary>
        public int MenuRightId { get; set; }
        /// <summary>
        /// Menu
        /// </summary>
        public virtual Menu Menu { get; set; }
        /// <summary>
        /// Role
        /// </summary>
        public virtual IdentityRole Role { get; set; }
    }
}