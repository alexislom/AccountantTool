using System.Collections.Generic;
using System.Data.Entity;
using AccountantTool.Data.Configs;
using AccountantTool.Model;
using SQLite.CodeFirst;

namespace AccountantTool.Data
{
    public class AccountantDbInitializer : SqliteDropCreateDatabaseWhenModelChanges<AccountantDbContext>
    {
        #region Construction

        public AccountantDbInitializer(DbModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountantRecordConfig());
            modelBuilder.Configurations.Add(new CompanyConfig());
            modelBuilder.Configurations.Add(new RequisitesConfig());
            modelBuilder.Configurations.Add(new ContactPersonConfig());
            modelBuilder.Configurations.Add(new LicenseConfig());
            modelBuilder.Configurations.Add(new ProductConfig());
            modelBuilder.Configurations.Add(new ContractConfig());
            modelBuilder.Configurations.Add(new AdditionalInfoConfig());
        }

        #endregion Construction

        #region Initialization

        //TODO: Create stubs here
        protected override void Seed(AccountantDbContext context)
        {
            var company = new Company { LongName = "TestlongName", ShortName = "TestShortName" };
            var requisites = new Requisites { };
            var contactPerson = new ContactPerson { };
            var license = new License { };
            var products = new List<Product> { new Product { } };
            var contract = new Contract { };
            var additionalInfo = new AdditionalInfo { };

            var accountantRecord = new AccountantRecord
            {
                Company = company,
                Requisites = requisites,
                ContactPerson = contactPerson,
                License = license,
                Product = products,
                Contract = contract,
                AdditionalInfo = additionalInfo
            };

            context.AccountantRecords.Add(accountantRecord);
            context.SaveChanges();
            base.Seed(context);
        }

        #endregion Initialization
    }
}