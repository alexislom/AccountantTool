using System.Data.Entity;
using AccountantTool.Model;

namespace AccountantTool.Data
{
    public class AccountantDbContext : DbContext
    {
        #region Construction

        public AccountantDbContext() : base("AccountantDb")
        {
            Configure();
        }

        #endregion Construction

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

        #region Public Properties (tables)

        //public DbSet<Manufacturer> Manufacturers { get; set; }
        //public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<AccountantRecord> AccountantRecords { get; set; }

        #endregion Public Properties (tables)
    }
}