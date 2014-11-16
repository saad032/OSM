using System.Data.Entity;
using OSM.Interfaces.Repository;
using OSM.Repository.BaseRepository;
using OSM.Repository.Repositories;
using OSM.Web.Views.RolesAdmin;
using Microsoft.Practices.Unity;
using OSM.Interfaces.Repository;
using OSM.Repository.Repositories;

namespace OSM.Repository
{
    public static class TypeRegistrations
    {
        public static void RegisterType(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IMenuRightRepository, MenuRightRepository>();
            unityContainer.RegisterType<ICategoryRepository, CategoryRepository>();
            unityContainer.RegisterType<IPrisonerRepository, PrisonerRepository>();
            unityContainer.RegisterType<ICaseTypeRepository, CaseTypeRepository>();
            unityContainer.RegisterType<ICaseStatusRepository, CaseStatusRepository>();
            unityContainer.RegisterType<IDetentionAuthorityRepository, DetentionAuthorityRepository>();
            unityContainer.RegisterType<IDetentionLocationRepository, DetentionLocationRepository>();
            unityContainer.RegisterType<ICityRepository, CityRepository>();
            unityContainer.RegisterType<IMenuRepository, MenuRepository>();

            unityContainer.RegisterType<DbContext, BaseDbContext>(new PerRequestLifetimeManager());
            //unityContainer.RegisterType<IUser, ApplicationUser>();
        }
    }
}
