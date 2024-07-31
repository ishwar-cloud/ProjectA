using Amantran.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Amantran.Interface
{
    public interface IInvitaionSelection
    {
        List<SelectListItem> GetDistricts(int stateId);
        List<SelectListItem> GetSubDistricts(int districtId);
        List<SelectListItem> GetVillages(int subDistrictId);

        InvitaionSelectionModel GetState();
        InvitaionSelectionModel GetFunction();

        InvitaionSelectionModel GetRecipients(int villageid);

        void AddInvitations(IEnumerable<Invitation> invitations);

    }
}
