using Lec2021.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lec2021.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestDbConxextcs _TestDbConxextcs;

        public HomeController(ILogger<HomeController> logger, TestDbConxextcs TestDbConxextcs)
        {
            _logger = logger;
            _TestDbConxextcs = TestDbConxextcs;
        }

        public IActionResult Index()
        {
            ViewData.Model =  _TestDbConxextcs.TestsModels.OrderBy(item => item.Id).ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
