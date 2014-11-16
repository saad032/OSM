using OSM.Models.DomainModels;

namespace OSM.Models.ModelMapers
{
    public static class DetentionAuthorityMapper
    {
        public static void UpdateTo(this DetentionAuthority source, DetentionAuthority target)
        {
            target.DetentionAuthorityId = source.DetentionAuthorityId;
            target.DetentionAuthorityName = source.DetentionAuthorityName;
            target.DetentionAuthorityDescription = source.DetentionAuthorityDescription;
            target.UpdatedDate = source.UpdatedDate;
            target.UpdatedBy = source.UpdatedBy;
        }
    }
}
