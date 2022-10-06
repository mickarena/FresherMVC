using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ShiftController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
