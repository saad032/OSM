using OSM.Implementation.Services;
using OSM.Interfaces.IServices;
using OSM.Models.IdentityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using OSM.Implementation.Identity;
using OSM.Implementation.Services;
using OSM.Interfaces.IServices;

namespace OSM.Implementation
{
    public static class TypeRegistrations
    {
        public static void RegisterType(IUnityContainer unityContainer)
        {
            UnityConfig.UnityContainer = unityContainer;
            Repository.TypeRegistrations.RegisterType(unityContainer);
            unityContainer.RegisterType<IMenuRightsService, MenuRightsService>();
            unityContainer.RegisterType<ICategoryService, CategoryService>();
            unityContainer.RegisterType<ILogger, LoggerService>();
            unityContainer.RegisterType<IPrisonerService, PrisonerService>();
            unityContainer.RegisterType<ICaseTypeService, CaseTypeService>();
            unityContainer.RegisterType<ICaseStatusService, CaseStatusService>();
            unityContainer.RegisterType<IDetentionAuthorityService, DetentionAuthorityService>();
            unityContainer.RegisterType<IDetentionLocationService, DetentionLocationService>();
            unityContainer.RegisterType<ICityService, CityService>();
            unityContainer.RegisterType<IMenuRightsService, MenuRightsService>();


            unityContainer.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
        }
    }
}
