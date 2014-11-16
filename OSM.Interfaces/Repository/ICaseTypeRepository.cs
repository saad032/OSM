using System;
using System.Collections.Generic;
using OSM.Interfaces.Repository;
using OSM.Models.DomainModels;
using OSM.Models.ResponseModels;
using OSM.Models.RequestModels;

namespace OSM.Interfaces.Repository
{
    public interface ICaseTypeRepository : IBaseRepository<CaseType, int>
    {
        IEnumerable<CaseType> GetAll();

        CaseTypeResponse GetAllCaseTypes(CaseTypeSearchRequest caseTypeSearchRequest);
        CaseType FindCaseTypeById(int caseTypeId);
        IEnumerable<CaseType> GetAllCaseTypes(DateTime from, DateTime to);

    }
}
