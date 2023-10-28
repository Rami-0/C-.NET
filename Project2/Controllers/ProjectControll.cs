using Microsoft.AspNetCore.Mvc;

namespace Project2.Controllers
{
    public class ProjectControll : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
