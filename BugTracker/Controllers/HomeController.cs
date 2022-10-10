using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BugTracker.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace BugTracker.Controllers
{
    public class HomeController : Controller
    {

        private IConfiguration _configuration;

        public HomeController(IConfiguration _config)
        {
            _configuration = _config;
        }
                   
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind] Ad_login ad)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            db dbop = new db(_configuration.GetConnectionString("BugTrackerContext"));
            int res = dbop.LoginCheck(ad);
            if (res == 1)
            {
                //TempData["msg"] = "You are welcome to Admin Section";
            }
            else
            {
                TempData["msg"] = "Admin id or Password is wrong.!";
                return View();
            }
            //return View();

            ViewBag.UserID = ad.Admin_id;
            TempData["UserID"] = ad.Admin_id;

            return RedirectToAction("Index", "bugtrackers");
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
