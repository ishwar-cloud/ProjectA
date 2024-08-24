namespace Amantran.BuscinessServices.Interface
{
    public interface IResponseMessageGenerator
    {
        void SetInserts(bool anyInserts);
        void SetUpdates(bool anyUpdates);
       // void SetRemovedRecipients(List<int> removedRecipients);
        void SetCustomMessage(string customMessage);
        string GenerateResponseMessage();
    }
}
