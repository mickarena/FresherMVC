using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
