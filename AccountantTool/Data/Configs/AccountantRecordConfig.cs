using System.Data.Entity.ModelConfiguration;
using AccountantTool.Model;

namespace AccountantTool.Data.Configs
{
    public class AccountantRecordConfig : EntityTypeConfiguration<AccountantRecord>
    {
        //TODO: Update config if it is need
        public AccountantRecordConfig()
        {
            //HasKey(p => p.Id);
        }
    }
}