using Amantran.BuscinessServices.Implimentation;
using Amantran.BuscinessServices.Interface;
using Amantran.Models;
using Infrastructure.DataContext;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Amantran.Controllers
{
    public class InvitationSelectionController : Controller
    {
        private readonly IInvitationMaster _invitationMaster;
        private readonly IResponseMessageGenerator _message;
        public InvitationSelectionController(IInvitationMaster invitationMaster, IResponseMessageGenerator message)
        {
            _invitationMaster = invitationMaster;
            _message = message;
        }

        public IActionResult Index()
        {
            var viewModel = _invitationMaster.GetState();
            return View(viewModel);
        }

        [HttpGet]
        public JsonResult GetDistricts(int stateId)
        {
            var districts = _invitationMaster.GetDistricts(stateId);
            return Json(districts);
        }

        [HttpGet]
        public JsonResult GetSubDistricts(int districtId)
        {
            var subDistricts = _invitationMaster.GetSubDistricts(districtId);
            return Json(subDistricts);
        }

        [HttpGet]
        public JsonResult GetVillages(int subDistrictId)
        {
            var villages = _invitationMaster.GetVillages(subDistrictId);
            return Json(villages);
        }

        [HttpGet]
        public IActionResult GetRecipients(int villageId)
        {
            var recipients = _invitationMaster.GetRecipients(villageId);
            return PartialView("_RecipientTable", recipients);

        }

        [HttpGet]
        public JsonResult GetFunctionProperties()
        {
            var functionModel = _invitationMaster.GetFunction();
            return Json(functionModel);
        }



        
        [HttpPost]
        public JsonResult SubmitRecipients(IFormCollection form)
        {
            var processedRecipients = new HashSet<string>();
            bool anyInserts = false;
            bool anyUpdates = false;

            int functionId = 1;

            foreach (var key in form.Keys)
            {
                var recipientId = key.Split('_')[1];
                int recipientIdInt = int.Parse(recipientId);

                // Check if the key corresponds to a recipient ID
                if (key.StartsWith("isOnlyGents_") || key.StartsWith("isWholeFamily_"))
                {
                    
                    if (processedRecipients.Contains(recipientId))
                        continue;
                              
                    var recipientData = new RecipientInvitationData
                    {
                        RecipientId = recipientIdInt,
                        IsOnlyGents = form[$"isOnlyGents_{recipientId}"] == "true",
                        IsWholeFamily = form[$"isWholeFamily_{recipientId}"] == "true",
                        IsWedding = form[$"isWedding_{recipientId}"] == "true",
                        IsGaval = form[$"isGaval_{recipientId}"] == "true",
                        IsHalad = form[$"isHalad_{recipientId}"] == "true",
                        IsOvalane = form[$"isOvalane_{recipientId}"] == "true",
                        IsReception = form[$"isReception_{recipientId}"] == "true",
                        IsMehandi = form[$"isMehandi_{recipientId}"] == "true",
                        IsSangit = form[$"isSangit_{recipientId}"] == "true",
                        InvitedById = int.Parse(form[$"invitedBy_{recipientId}"]),
                       
                    };

                   

                    var invitationId = _invitationMaster.CreateOrUpdateInvitation(recipientData, 1);
                    anyUpdates = true;


                    // Create WhatsApp message for the card
                    if (form.ContainsKey($"sampleCard_{recipientId}"))
                    {
                        var cardIdString = form[$"sampleCard_{recipientId}"];

                        _invitationMaster.CreateOrUpdateCard(cardIdString, invitationId, recipientIdInt,"Image");
                        
                    }

                    // Create WhatsApp message for the video
                    if (form.ContainsKey($"sampleVideo_{recipientId}"))
                    {
                        var videoIdString = form[$"sampleVideo_{recipientId}"];
                        _invitationMaster.CreateOrUpdateCard(videoIdString, invitationId, recipientIdInt, "Video");
                    }

                    processedRecipients.Add(recipientId); // Mark this recipient as processed
                }
                else if (!key.StartsWith("isOnlyGents_") && !key.StartsWith("isWholeFamily_"))
                {
                    var recipientData = new RecipientInvitationData
                    {
                        IsOnlyGents = form[$"isOnlyGents_{recipientId}"] == "true",
                        IsWholeFamily = form[$"isWholeFamily_{recipientId}"] == "true",
                    };

                    var existingInvitation = _invitationMaster.GetInvitation(recipientIdInt, functionId);

                    

                    if (existingInvitation != null)
                    {
                        if (!recipientData.IsOnlyGents && !recipientData.IsWholeFamily)
                        {

                            var InvId = existingInvitation.InvitationId;
                            _invitationMaster.RemoveInvitation(InvId);

                            
                                                  
                          
                            anyUpdates = true;
                        }
                        else
                        {
                            // Update the existing invitation only if there are changes
                            existingInvitation.Individual = recipientData.IsOnlyGents;
                            existingInvitation.WholeFamily = recipientData.IsWholeFamily;

                            // Update the invitation in the database
                            _invitationMaster.UpdateEntity(existingInvitation);
                            anyUpdates = true;
                        }
                    }
                }
            }

            _message.SetInserts(anyInserts);
            _message.SetUpdates(anyUpdates);

            _message.SetCustomMessage("Please review the changes.");

            var responseMessage = _message.GenerateResponseMessage();

            return Json(new { success = true, message = responseMessage });
        }

    }
}
