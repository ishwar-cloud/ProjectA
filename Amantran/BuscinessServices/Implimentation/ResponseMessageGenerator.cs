using Amantran.BuscinessServices.Interface;

namespace Amantran.BuscinessServices.Implimentation
{
    public class ResponseMessageGenerator : IResponseMessageGenerator
    {
        private bool _anyInserts;
        private bool _anyUpdates;
        private List<int> _removedRecipients;
        private string _customMessage;

        private readonly string _insertMessage = "New records inserted successfully.";
        private readonly string _updateMessage = "Recipients updated successfully.";
        private readonly string _combinedMessage = "Recipients updated and new records inserted successfully.";
        private readonly string _removedPrefix = "Removed recipients: ";

        public void SetInserts(bool anyInserts)
        {
            _anyInserts = anyInserts;
        }

        public void SetUpdates(bool anyUpdates)
        {
            _anyUpdates = anyUpdates;
        }

        //public void SetRemovedRecipients(List<int> removedRecipients)
        //{
        //    _removedRecipients = removedRecipients;
        //}

        public void SetCustomMessage(string customMessage)
        {
            _customMessage = customMessage;
        }

        public string GenerateResponseMessage()
        {
            var responseMessage = string.Empty;

            if (_anyInserts && _anyUpdates)
            {
                responseMessage = _combinedMessage;
            }
            else if (_anyInserts)
            {
                responseMessage = _insertMessage;
            }
            else if (_anyUpdates)
            {
                responseMessage = _updateMessage;
            }

            if (_removedRecipients != null && _removedRecipients.Any())
            {
                responseMessage += " " + _removedPrefix + string.Join(", ", _removedRecipients);
            }

            if (!string.IsNullOrEmpty(_customMessage))
            {
                responseMessage += " " + _customMessage;
            }

            return responseMessage;
        }
    }
}
