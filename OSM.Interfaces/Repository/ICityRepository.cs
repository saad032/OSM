using System.Collections.Generic;
using OSM.Models.DomainModels;

namespace OSM.Interfaces.Repository
{
    public interface ICityRepository
    {
        IEnumerable<City> GetAll();
    }
}
