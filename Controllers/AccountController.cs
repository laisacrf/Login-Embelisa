using Microsoft.AspNetCore.Mvc;
using CondominioApp.Context;
using CondominioApp.Models;

namespace CondominioApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly CondominioContext _context;

        public AccountController(CondominioContext context)
        {
            _context = context;
        }

        // =========================
        // CADASTRO DE ADMIN (USUARIO)
        // =========================
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                TempData["Mensagem"] = "Cadastro de administrador realizado com sucesso!";
                return RedirectToAction("Login");
            }
            return View(usuario);
        }

        // =========================
        // LOGIN
        // =========================
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            // Tenta login como ADMIN (Usuario)
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
            if (usuario != null)
                return RedirectToAction("PainelAdm");

            // Tenta login como MORADOR
            var morador = _context.Moradores.FirstOrDefault(m => m.Email == email && m.Senha == senha);
            if (morador != null)
                return RedirectToAction("PainelUsuario");

            ViewBag.Erro = "Email ou senha inválidos.";
            return View();
        }

        // =========================
        // PAINÉIS
        // =========================
        public IActionResult PainelAdm()
        {
            return Content("Painel do Administrador: Aqui você pode gerenciar o condomínio.");
        }

        public IActionResult PainelUsuario()
        {
            return Content("Painel do Morador: Aqui você vê boletos e avisos.");
        }

        // =========================
        // CADASTRO DE MORADOR
        // =========================
        public IActionResult RegisterMorador() => View();

        [HttpPost]
        public IActionResult RegisterMorador(Morador morador)
        {
            if (ModelState.IsValid)
            {
                _context.Moradores.Add(morador);
                _context.SaveChanges();
                TempData["Mensagem"] = "Cadastro de morador realizado com sucesso!";
                return RedirectToAction("Login");
            }

            return View(morador);
        }
    }
}
