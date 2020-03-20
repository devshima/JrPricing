using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JrPricingApplication;
using JrPricingWebApplication.Models;

namespace JrPricingWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FareApplicationService _fareApplicationService;

        public HomeController(ILogger<HomeController> logger, FareApplicationService fareApplicationService)
        {
            _logger = logger;
            _fareApplicationService = fareApplicationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate(FarePostRequestModel request)
        {
            var command = new FareCalculateCommand(
                request.departure,
                request.destination,
                request.superExpressName,
                request.seatName,
                request.fareName,
                request.tripName,
                request.boardingDate,
                request.numberOfPeopleValue
                );

            var result = _fareApplicationService.calculate(command);
            TempData["result"] = result.amount();
            return RedirectToAction("Result");
        }

        public IActionResult Result()
        {
            return View();
        }

    }
}
