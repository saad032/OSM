using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using OSM.Interfaces.Repository;
using OSM.Models.DomainModels;
using OSM.Models.RequestModels;
using OSM.Models.ResponseModels;
using OSM.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using OSM.Interfaces.Repository;
using OSM.Models.Common;
using OSM.Models.RequestModels;

namespace OSM.Repository.Repositories
{
    public sealed class DetentionLocationRepository : BaseRepository<DetentionLocation>, IDetentionLocationRepository
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public DetentionLocationRepository(IUnityContainer container)
            : base(container)
        {

        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<DetentionLocation> DbSet
        {
            get { return db.DetentionLocations; }
        }

        #endregion

        #region Private

        /// <summary>
        /// Order by Column Names Dictionary statements
        /// </summary>
        private readonly Dictionary<DetentionLocationByColumn, Func<DetentionLocation, object>> detentionLocationClause
            =

            new Dictionary<DetentionLocationByColumn, Func<DetentionLocation, object>>
            {
                {DetentionLocationByColumn.DetentionLocationId, c => c.DetentionLocationId},
                {DetentionLocationByColumn.DetentionLocationName, c => c.DetentionLocationName},
                {DetentionLocationByColumn.DetentionLocationDescrition, c => c.DetentionLocationDescription},
            };

        #endregion

        public IEnumerable<DetentionLocation> GetAll()
        {
            return DbSet.ToList();
        }

        public DetentionLocationResponse GetAllDetentionLocations(
            DetentionLocationSearchRequest detentionLocationSearchRequest)
        {
            int fromRow = (detentionLocationSearchRequest.PageNo - 1)*detentionLocationSearchRequest.PageSize;
            int toRow = detentionLocationSearchRequest.PageSize;

            Expression<Func<DetentionLocation, bool>> query =
                s =>
                    (((detentionLocationSearchRequest.Id == 0) ||
                      s.DetentionLocationId == detentionLocationSearchRequest.Id
                      || s.DetentionLocationId.Equals(detentionLocationSearchRequest.Id)) &&
                     (string.IsNullOrEmpty(detentionLocationSearchRequest.DetentionLocationName)
                      || (s.DetentionLocationName.Contains(detentionLocationSearchRequest.DetentionLocationName))));

            IEnumerable<DetentionLocation> detentionLocations = detentionLocationSearchRequest.IsAsc
                ? DbSet
                    .Where(query)
                    .OrderBy(detentionLocationClause[detentionLocationSearchRequest.DetentionLocationByColumn])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet
                    .Where(query)
                    .OrderByDescending(detentionLocationClause[detentionLocationSearchRequest.DetentionLocationByColumn])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
            return new DetentionLocationResponse
                   {
                       DetentionLocations = detentionLocations,
                       TotalCount = DbSet.Count(query)
                   };
        }

        public DetentionLocation FindDetentionLocationById(int detentionLocationId)
        {
            return
                DbSet.FirstOrDefault(detentionLocation => detentionLocation.DetentionLocationId == detentionLocationId);
        }

        public IEnumerable<DetentionLocation> GetAllDetentionLocations(DateTime from, DateTime to)
        {
            var detentionLocations = DbSet.ToList();
            foreach (var detentionLoacation in detentionLocations)
            {
                detentionLoacation.PrisonerCaseInfos.Select(x => x.ReleaseDate >= from && x.ReleaseDate <= to);
            }
            return detentionLocations;
        }

    }
}
