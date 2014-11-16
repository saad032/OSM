using System.Collections.Generic;
using OSM.Interfaces.IServices;
using OSM.Interfaces.Repository;
using OSM.Models.DomainModels;

namespace OSM.Implementation.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository iRepository;

        public CityService(ICityRepository xRepository)
        {
            iRepository = xRepository;
        }

        public IEnumerable<City> LoadAll()
        {
            return iRepository.GetAll();
        }
    }
}
