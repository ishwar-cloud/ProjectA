using Amantran.Interface;
using Amantran.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Amantran.Services
{
    public class InvitaionSelection : IInvitaionSelection
    {
        private readonly AmantranContext context;

        public InvitaionSelection(AmantranContext context)
        {
            this.context = context;
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

            var states = context.States.ToList();
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

        public List<SelectListItem> GetDistricts(int stateId)
        {
            return context.Districts
                .Where(d => d.StateId == stateId)
                .Select(d => new SelectListItem
                {
                    Text = d.DistrictName,
                    Value = d.DistrictId.ToString()
                })
                .ToList();
        }

        public List<SelectListItem> GetSubDistricts(int districtId)
        {
            return context.SubDistricts
                .Where(sd => sd.DistrictId == districtId)
                .Select(sd => new SelectListItem
                {
                    Text = sd.SubDistrictName,
                    Value = sd.SubDistrictId.ToString()
                })
                .ToList();
        }

        public List<SelectListItem> GetVillages(int subDistrictId)
        {
            return context.Villages
                .Where(v => v.SubDistrictId == subDistrictId)
                .Select(v => new SelectListItem
                {
                    Text = v.VillageName,
                    Value = v.VillageId.ToString()
                })
                .ToList();
        }

        public InvitaionSelectionModel GetRecipients(int villageID)
        {
            var invitedByOptions = context.InvitedBies.Where(f => f.FunctionId == 1).ToList();
            var recipients = context.Recipients.Where(v => v.VillageId == villageID).ToList();

            var defaultInvitedBy = invitedByOptions.FirstOrDefault(i => i.Default);
            var recipentModel = new InvitaionSelectionModel
            {
                Recipients = recipients,
                InvitedByList = invitedByOptions,
                DefaultInvitedBy = defaultInvitedBy,

            };

            return recipentModel;
        }

        public void AddInvitations(IEnumerable<Invitation> invitations)
        {
            context.Invitations.AddRange(invitations);
            context.SaveChanges();
        }

        public InvitaionSelectionModel GetFunction()
        {
            var function = context.Functions
                                        .Where(f => f.FunctionId == 1)
                                        .Select(f => new
                                        {
                                            f.IsWeeding,
                                            f.IsGaval,
                                            f.IsHalad,
                                            f.IsOvalane,
                                            f.IsReception,
                                            f.IsMehandi,
                                            f.IsSangit
                                        }).FirstOrDefault();



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
    }
}
