using System;
using System.Collections.Generic;
using OSM.Interfaces.IServices;
using OSM.Interfaces.Repository;
using OSM.Models.DomainModels;
using OSM.Models.ModelMapers;
using OSM.Interfaces.IServices;
using OSM.Interfaces.Repository;
using OSM.Models.RequestModels;
using OSM.Models.ResponseModels;

namespace OSM.Implementation.Services
{
    public class CaseStatusService : ICaseStatusService
    {
        private readonly ICaseStatusRepository iRepository;

        public CaseStatusService(ICaseStatusRepository xRepository)
        {
            iRepository = xRepository;
        }

        public IEnumerable<CaseStatus> LoadAll()
        {
            return iRepository.GetAll();
        }

        public bool UpdateCaseStatus(CaseStatus caseStatus)
        {
            var caseStatusToupdate = FindCaseStatusById(caseStatus.CaseStatusId);
            if (caseStatusToupdate != null)
            {
                caseStatus.UpdateTo(caseStatusToupdate);
                iRepository.Update(caseStatusToupdate);
                iRepository.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteCaseStatus(CaseStatus caseStatus)
        {
            iRepository.Delete(caseStatus);
            iRepository.SaveChanges();
        }

        public bool AddCaseStatus(CaseStatus caseStatus)
        {
            iRepository.Add(caseStatus);
            iRepository.SaveChanges();
            return true;
        }

        public CaseStatusResponse GetAllCaseStatuses(CaseStatusSearchRequest caseStatusSearchRequest)
        {
            return iRepository.GetAllCaseStatuses(caseStatusSearchRequest);
        }

        public CaseStatus FindCaseStatusById(int? id)
        {
            if (id != null) return iRepository.FindCaseStatusById((int)id);
            return null;
        }

        public IEnumerable<CaseStatus> GetAllCaseStatuses(DateTime from, DateTime to)
        {
            return iRepository.GetAllCaseStatuses(from, to);
        } 
    }
}
