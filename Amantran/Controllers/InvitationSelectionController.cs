using Amantran.Interface;
using Amantran.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Amantran.Controllers
{
    public class InvitationSelectionController : Controller
    {
        private readonly IInvitaionSelection _invitaionSelection;

        public InvitationSelectionController(IInvitaionSelection invitaionSelection)
        {
            _invitaionSelection = invitaionSelection;
        }

        public IActionResult Index()
        {
            var viewModel = _invitaionSelection.GetState();
            
           

            return View(viewModel);

        }

        [HttpGet]
        public JsonResult GetDistricts(int stateId)
        {
            var districts = _invitaionSelection.GetDistricts(stateId);
            return Json(districts);
        }

        [HttpGet]
        public JsonResult GetSubDistricts(int districtId)
        {
            var subDistricts = _invitaionSelection.GetSubDistricts(districtId);
            return Json(subDistricts);
        }

        [HttpGet]
        public JsonResult GetVillages(int subDistrictId)
        {
            var villages = _invitaionSelection.GetVillages(subDistrictId);
            return Json(villages);
        }


        [HttpGet]
        public IActionResult GetRecipients(int villageId)
        {
            var recipients = _invitaionSelection.GetRecipients(villageId);

             
            // return RedirectToAction("Index", recipients);

            return PartialView("_RecipientTable", recipients);

        }

        [HttpGet]
        public JsonResult GetFunctionProperties()
        {
            var functionModel = _invitaionSelection.GetFunction();
            return Json(functionModel);
        }

        [HttpPost]
        public IActionResult SubmitRecipients(IFormCollection form)
        {
            var invitations = new List<Invitation>();
            var processedRecipients = new HashSet<string>();

            foreach (var key in form.Keys)
            {
                if (key.StartsWith("isOnlyGents_") || key.StartsWith("isWholeFamily_"))
                {
                    var recipientId = key.Split('_')[1];


                    // Skip if this recipient has already been processed
                    if (processedRecipients.Contains(recipientId))
                        continue;

                    var isOnlyGents = form[$"isOnlyGents_{recipientId}"] == "true";
                    var isWholeFamily = form[$"isWholeFamily_{recipientId}"] == "true";
                    var isWedding = form[$"isWedding_{recipientId}"] == "true";
                    var isGaval = form[$"isGaval_{recipientId}"] == "true";
                    var isHalad = form[$"isHalad_{recipientId}"] == "true";
                    var isOvalane = form[$"isOvalane_{recipientId}"] == "true";
                    var isReception = form[$"isReception_{recipientId}"] == "true";
                    var isMehandi = form[$"isMehandi_{recipientId}"] == "true";
                    var isSangit = form[$"isSangit_{recipientId}"] == "true";
                    var invitedById = int.Parse(form[$"invitedBy_{recipientId}"]);

                    // Create and add a new Invitation object to the list
                    invitations.Add(new Invitation
                    {
                        RecipientId = int.Parse(recipientId),
                        Individual = isOnlyGents,
                        WholeFamily = isWholeFamily,
                        Wedding = isWedding,
                        Gaval = isGaval,
                        Halad = isHalad,
                        Ovalane = isOvalane,
                        Reception = isReception,
                        InvitedById = invitedById,
                        Mehendi= isMehandi,
                        Sangeet=isSangit,
                        
                    });

                    processedRecipients.Add(recipientId); // Mark this recipient as processed
                }
            }

            // Use the service to add invitations
            _invitaionSelection.AddInvitations(invitations);

            return RedirectToAction("Index");
        }



    }
}
