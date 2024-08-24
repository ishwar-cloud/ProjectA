using Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Amantran.Models
{
    public class InvitaionSelectionModel
    {

        public List<SelectListItem> StateList { get; set; }
        public List<SelectListItem> DistrictList { get; set; }
        public List<SelectListItem> SubDistrictList { get; set; }
        public List<SelectListItem> VillageList { get; set; }

        public List<Recipient> Recipients { get; set; }
        public List<InvitedBy> InvitedByList { get; set; }

        public List<Function> FunctionList { get; set; }

        // Properties for dynamic headers
        public bool IsWedding { get; set; }
        public bool IsGaval { get; set; }
        public bool IsHalad { get; set; }
        public bool IsOvalane { get; set; }
        public bool IsReception { get; set; }
        public bool IsMehandi { get; set; }
        public bool IsSangit { get; set; }

        public InvitedBy DefaultInvitedBy { get; set; }
        public List<Invitation> ExistingInvitations { get; set; }
        public List<WhatsappMessage> ExistVideoList{  get; set; }
        public List<WhatsappMessage> ExistcardsList { get; set; }
        public List<WhatsappTemplateStructure> SampleCards { get; set; }
        public List<WhatsappTemplateStructure> SampleVideo { get; set; }
    }
}
