using OSM.Web.Models;

namespace OSM.Web.ModelMappers
{
    public static class CategoryMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Category CreateFrom(this OSM.Models.DomainModels.Category source)
        {
            return new Category
            {
                Id = source.Id,
                Name = source.Name,
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static OSM.Models.DomainModels.Category CreateFrom(this Category source)
        {
            if (source != null)
            {
                return new OSM.Models.DomainModels.Category
                {
                    Id = source.Id,
                    Name = source.Name,
                };
            }
            return new OSM.Models.DomainModels.Category();
        }

        #endregion
    }
}
