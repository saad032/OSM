using System;
using System.Collections.Generic;
using OSM.Models.DomainModels;
using OSM.Models.ModelMapers;
using OSM.Models.ResponseModels;
using OSM.Interfaces.IServices;
using OSM.Interfaces.Repository;
using OSM.Models.RequestModels;

namespace OSM.Implementation.Services
{
    public class DetentionLocationService : IDetentionLocationService
    {
        private readonly IDetentionLocationRepository iRepository;

        public DetentionLocationService(IDetentionLocationRepository xRepository)
        {
            iRepository = xRepository;
        }

        public IEnumerable<DetentionLocation> LoadAll()
        {
            return iRepository.GetAll();
        }
        public bool UpdateDetentionLocation(DetentionLocation detentionLocation)
        {
            var caseTypeToupdate = FindDetentionLocationById(detentionLocation.DetentionLocationId);
            if (caseTypeToupdate != null)
            {
                detentionLocation.UpdateTo(caseTypeToupdate);
                iRepository.Update(caseTypeToupdate);
                iRepository.SaveChanges();
                return true;
            }
            return false;
        }
        public void DeleteDetentionLocation(DetentionLocation detentionLocation)
        {
            iRepository.Delete(detentionLocation);
            iRepository.SaveChanges();
        }

        public bool AddDetentionLocation(DetentionLocation detentionLocation)
        {
            iRepository.Add(detentionLocation);
            iRepository.SaveChanges();
            return true;
        }

        public DetentionLocationResponse GetAllDetentionLocations(DetentionLocationSearchRequest detentionLocationSearchRequest)
        {
            return iRepository.GetAllDetentionLocations(detentionLocationSearchRequest);
        }

        public DetentionLocation FindDetentionLocationById(int? id)
        {
            if (id != null) return iRepository.FindDetentionLocationById((int)id);
            return null;
        }
        public IEnumerable<DetentionLocation> GetAllDetentionLocations(DateTime from, DateTime to)
        {
            return iRepository.GetAllDetentionLocations(from, to);
        }

    }
}
