using AccountantTool.Model;

namespace AccountantTool.Helpers.Search
{
    public interface IAccountantRecordSearch
    {
        string SearchString { get; set; }
        ICollectionView<AccountantRecord> FilteredAccountantRecords { get; }
    }
}