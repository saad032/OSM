using System.Linq;
using OSM.Models.DomainModels;

namespace OSM.Web.ModelMappers
{
    public static class DetentionLocationMapper
    {
        public static DetentionLocation CreateFrom(this Models.DetentionLocation source)
        {
            var caseType = new DetentionLocation
            {
                DetentionLocationId = source.DetentionLocationId ?? 0,
                DetentionLocationName = source.DetentionLocationName,
                DetentionLocationDescription = source.DetentionLocationDescription,
                CreatedBy = source.CreatedBy,
                UpdatedBy = source.UpdatedBy,
                CreatedDate = source.CreatedDate,
                UpdatedDate = source.UpdatedDate
            };
            return caseType;
        }
        public static Models.DetentionLocation CreateFrom(this DetentionLocation source)
        {
            return new Models.DetentionLocation
            {
                DetentionLocationId = source.DetentionLocationId,
                DetentionLocationName = source.DetentionLocationName,
                DetentionLocationDescription = source.DetentionLocationDescription,
                NumberOfPrisoners = source.PrisonerCaseInfos.Count(x => x.DetentionLocationId == source.DetentionLocationId)
            };

        }
    }
}