using System.Data.Entity;
using AccountantTool.Model;

namespace AccountantTool.Data
{
    public class AccountantDbContext : DbContext
    {
        #region Construction

        public AccountantDbContext() : this("AccountantDb")
        {
        }

        public AccountantDbContext(string connectionString)
            : base(connectionString)
        {
            Configure();
        }

        #endregion Construction

        #region Public Properties (tables)

        public DbSet<AccountantRecord> AccountantRecords { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Requisites> Requisites { get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<AdditionalInfo> AdditionalInfos { get; set; }

        #endregion Public Properties (tables)

        #region Configuration

        private void Configure()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }
        #endregion Configuration

        #region Initialization

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var initializer = new AccountantDbInitializer(modelBuilder);
            Database.SetInitializer(initializer);
        }
        #endregion Initialization


    }
}