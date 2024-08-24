using Infrastructure.DataContext;
using Infrastructure.Interface;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Repository
{
    public class InvitaionSelection : IInvitaionSelection
    {
        private readonly AmantranContext _context;
        

        public InvitaionSelection(AmantranContext context )
        {
            _context = context;
           
        }
        public List<District> GetDistricts(int stateId)
        {
            return _context.Districts.Where(d => d.StateId == stateId).ToList();
        }
        public Function GetFunction(int functionId)
        {
            return _context.Functions.FirstOrDefault(fd => fd.FunctionId == functionId);

        }
        public List<InvitedBy> GetInvitedBies(int functionId)
        {
            return _context.InvitedBies.Where(i => i.FunctionId == functionId).ToList();
        }
        public List<Recipient> GetRecipients(int villageID)
        {
            return _context.Recipients.Where(r => r.VillageId == villageID).ToList();
        }
        public List<WhatsappTemplateStructure> GetCardAndVideo(int functionI, string media)
        {
            return _context.WhatsappTemplateStructures.Where(f => f.FunctionId == functionI && f.Type == media).ToList();
        }
        public List<State> GetState()
        {
            return _context.States.ToList();
        }
        public List<SubDistrict> GetSubDistricts(int districtId)
        {
            return _context.SubDistricts.Where(sb => sb.DistrictId == districtId).ToList();
        }
        public List<Village> GetVillages(int subDistrictId)
        {
            return _context.Villages.Where(v => v.SubDistrictId == subDistrictId).ToList();
        }
        public void RemoveInvitation(int InvId)
        {            
            var isDelete = removeMessage(InvId);
            if (isDelete)
            {
                RemoveEntityById<Invitation>(InvId);
            }
        }
        public bool removeMessage(int invitationID)
        {
            var messages = _context.WhatsappMessages.Where(m =>m.InvitationId == invitationID).ToList();
            if (messages.Any())
            {
                _context.WhatsappMessages.RemoveRange(messages); // Remove all messages in one go
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public WhatsappMessage GetWhatsappMessage(int InvId, string mediatype)
        {            
            return _context.WhatsappMessages.Where(i => i.InvitationId == InvId && i.MediaType == mediatype).FirstOrDefault();
        }
        public Invitation GetInvitation(int recipientId, int? functionId = null)
        {
            return functionId.HasValue
                ? _context.Invitations.FirstOrDefault(i => i.RecipientId == recipientId && i.FunctionId == functionId.Value)
                : _context.Invitations.FirstOrDefault(i => i.RecipientId == recipientId);
        }

        public void UpdateEntity<T>(T entity) where T : class
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
        public void AddEntity<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public void RemoveEntityById<T>(int id) where T : class
        {
            var entity = _context.Set<T>().Find(id); 
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
        }
        public List<T> GetAllList<T>(Func<T, bool> predicate) where T : class
        {
            return _context.Set<T>().Where(predicate).ToList();
        }
       


    }
}
