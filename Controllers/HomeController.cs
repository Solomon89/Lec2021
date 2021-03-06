﻿using Lec2021.Models;
using Lec2021.Services;
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
        private readonly IMessageSender _MessageSender;

        public HomeController(ILogger<HomeController> logger, TestDbConxextcs TestDbConxextcs, IMessageSender MessageSender)
        {
            _logger = logger;
            _TestDbConxextcs = TestDbConxextcs;
            _MessageSender = MessageSender;
        }

        public IActionResult Index()
        {
            ViewData.Model =  _TestDbConxextcs.TestsModels.OrderBy(item => item.Id).ToList();
            ViewBag.Message = _MessageSender.Send("Привет мир");
            return View();
        }
        public IActionResult GetTest(int id)
        {
            ViewData.Model = _TestDbConxextcs.TestsModels.FirstOrDefault(i=>i.Id ==id);
            return View();
        }
        [HttpGet]
        public IActionResult EditTest(int id)
        {
            ViewData.Model = _TestDbConxextcs.TestsModels.FirstOrDefault(i => i.Id == id);
            return View();
        }
        [HttpPost]
        public IActionResult EditTest(TestsModel TestsModel)
        {
            var fromDB =  _TestDbConxextcs.TestsModels.Find(TestsModel.Id);
            fromDB.isActive = TestsModel.isActive;
            fromDB.Name = TestsModel.Name;
            fromDB.Description = TestsModel.Description;
            fromDB.Created = TestsModel.Created;
            fromDB.Owner = TestsModel.Owner;
            fromDB.Updated = TestsModel.Updated;
            _TestDbConxextcs.SaveChanges();
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
