using Amantran.BuscinessServices.Interface;
using Amantran.Models;
using Infrastructure.DataContext;
using Infrastructure.Interface;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Amantran.BuscinessServices.Implimentation
{
    public class InvitationMaster : IInvitationMaster
    {
        private int functionId = 1;
        private readonly IInvitaionSelection _invitationSelection;

        public InvitationMaster(IInvitaionSelection invitationSelection)
        {

            _invitationSelection = invitationSelection;
        }
        public List<SelectListItem> GetDistricts(int stateId)
        {

            var district = _invitationSelection.GetDistricts(stateId);
           
            return district
                .Where(d => d.StateId == stateId)
                .Select(d => new SelectListItem
                {
                    Text = d.DistrictName,
                    Value = d.DistrictId.ToString()
                })
                .ToList();
        }
        public InvitaionSelectionModel GetFunction()
        {
            var function = _invitationSelection.GetFunction(1);//need to pass function id 
            if (function == null)
            {
                return null;
            }
            var functionModel = new InvitaionSelectionModel
            {
                IsWedding = function?.IsWeeding ?? false,
                IsGaval = function?.IsGaval ?? false,
                IsHalad = function?.IsHalad ?? false,
                IsOvalane = function?.IsOvalane ?? false,
                IsReception = function?.IsReception ?? false,
                IsMehandi = function?.IsMehandi ?? false,
                IsSangit = function?.IsSangit ?? false
            };

            return functionModel;

        }
        public InvitaionSelectionModel GetRecipients(int villageid)
        {
            


            var invitedByOptions = _invitationSelection.GetInvitedBies(functionId);
            var recipients = _invitationSelection.GetRecipients(villageid);
            var cards = _invitationSelection.GetCardAndVideo(functionId,"Image");
            var video = _invitationSelection.GetCardAndVideo(functionId,"Video");
            var defaultInvitedBy = invitedByOptions.FirstOrDefault(i => i.Default);

            // List to store recipients that already exist in the Invitation table
            var existingInvitations = new List<Invitation>();
            var existVideos = new List<WhatsappMessage>();
            var existCards = new List<WhatsappMessage>();

            foreach (var recipient in recipients)
            {
                var existingInvitation = (Invitation)_invitationSelection.GetInvitation(recipient.RecipientId, functionId);
               
                if (existingInvitation != null)
                {
                    var InvId = existingInvitation.InvitationId;
                    var  existCard = _invitationSelection.GetWhatsappMessage(InvId, "Image");
                    var  existVideo = _invitationSelection.GetWhatsappMessage(InvId, "Video");

                    existingInvitations.Add(existingInvitation);
                    existVideos.Add(existVideo);
                    existCards.Add(existCard);
                }
            }
            var recipentModel = new InvitaionSelectionModel
            {
                Recipients = recipients,
                InvitedByList = invitedByOptions,
                DefaultInvitedBy = defaultInvitedBy,
                SampleVideo = video,
                SampleCards = cards,
                ExistingInvitations = existingInvitations,
                ExistVideoList=existVideos,  
                ExistcardsList=existCards,
            };
            return recipentModel;
        }
        public InvitaionSelectionModel GetState()
        {
            var viewModel = new InvitaionSelectionModel
            {
                StateList = new List<SelectListItem>(),
                DistrictList = new List<SelectListItem>(),
                SubDistrictList = new List<SelectListItem>(),
                VillageList = new List<SelectListItem>()
            };

            var states = _invitationSelection.GetState();
            foreach (var item in states)
            {
                viewModel.StateList.Add(new SelectListItem
                {
                    Text = item.StateName,
                    Value = item.StateId.ToString()
                });
            }
            return viewModel;
        }
        public List<SelectListItem> GetSubDistricts(int districtId)
        {
            var subDistric = _invitationSelection.GetSubDistricts(districtId);
            return subDistric.Select(sd => new SelectListItem
            {
                Text = sd.SubDistrictName,
                Value = sd.SubDistrictId.ToString()
            })
            .ToList();
        }
        public List<SelectListItem> GetVillages(int subDistrictId)
        {
            var villages = _invitationSelection.GetVillages(subDistrictId);
            return villages
                .Select(v => new SelectListItem
                {
                    Text = v.VillageName,
                    Value = v.VillageId.ToString()
                })
                .ToList();
        }
        public void RemoveInvitation(int InvId)
        {
            _invitationSelection.RemoveInvitation(InvId);
        }
        public int CreateOrUpdateInvitation(RecipientInvitationData recipientData, int functionId)
        {
            var existingInvitation = (Invitation)_invitationSelection.GetInvitation(recipientData.RecipientId, functionId);
            


            if (existingInvitation != null)
            {
                // Check if any updates are necessary
                if (existingInvitation.Individual != recipientData.IsOnlyGents ||
                    existingInvitation.WholeFamily != recipientData.IsWholeFamily ||
                    existingInvitation.Wedding != recipientData.IsWedding ||
                    existingInvitation.Gaval != recipientData.IsGaval ||
                    existingInvitation.Halad != recipientData.IsHalad ||
                    existingInvitation.Ovalane != recipientData.IsOvalane ||
                    existingInvitation.Reception != recipientData.IsReception ||
                    existingInvitation.InvitedById != recipientData.InvitedById ||
                    existingInvitation.Mehendi != recipientData.IsMehandi ||
                    existingInvitation.Sangeet != recipientData.IsSangit)
                {
                    // Update the existing invitation with the new data
                    existingInvitation.Individual = recipientData.IsOnlyGents;
                    existingInvitation.WholeFamily = recipientData.IsWholeFamily;
                    existingInvitation.Wedding = recipientData.IsWedding;
                    existingInvitation.Gaval = recipientData.IsGaval;
                    existingInvitation.Halad = recipientData.IsHalad;
                    existingInvitation.Ovalane = recipientData.IsOvalane;
                    existingInvitation.Reception = recipientData.IsReception;
                    existingInvitation.InvitedById = recipientData.InvitedById;
                    existingInvitation.Mehendi = recipientData.IsMehandi;
                    existingInvitation.Sangeet = recipientData.IsSangit;

                    _invitationSelection.UpdateEntity(existingInvitation);
                }

                // Return the InvitationId of the updated invitation
                return existingInvitation.InvitationId;
            }
            else
            {
                // Create a new invitation with the provided data
                var invitation = new Invitation
                {
                    RecipientId = recipientData.RecipientId,
                    FunctionId = functionId,
                    Individual = recipientData.IsOnlyGents,
                    WholeFamily = recipientData.IsWholeFamily,
                    Wedding = recipientData.IsWedding,
                    Gaval = recipientData.IsGaval,
                    Halad = recipientData.IsHalad,
                    Ovalane = recipientData.IsOvalane,
                    Reception = recipientData.IsReception,
                    InvitedById = recipientData.InvitedById,
                    Mehendi = recipientData.IsMehandi,
                    Sangeet = recipientData.IsSangit
                };

                

                _invitationSelection.AddEntity(invitation);

                // After adding the invitation, return the newly created InvitationId
                return invitation.InvitationId;
            }
        }
        public void CreateWhatsaapMessage(RecipientInvitationData whatsappMessage)
        {
            // Create a WhatsApp message for the card if cardId is provided
            if (whatsappMessage.w_cardId > 0)
            {
                var cardMessage = new WhatsappMessage
                {
                    InvitationId = whatsappMessage.invitationId,
                    TemplateStructureId = whatsappMessage.w_cardId,
                    MediaType = whatsappMessage.mediaType
                    // Other properties as needed
                };
                _invitationSelection.AddEntity(cardMessage);
            }

            // Create a WhatsApp message for the video if videoId is provided
            if (whatsappMessage.w_videoId > 0)
            {
                var videoMessage = new WhatsappMessage
                {
                    InvitationId = whatsappMessage.invitationId,
                    TemplateStructureId = whatsappMessage.w_videoId,
                    MediaType = whatsappMessage.mediaType

                    // Other properties as needed
                };
                _invitationSelection.AddEntity(videoMessage);
            }


        }
        public void UpdateEntity<T>(T entity) where T : class
        {
            _invitationSelection.UpdateEntity(entity);
        }
        public void AddEntity<T>(T entity) where T : class
        {
           _invitationSelection.AddEntity(entity);
        }
        public void RemoveEntityById<T>(int id) where T : class
        {
            _invitationSelection.RemoveEntityById<T>(id);
        }
        public void CreateOrUpdateCard(string StringId, int invitationId,int recipientIdInt,string media)
        {

            if(media == "Image")
            {
                if (int.TryParse(StringId, out var cardId))
                {
                    var W_message_card = new RecipientInvitationData
                    {
                        invitationId = invitationId,
                        w_cardId = cardId,
                        mediaType = media
                    };

                    var cardInvId = _invitationSelection.GetInvitation(recipientIdInt, functionId);
                    var existcardmessage = _invitationSelection.GetWhatsappMessage(cardInvId.InvitationId, media);

                    if (existcardmessage != null)
                    {


                        if (existcardmessage.TemplateStructureId != W_message_card.w_cardId)
                        {
                            existcardmessage.TemplateStructureId = W_message_card.w_cardId;
                        }

                        _invitationSelection.UpdateEntity(existcardmessage);
                    }
                    else
                    {
                        CreateWhatsaapMessage(W_message_card);

                    }

                }
            }

            if(media == "Video")
            {
                if (int.TryParse(StringId, out var videoId))
                {
                    var W_message_video = new RecipientInvitationData
                    {
                        invitationId = invitationId,
                        w_videoId = videoId,
                        mediaType = "Video"
                    };


                    var videoInvId = _invitationSelection.GetInvitation(recipientIdInt, functionId);
                    var existcardmessage = _invitationSelection.GetWhatsappMessage(videoInvId.InvitationId, media);

                    if (existcardmessage != null)
                    {
                        if (existcardmessage.TemplateStructureId != W_message_video.w_videoId)
                        {
                            existcardmessage.TemplateStructureId = W_message_video.w_videoId;
                        }
                        // _invitaionSelection.UpdateEntity(existcardmessage);
                        _invitationSelection.UpdateEntity(existcardmessage);
                    }
                    else
                    {
                       CreateWhatsaapMessage(W_message_video);

                    }
                   
                }
            }





           
        }
        public Invitation GetInvitation(int recipientId, int? functionId)
        {
            return _invitationSelection.GetInvitation(recipientId, functionId);
        }


       
    }


}
