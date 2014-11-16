using System.Linq;
using OSM.Models.DomainModels;

namespace OSM.Web.ModelMappers
{
    public static class CaseTypeMapper
    {

        public static CaseType CreateFrom(this Models.CaseType source)
        {
            var caseType = new CaseType
            {
                CaseTypeId = source.CaseTypeId ?? 0,
                CaseTypeName = source.CaseTypeName,
                CaseTypeDescription = source.CaseTypeDescription,
                CreatedBy = source.CreatedBy,
                UpdatedBy = source.UpdatedBy,
                CreatedDate = source.CreatedDate,
                UpdatedDate = source.UpdatedDate
            };
            return caseType;
        }
        public static Models.CaseType CreateFrom(this CaseType source)
        {
            return new Models.CaseType
            {
                CaseTypeId = source.CaseTypeId,
                CaseTypeName = source.CaseTypeName,
                CaseTypeDescription = source.CaseTypeDescription,
                NumberOfPrisoners = source.PrisonerCaseInfos.Count(x => x.CaseTypeId == source.CaseTypeId)
            };

        }
    }
}