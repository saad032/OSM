using System;
using System.Collections.Generic;
using OSM.Models.DomainModels;
using OSM.Models.ResponseModels;
using OSM.Models.RequestModels;

namespace OSM.Interfaces.IServices
{
    public interface IDetentionLocationService
    {
        /// <summary>
        /// Load all Detention Locations for Prisoner Add/Edit Screen
        /// </summary>
        /// <returns></returns>
        IEnumerable<DetentionLocation> LoadAll();

        bool UpdateDetentionLocation(DetentionLocation detentionLocation);

        void DeleteDetentionLocation(DetentionLocation detentionLocation);

        bool AddDetentionLocation(DetentionLocation detentionLocation);

        DetentionLocationResponse GetAllDetentionLocations(DetentionLocationSearchRequest detentionLocationSearchRequest);

        DetentionLocation FindDetentionLocationById(int? id);
        IEnumerable<DetentionLocation> GetAllDetentionLocations(DateTime from, DateTime to);
    }
}
