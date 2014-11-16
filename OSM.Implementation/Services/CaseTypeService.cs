using System;
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
    public class CaseTypeService : ICaseTypeService
    {
        private readonly ICaseTypeRepository iRepository;

        public CaseTypeService(ICaseTypeRepository xRepository)
        {
            iRepository = xRepository;
        }

        public IEnumerable<CaseType> LoadAll()
        {
            return iRepository.GetAll();
        }

        public bool UpdateCaseType(CaseType caseType)
        {
            var caseTypeToupdate = FindCaseTypeById(caseType.CaseTypeId);
            if (caseTypeToupdate != null)
            {
                caseType.UpdateTo(caseTypeToupdate);
                iRepository.Update(caseTypeToupdate);
                iRepository.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteCaseType(CaseType caseType)
        {
            iRepository.Delete(caseType);
            iRepository.SaveChanges();
        }

        public bool AddCaseType(CaseType caseType)
        {
            iRepository.Add(caseType);
            iRepository.SaveChanges();
            return true;
        }

        public CaseTypeResponse GetAllCaseType(CaseTypeSearchRequest caseTypeSearchRequest)
        {
            return iRepository.GetAllCaseTypes(caseTypeSearchRequest);
        }

        public CaseType FindCaseTypeById(int? id)
        {
            if (id != null) return iRepository.FindCaseTypeById((int)id);
            return null;
        }

        public IEnumerable<CaseType> GetAllCaseTypes(DateTime from, DateTime to)
        {
            return iRepository.GetAllCaseTypes(from, to);
        }
    }
}
