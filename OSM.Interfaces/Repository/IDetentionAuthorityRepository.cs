using System.Collections.Generic;
using OSM.Interfaces.Repository;
using OSM.Models.DomainModels;
using OSM.Models.ResponseModels;
using OSM.Models.RequestModels;

namespace OSM.Interfaces.Repository
{
    public interface IDetentionAuthorityRepository : IBaseRepository<DetentionAuthority, int>
    {
        IEnumerable<DetentionAuthority> GetAll();

        DetentionAuthorityResponse GetAllDetentionAuthorities(DetentionAuthoritySearchRequest detentionAuthoritySearchRequest);
        DetentionAuthority FindDetentionAuthorityById(int detentionAuthorityId);
    }
}
