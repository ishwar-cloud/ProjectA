using Amantran.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Amantran.Controllers
{
    public class RecipientFormController : Controller
    {
        private readonly AmantranContext _context;

        public RecipientFormController(AmantranContext context)
        {
            _context = context;
        }

        // GET: RecipientForm
        public IActionResult Index()
        {
            ViewBag.Villages = new SelectList(_context.Villages, "VillageId", "VillageName");
            ViewBag.Countries = new SelectList(_context.Countries, "CountryId", "CountryName");
            return View();
        }

        // POST: RecipientForm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Recipient model)
        {
            if (ModelState.IsValid)
            {
                var recipientEntity = new Recipient
                {
                    Age = model.Age,
                    AllMarriedDaughters = model.AllMarriedDaughters,
                    AvailableOnWhatsapp = model.AvailableOnWhatsapp,
                    BloodGroup = model.BloodGroup,
                    BloodRequestReceived = model.BloodRequestReceived,
                    BloodRequestSentCount = model.BloodRequestSentCount,
                    CommunityId = model.CommunityId,
                    VillageId = model.VillageId,
                    DataCollectionId = model.DataCollectionId,
                    FamilyTreeId = model.FamilyTreeId,
                    CompleteFamilyId = model.CompleteFamilyId,
                    CountryCode = model.CountryCode,
                    CurrentLocation = model.CurrentLocation,
                    Dead = model.Dead,
                    Education = model.Education,
                    EducationCategory = model.EducationCategory,
                    Email = model.Email,
                    FatherId = model.FatherId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    ForeignResidence = model.ForeignResidence,
                    Gender = model.Gender,
                    Gotra = model.Gotra,
                    HindiFirstName = model.HindiFirstName,
                    HindiLastName = model.HindiLastName,
                    HindiMiddleName = model.HindiMiddleName,
                    HindiRecipientName = model.HindiRecipientName,
                    HindiSalutation = model.HindiSalutation,
                    KnownAs = model.KnownAs,
                    Kul = model.Kul,
                    MarathiFirstName = model.MarathiFirstName,
                    MarathiLastName = model.MarathiLastName,
                    MarathiMiddleName = model.MarathiMiddleName,
                    MarathiRecipientName = model.MarathiRecipientName,
                    MiddleName = model.MiddleName,
                    MotherId = model.MotherId,
                    Notes = model.Notes,
                    Occupation = model.Occupation,
                    OccupationCategory = model.OccupationCategory,
                    RecipientName = model.RecipientName,
                    RelationshipStatus = model.RelationshipStatus,
                    Salutation = model.Salutation,
                    SpouseId = model.SpouseId,
                    Title = model.Title,
                    WhatsappNumber = model.WhatsappNumber,

                };

                _context.Recipients.Add(recipientEntity);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Recipient details successfully added!";
                return RedirectToAction("Index");
            }

            ViewBag.Villages = new SelectList(_context.Villages, "VillageId", "VillageName");
            ViewBag.Countries = new SelectList(_context.Countries, "CountryId", "CountryName");


            return View(model);
        }
        }
}
