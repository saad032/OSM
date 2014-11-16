using System;
using System.Collections.Generic;
using OSM.Models.DomainModels;
using OSM.Models.ResponseModels;
using OSM.Models.RequestModels;

namespace OSM.Interfaces.IServices
{
    public interface ICaseStatusService
    {
        /// <summary>
        /// Load all Case Statuses for Prisoner Add/Edit Screen
        /// </summary>
        /// <returns></returns>
        IEnumerable<CaseStatus> LoadAll();

        bool UpdateCaseStatus(CaseStatus caseStatus);

        void DeleteCaseStatus(CaseStatus caseStatus);

        bool AddCaseStatus(CaseStatus caseStatus);

        CaseStatusResponse GetAllCaseStatuses(CaseStatusSearchRequest caseStatusSearchRequest);

        CaseStatus FindCaseStatusById(int? id);
        IEnumerable<CaseStatus> GetAllCaseStatuses(DateTime from, DateTime to);
    }
}
