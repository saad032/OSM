using System;
using System.Collections.Generic;
using OSM.Models.DomainModels;
using OSM.Models.ResponseModels;
using OSM.Models.RequestModels;

namespace OSM.Interfaces.IServices
{
    public interface ICaseTypeService
    {
        /// <summary>
        /// Load all Case Types for Prisoner Add/Edit Screen
        /// </summary>
        /// <returns></returns>
        IEnumerable<CaseType> LoadAll();

        bool UpdateCaseType(CaseType casetype);

        void DeleteCaseType(CaseType casetype);

        bool AddCaseType(CaseType casetype);

        CaseTypeResponse GetAllCaseType(CaseTypeSearchRequest caseTypeSearchRequest);
        
        CaseType FindCaseTypeById(int? id);

        IEnumerable<CaseType> GetAllCaseTypes(DateTime from, DateTime to);
    }
}
