using Microsoft.AspNetCore.Mvc;
using CondominioApp.Models;

namespace CondominioApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string tipo)
        {
            ViewBag.Tipo = tipo; // mostra se é admin ou morador
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha, string tipo)
        {
            // ADMIN
            if (tipo == "morador" && email == "admin@condominio.com" && senha == "1234")
            {
                return RedirectToAction("Index", "Conta");
            }

            // MORADOR
            if (tipo == "visitante" && email == "morador@condominio.com" && senha == "1234")
            {
                return RedirectToAction("Index", "Conta");
            }

            ViewBag.Erro = "Email ou senha inválidos.";
            ViewBag.Tipo = tipo;
            return View();
        }

        public IActionResult Register(string tipo)
        {
            ViewBag.Tipo = tipo;
            return View();
        }

        [HttpPost]
        public IActionResult Register(Usuario usuario, string tipo)
        {
            TempData["Mensagem"] = "Cadastro simulado com sucesso.";
            return RedirectToAction("Login", new { tipo = tipo });
        }
    }
}
