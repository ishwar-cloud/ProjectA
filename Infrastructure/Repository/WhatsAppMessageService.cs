using Infrastructure.DataContext;
using Infrastructure.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Repository
{
    internal class WhatsAppMessageService : IWhatsAppMessageService
    {
        private readonly AmantranContext _context;

        public WhatsAppMessageService(AmantranContext context)
        {
            _context = context;
        }

        public void AddMessage(WhatsappMessage whatsappMessage)
        {
            var message = new WhatsappMessage
            {
                SequenceNumber = whatsappMessage.SequenceNumber,

                // Set other properties as needed
            };
            _context.WhatsappMessages.Add(whatsappMessage);
            _context.SaveChanges();
        }

        public void CreateMessage(int invitationId, int WTStrId, bool isUpdate)
        {
            _context.Database.ExecuteSqlRaw("EXEC YourStoredProcedure @InvitationId, @RecipientId, @TemplateStructureId, @IsUpdate",
                                       new SqlParameter("@InvitationId", invitationId),

                                       new SqlParameter("@TemplateStructureId", WTStrId)
                                       // new SqlParameter("@IsUpdate", isUpdate)
                                       );
        }
    }
}
