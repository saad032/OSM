using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using OSM.Models.DomainModels;
using OSM.Models.IdentityModels;
using OSM.Models.LoggerModels;
using OSM.Models.MenuModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;

namespace OSM.Repository.BaseRepository
{
    /// <summary>
    /// Base Db Context. Implements Identity Db Context over Application User
    /// </summary>
    public sealed class BaseDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Private
        private IUnityContainer container;
        #endregion
        #region Protected
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<Product>().HasKey(p => p.Id);
            //modelBuilder.Entity<Product>().Property(c => c.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
        #endregion
        #region Constructor
        public BaseDbContext()
        {            
        }
        #endregion
        #region Public

        public BaseDbContext(string connectionString,IUnityContainer container)
            : base(connectionString)
        {
            this.container = container;
        }
        #region Logger

        /// <summary>
        /// Logs
        /// </summary>
        public DbSet<Log> Logs { get; set; }
        /// <summary>
        /// Log Categories
        /// </summary>
        public DbSet<LogCategory> LogCategories { get; set; }
        /// <summary>
        /// Category Logs
        /// </summary>
        public DbSet<CategoryLog> CategoryLogs { get; set; }
        #endregion
        #region Menu Rights and Security
        /// <summary>
        /// Menu Rights
        /// </summary>
        public DbSet<MenuRight> MenuRights { get; set; }
        /// <summary>
        /// Menu
        /// </summary>
        public DbSet<Menu> Menus { get; set; }
        #endregion
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Prisoner> Prisoners { get; set; }
        public DbSet<PrisonerAddress> PrisonerAddresses { get; set; }
        public DbSet<PrisonerWorkInfo> PrisonerWorkInfos { get; set; }
        public DbSet<PrisonerCaseInfo> PrisonerCaseInfos { get; set; }
        public DbSet<DetentionLocation> DetentionLocations { get; set; }
        public DbSet<DetentionAuthority> DetentionAuthorities { get; set; }
        public DbSet<CaseStatus> CaseStatuses { get; set; }
        public DbSet<CaseType> CaseTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Car> Cars{ get; set; }
        public DbSet<CarMaker> CarMakers{ get; set; }
        public DbSet<CarModel> CarModels{ get; set; }
        public DbSet<Customer> Customers{ get; set; }
        #endregion
    }
}
