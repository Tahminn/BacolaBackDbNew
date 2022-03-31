using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BacolaBackDb.Controllers
{
    public class MyAccountController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "My Account";
            ViewBag.Javascript = "my-account";
            return View();
        }
    }
}
