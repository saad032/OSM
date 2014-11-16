using OSM.Models.DomainModels;

namespace OSM.Models.ModelMapers
{
    public static class DetentionLocationMapper
    {
        public static void UpdateTo(this DetentionLocation source, DetentionLocation target)
        {
            target.DetentionLocationId = source.DetentionLocationId;
            target.DetentionLocationName = source.DetentionLocationName;
            target.DetentionLocationDescription = source.DetentionLocationDescription;
            target.UpdatedBy = source.UpdatedBy;
            target.UpdatedDate = source.UpdatedDate;
        }
    }
}
