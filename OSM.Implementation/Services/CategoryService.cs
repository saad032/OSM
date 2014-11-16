using System.Collections.Generic;
using OSM.Interfaces.IServices;
using OSM.Interfaces.Repository;
using OSM.Models.DomainModels;

namespace OSM.Implementation.Services
{
    /// <summary>
    /// Category Service
    /// </summary>
    public class CategoryService : ICategoryService
    {
        #region Private
        private readonly ICategoryRepository categoryRepository;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="categoryRepository"></param>
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;

        }
        #endregion

        #region Public
        /// <summary>
        /// Load All Categories
        /// </summary>
        public IEnumerable<Category> LoadAllCategories()
        {

            return categoryRepository.GetAllCategories();
        }
        #endregion
    }
}
