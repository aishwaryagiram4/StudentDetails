using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentDetails.Models;

namespace StudentDetails.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChangePass()
        {
            return View();
        }
        public IActionResult LoginTable()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginTable(LoginTable user)
        {
            DataAccess dataAccess = new DataAccess();
            bool success = dataAccess.CheckLogin(user);
            if (success)
            {
                return RedirectToAction("Index","Students");
            }
            else
            {
                ViewData["Error"] = "Invalid Details";
                return View();
            }
        }
        public IActionResult RegisterTable()
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
