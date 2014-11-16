﻿using System.Collections.Generic;
using OSM.Models.DomainModels;
using OSM.Models.ResponseModels;
using OSM.Models.RequestModels;

namespace OSM.Interfaces.IServices
{
    public interface IDetentionAuthorityService
    {
        /// <summary>
        /// Load all Detention Authorities for Prisoner Add/Edit Screen
        /// </summary>
        /// <returns></returns>
        IEnumerable<DetentionAuthority> LoadAll();

        bool UpdateDetentionAuthority(DetentionAuthority detentionAuthority);

        void DeleteDetentionAuthority(DetentionAuthority detentionAuthority);

        bool AddDetentionAuthority(DetentionAuthority detentionAuthority);

        DetentionAuthorityResponse GetAllDetentionAuthorities(DetentionAuthoritySearchRequest detentionAuthoritySearchRequest);

        DetentionAuthority FindDetentionAuthorityById(int? id);
    }
}
