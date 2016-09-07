using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yaus.Controllers.api;

namespace yaus.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            this.ViewData["CreateUrl"] = this.Url.Link("apiUrl", null);
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
