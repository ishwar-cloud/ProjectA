using Amantran.BuscinessServices.Implimentation;
using Amantran.Models;
using Dapper;
using Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amantran.Controllers
{
    public class MessageController : Controller
    {
        private readonly IFacebookApiService _facebookApiService;
        private readonly AmantranContext _context;

        public MessageController(IFacebookApiService facebookApiService, AmantranContext context)
        {
            _facebookApiService = facebookApiService;
            _context = context;
        }

        public IActionResult Index(string message = null)
        {
            ViewData["Message"] = message;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage()
        {
            var results = new List<SendMessageModel>();
            if (ModelState.IsValid)
            {
                
                try
                {
                    // Call the stored procedure
                     results = (await _context.Database
                        .GetDbConnection()
                        .QueryAsync<SendMessageModel>(
                            "SP_Invitation",
                            commandType: System.Data.CommandType.StoredProcedure)).ToList();

                    // Check if data was returned
                    if (results.Any())
                    {
                        await _facebookApiService.SendMessageAsync(results);
                        TempData["Message"] = "Message sent successfully";
                    }
                    else
                    {
                        TempData["Message"] = "No data returned from the stored procedure.";
                    }
                }
                catch (Exception ex)
                {
                    TempData["Message"] = $"Error: {ex.Message}";
                }

                return RedirectToAction("Index");
            }

            ViewBag.Results = results;
            return View("Index", results);
        }
    }
}

