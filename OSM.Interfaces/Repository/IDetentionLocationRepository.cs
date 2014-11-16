using System;
using System.Collections.Generic;
using OSM.Interfaces.Repository;
using OSM.Models.DomainModels;
using OSM.Models.ResponseModels;
using OSM.Models.RequestModels;

namespace OSM.Interfaces.Repository
{
    public interface IDetentionLocationRepository : IBaseRepository<DetentionLocation, int>
    {
        IEnumerable<DetentionLocation> GetAll();

        DetentionLocationResponse GetAllDetentionLocations(DetentionLocationSearchRequest detentionLocationSearchRequest);
        DetentionLocation FindDetentionLocationById(int detentionLocationId);
        IEnumerable<DetentionLocation> GetAllDetentionLocations(DateTime from, DateTime to);
    }
}
