using Microsoft.AspNetCore.Mvc;

namespace SeuApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View(); // importante: sem nome de layout aqui
        }
    }
}
