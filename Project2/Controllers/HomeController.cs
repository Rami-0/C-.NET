using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using System.Diagnostics;

namespace Project2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}