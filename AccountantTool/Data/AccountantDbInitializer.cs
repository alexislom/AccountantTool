using System.Data.Entity;
using SQLite.CodeFirst;

namespace AccountantTool.Data
{
    public class AccountantDbInitializer : SqliteDropCreateDatabaseWhenModelChanges<AccountantDbContext>
    {
        #region Construction

        public AccountantDbInitializer(DbModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        #endregion Construction

        #region Initialization

        //TODO: Create stubs here
        protected override void Seed(AccountantDbContext context)
        {
            //context.//DbSet.Add(lalala);
            //context.SaveChanges();
            base.Seed(context);
        }

        #endregion Initialization
    }
}