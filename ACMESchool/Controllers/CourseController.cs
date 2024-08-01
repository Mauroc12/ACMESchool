using Microsoft.AspNetCore.Mvc;

namespace ACMESchool.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
