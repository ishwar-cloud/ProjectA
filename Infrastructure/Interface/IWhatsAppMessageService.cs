using Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IWhatsAppMessageService
    {
        void CreateMessage(int invitationId, int WTStrId, bool isUpdate);
        void AddMessage(WhatsappMessage whatsappMessage);
    }
}
