namespace AccountantTool.Controls.Interfaces
{
    public interface INotifyControlDataSave
    {
        void DoClose();

        bool IsDirty { get; }
    }
}