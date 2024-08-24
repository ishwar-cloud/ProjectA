using Amantran.Models;
using Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Amantran.BuscinessServices.Interface
{
    public interface IInvitationMaster
    {
        public InvitaionSelectionModel GetState();
        public List<SelectListItem> GetDistricts(int stateId);
        public List<SelectListItem> GetSubDistricts(int districtId);
        public List<SelectListItem> GetVillages(int subDistrictId);
        public InvitaionSelectionModel GetRecipients(int villageid);
        public InvitaionSelectionModel GetFunction();  
        public void RemoveInvitation(int InvId);
        public void CreateOrUpdateCard(string cardIdString, int invitationId, int recipientIdInt,string media);
        public int CreateOrUpdateInvitation(RecipientInvitationData recipientData, int functionId);
        public void CreateWhatsaapMessage(RecipientInvitationData whatsappMessage);
        public void UpdateEntity<T>(T entity) where T : class;
        public void AddEntity<T>(T entity) where T : class;
        public void RemoveEntityById<T>(int id) where T : class;
        public Invitation GetInvitation(int recipientId, int? functionId);

    }
}

