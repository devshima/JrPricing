using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JrPricingWebApplication.Models;
using JrPricingDomain.Service;

namespace JrPricingWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IFareSystemService _fareSystemService;

        public HomeController(ILogger<HomeController> logger, IFareSystemService fareSystemService)
        {
            _logger = logger;
            _fareSystemService = fareSystemService;
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
        public IActionResult Calculate(PricingParameter param)
        {
            var result = _fareSystemService.calculateFare(
                    new JrPricingDomain.Model.Departure(param.departure),
                    new JrPricingDomain.Model.Destination(param.destination),
                    param.superExpressName,
                    param.seatName,
                    param.fareName,
                    param.tripName,
                    param.boardingDate,
                    param.numberOfPeopleValue
                );
            TempData["result"] = result;
            return RedirectToAction("Result");
        }

        public IActionResult Result()
        {
            return View();
        }

    }
}
