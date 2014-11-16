using System.Collections.Generic;
using OSM.Interfaces.IServices;
using OSM.Models.DomainModels;
using OSM.Models.ModelMapers;
using OSM.Models.ResponseModels;
using OSM.Interfaces.IServices;
using OSM.Interfaces.Repository;
using OSM.Models.RequestModels;

namespace OSM.Implementation.Services
{
    public class DetentionAuthorityService : IDetentionAuthorityService
    {
        private readonly IDetentionAuthorityRepository iRepository;

        public DetentionAuthorityService(IDetentionAuthorityRepository xRepository)
        {
            iRepository = xRepository;
        }

        public IEnumerable<DetentionAuthority> LoadAll()
        {
            return iRepository.GetAll();
        }

        public bool UpdateDetentionAuthority(DetentionAuthority detentionAuthority)
        {
            var caseTypeToupdate = FindDetentionAuthorityById(detentionAuthority.DetentionAuthorityId);
            if (caseTypeToupdate != null)
            {
                detentionAuthority.UpdateTo(caseTypeToupdate);
                iRepository.Update(caseTypeToupdate);
                iRepository.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteDetentionAuthority(DetentionAuthority detentionAuthority)
        {
            iRepository.Delete(detentionAuthority);
            iRepository.SaveChanges();
        }

        public bool AddDetentionAuthority(DetentionAuthority detentionAuthority)
        {
            iRepository.Add(detentionAuthority);
            iRepository.SaveChanges();
            return true;
        }

        public DetentionAuthorityResponse GetAllDetentionAuthorities(DetentionAuthoritySearchRequest detentionAuthoritySearchRequest)
        {
            return iRepository.GetAllDetentionAuthorities(detentionAuthoritySearchRequest);
        }

        public DetentionAuthority FindDetentionAuthorityById(int? id)
        {
            if (id != null) return iRepository.FindDetentionAuthorityById((int)id);
            return null;
        }
    }
}
