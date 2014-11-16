using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OSM.Implementation.Identity;
using OSM.Interfaces.IServices;
using OSM.Models.IdentityModels;
using OSM.Models.MenuModels;
using OSM.WebBase.UnityConfiguration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Practices.Unity;

namespace OSM.Web.Controllers
{
    public class BaseController : Controller
    {
        #region Private

        private ApplicationUserManager _userManager;
        private IMenuRightsService menuRightService;

        #endregion

        #region Protected
        // GET: Base
        protected override async void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["FullName"] == null || Session["FullName"] == string.Empty)
                SetUserDetail();
        }

        #endregion

        #region Public

//when isForce =  true it sets the value, no matter session has or not
        public void SetUserDetail()
        {
            Session["FullName"] = Session["LoginID"] = string.Empty;
            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser result =
                    HttpContext.GetOwinContext()
                        .GetUserManager<ApplicationUserManager>()
                        .FindByEmail(User.Identity.Name);
                string role =
                    HttpContext.GetOwinContext()
                        .Get<ApplicationRoleManager>()
                        .FindById(result.Roles.ToList()[0].RoleId)
                        .Name;
                Session["FullName"] = result.FirstName + " " + result.LastName;
                Session["ProfileImage"] = result.ImageName;
                Session["LoginID"] = result.Id;
                Session["RoleName"] = role;

                menuRightService = UnityWebActivator.Container.Resolve<IMenuRightsService>();

                ApplicationUser userResult = UserManager.FindByEmail(User.Identity.Name);
                IList<IdentityUserRole> roles = userResult.Roles.ToList();
                IList<MenuRight> userRights =
                    menuRightService.FindMenuItemsByRoleId(roles[0].RoleId).ToList();

                string[] userPermissions = userRights.Select(user => user.Menu.PermissionKey).ToArray();
                Session["UserPermissionSet"] = userPermissions;
                return;
            }

        }



        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        #endregion

    }
}