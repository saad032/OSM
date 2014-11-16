using System.Collections.Generic;
using OSM.Models.DomainModels;

namespace OSM.Interfaces.IServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> LoadAllCategories();
    }
}
