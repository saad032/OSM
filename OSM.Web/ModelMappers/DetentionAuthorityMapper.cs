using OSM.Models.DomainModels;

namespace OSM.Web.ModelMappers
{
    public static class DetentionAuthorityMapper
    {
        public static DetentionAuthority CreateFrom(this Models.DetentionAuthority source)
        {
            var caseType = new DetentionAuthority
            {
                DetentionAuthorityId = source.DetentionAuthorityId ?? 0,
                DetentionAuthorityName = source.DetentionAuthorityName,
                DetentionAuthorityDescription = source.DetentionAuthorityDescription,
                CreatedBy = source.CreatedBy,
                UpdatedBy = source.UpdatedBy,
                CreatedDate = source.CreatedDate,
                UpdatedDate = source.UpdatedDate
            };
            return caseType;
        }
        public static Models.DetentionAuthority CreateFrom(this DetentionAuthority source)
        {
            return new Models.DetentionAuthority
            {
                DetentionAuthorityId = source.DetentionAuthorityId,
                DetentionAuthorityName = source.DetentionAuthorityName,
                DetentionAuthorityDescription = source.DetentionAuthorityDescription
            };

        }
    }
}