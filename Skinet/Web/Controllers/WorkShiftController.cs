using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class WorkShiftController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
