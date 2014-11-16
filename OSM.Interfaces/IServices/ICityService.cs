using System.Collections.Generic;
using OSM.Models.DomainModels;

namespace OSM.Interfaces.IServices
{
    public interface  ICityService
    {
        /// <summary>
        /// Load all Cities for Prisoner Add/Edit Screen
        /// </summary>
        /// <returns></returns>
        IEnumerable<City> LoadAll();
    }
}
