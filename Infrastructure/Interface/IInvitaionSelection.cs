using Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IInvitaionSelection
    {
       public List<State> GetState();
       public List<District> GetDistricts(int stateId);
       public List<SubDistrict> GetSubDistricts(int districtId);
       public List<Village> GetVillages(int subDistrictId);
       public List<Recipient> GetRecipients(int villageID);
       public List<InvitedBy> GetInvitedBies(int functionId);
       public List<WhatsappTemplateStructure> GetCardAndVideo(int functionI, string media);
       public Function GetFunction(int functionId);     
       public WhatsappMessage GetWhatsappMessage(int invID,string mediatype);      
       public void RemoveInvitation(int InvId);
        public Invitation GetInvitation(int recipientId, int? functionId);
       public void UpdateEntity<T>(T entity) where T : class;
       public void AddEntity<T>(T entity) where T : class;
       public void RemoveEntityById<T>(int id) where T : class;
       public List<T> GetAllList<T>(Func<T, bool> predicate) where T : class;



    }
}
