using Microsoft.AspNetCore.Mvc;

namespace Embelisa.Controllers
{
    public class RelatoriosController : Controller
    {
        public IActionResult Inadimplencia()
        {
            return View();
        }
    }
}
