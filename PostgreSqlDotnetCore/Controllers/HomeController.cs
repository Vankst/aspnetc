using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PostgreSqlDotnetCore.Models;
using PostgreSqlDotnetCore.Views;

namespace PostgreSqlDotnetCore.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AddApplication()
        {
            return View();
        }
        public IActionResult ListApplication()
        {
            return View();
        }

        public IActionResult Stats()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult AddApplication(string name, string email)
        {
            Random rnd = new Random();
             string ucode = String.Empty;
            int r;
            char[] ch4r = "abcdefghijklmnopqrstuvwxyzABCDEFGHUJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()!№;:?_-=+".ToCharArray();
            for (int i = 0; i < 64; i++)
            {
                r = rnd.Next(ch4r.Length);
                ucode += ch4r[r];
            }
            DB dB = new DB();
            dB.addApp(name, ucode, email);
            return View(dB);
        }
    }
}
