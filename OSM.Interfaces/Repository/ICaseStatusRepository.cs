using System;
using System.Collections.Generic;
using OSM.Interfaces.Repository;
using OSM.Models.DomainModels;
using OSM.Models.ResponseModels;
using OSM.Models.RequestModels;

namespace OSM.Interfaces.Repository
{
    public interface ICaseStatusRepository : IBaseRepository<CaseStatus, int>
    {
        IEnumerable<CaseStatus> GetAll();

        CaseStatusResponse GetAllCaseStatuses(CaseStatusSearchRequest caseStatusSearchRequest);
        CaseStatus FindCaseStatusById(int caseStatusId);
        IEnumerable<CaseStatus> GetAllCaseStatuses(DateTime from, DateTime to);
    }
}
