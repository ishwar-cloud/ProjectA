using Amantran.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Amantran.Controllers
{
    public class InvitedByController : Controller
    {
        private readonly AmantranContext _context;
        private readonly ILogger<InvitedByController> _logger;

        public InvitedByController(AmantranContext context, ILogger<InvitedByController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvitedBy model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var invitedByEntity = new InvitedBy
                    {
                        InvitedByName = model.InvitedByName,
                        Relation = model.Relation,
                        //FunctionId = model.FunctionId,  // Ensure FunctionId is included
                        Default = model.Default
                    };

                    _context.Add(invitedByEntity);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Invited By details successfully added!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while saving InvitedBy details.");
                    ModelState.AddModelError("", "An error occurred while saving the details. Please try again.");
                }
            }

            return View(model);
        }

        public IActionResult Index()
        {
            return View(new InvitedBy());
        }
    }
}
