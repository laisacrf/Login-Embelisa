using Microsoft.AspNetCore.Mvc;
using CondominioApp.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace CondominioApp.Controllers
{
    public class AccountController : Controller
    {
        // "Banco" de usuários em memória
        private static List<Usuario> usuarios = new List<Usuario>();

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuario != null)
            {
                // Guarda o usuário logado na sessão
                HttpContext.Session.SetString("UsuarioEmail", usuario.Email);

                // Redireciona para a página de financeiro
                return RedirectToAction("Index", "Conta");
            }

            ViewBag.Erro = "E-mail ou senha inválidos.";
            return View();
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Email) || string.IsNullOrWhiteSpace(usuario.Senha))
            {
                ViewBag.Mensagem = "Preencha todos os campos.";
                return View();
            }

            if (usuarios.Any(u => u.Email == usuario.Email))
            {
                ViewBag.Mensagem = "Este e-mail já está cadastrado.";
                return View();
            }

            usuarios.Add(usuario);
            TempData["Mensagem"] = "Cadastro realizado com sucesso!";
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
