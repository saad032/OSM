using System.Collections.Generic;
using OSM.Models.DomainModels;

namespace OSM.Interfaces.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category, int>
    {
        IEnumerable<Category> GetAllCategories();
    }
}
