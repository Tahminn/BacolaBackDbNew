using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BacolaBackDb.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {            
            ViewBag.Title = "About";
            ViewBag.Javascript = "about";            
            return View();
        }
    }
}
