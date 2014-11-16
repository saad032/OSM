using System.Collections.Generic;
using System.Linq;
using OSM.Models.MenuModels;

namespace OSM.Interfaces.Repository
{
    public interface IMenuRightRepository : IBaseRepository<MenuRight, int>
    {
        IQueryable<MenuRight> GetMenuByRole(string roleId);
    }
}
