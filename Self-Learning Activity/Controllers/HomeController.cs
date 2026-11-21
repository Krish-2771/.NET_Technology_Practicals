using Microsoft.AspNetCore.Mvc;

namespace StudentCourseRegistration.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return Content("Something went wrong. Please go back and try again.");
        }
    }
}
