using Microsoft.AspNetCore.Mvc;
using CondominioApp.Context;
using login_e_cadastro.Models;
using System.Linq;

namespace Embelisa.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly CondominioContext _context;

        public RelatoriosController(CondominioContext context)
        {
            _context = context;
        }

        public IActionResult Inadimplencia()
        {
            // Busca todos os clientes inadimplentes do banco
            var clientes = _context.ClientesInadimplentes.ToList();
            return View(clientes);
        }

        [HttpPost]
        public IActionResult AdicionarCliente(ClienteInadimplente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.ClientesInadimplentes.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction("Inadimplencia");
            }

            return View("Inadimplencia", _context.ClientesInadimplentes.ToList());
        }
    }
}
