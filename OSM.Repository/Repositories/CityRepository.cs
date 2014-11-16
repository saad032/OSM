using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OSM.Interfaces.Repository;
using OSM.Repository.BaseRepository;
using OSM.Models.DomainModels;
using Microsoft.Practices.Unity;

namespace OSM.Repository.Repositories
{
    public sealed class CityRepository : BaseRepository<City>, ICityRepository
    {
        #region Constructor

            /// <summary>
            /// Constructor
            /// </summary>
            public CityRepository(IUnityContainer container)
                : base(container)
            {

            }

            /// <summary>
            /// Primary database set
            /// </summary>
            protected override IDbSet<City> DbSet
            {
                get { return db.Cities; }
            }

        #endregion

        public IEnumerable<City> GetAll()
        {
            return DbSet.ToList();
        }
    }
}
