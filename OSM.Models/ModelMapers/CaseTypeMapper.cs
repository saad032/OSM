using OSM.Models.DomainModels;

namespace OSM.Models.ModelMapers
{
    public static class CaseTypeMapper
    {
        public static void UpdateTo(this CaseType source, CaseType target)
        {
            target.CaseTypeId = source.CaseTypeId;
            target.CaseTypeName = source.CaseTypeName;
            target.CaseTypeDescription = source.CaseTypeDescription;
            target.UpdatedBy = source.UpdatedBy;
            target.UpdatedDate = source.UpdatedDate;
        }
    }
}
