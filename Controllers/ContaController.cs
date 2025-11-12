using Microsoft.AspNetCore.Mvc;
using CondominioApp.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CondominioApp.Controllers
{
    public class ContaController : Controller
    {
        private static List<ContaMensal> contas = new List<ContaMensal>
        {
            new ContaMensal { Id = 1, Morador = "João", Descricao = "Luz - Novembro", Valor = 180.75M, Mes = "Novembro", Vencimento = DateTime.Today.AddDays(10) },
            new ContaMensal { Id = 2, Morador = "Maria", Descricao = "Água - Novembro", Valor = 95.30M, Mes = "Novembro", Vencimento = DateTime.Today.AddDays(15) },
            new ContaMensal { Id = 3, Morador = "Pedro", Descricao = "Condomínio - Novembro", Valor = 350.00M, Mes = "Novembro", Vencimento = DateTime.Today.AddDays(20) }
        };

        public IActionResult Index()
        {
            return View(contas);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] ContaMensal novaConta)
        {
            if (novaConta == null)
                return Json(new { sucesso = false });

            novaConta.Id = contas.Any() ? contas.Max(c => c.Id) + 1 : 1;
            contas.Add(novaConta);
            return Json(new { sucesso = true });
        }

        [HttpPost]
        public IActionResult MarcarPago(int id)
        {
            var conta = contas.FirstOrDefault(c => c.Id == id);
            if (conta == null) return Json(new { sucesso = false });

            conta.Pago = true;
            return Json(new { sucesso = true });
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            var conta = contas.FirstOrDefault(c => c.Id == id);
            if (conta == null) return Json(new { sucesso = false });

            contas.Remove(conta);
            return Json(new { sucesso = true });
        }

        [HttpPost]
        public IActionResult GerarPix(int id)
        {
            var conta = contas.FirstOrDefault(c => c.Id == id);
            if (conta == null) return NotFound();

            string pixCodigo = "00020126360014BR.GOV.BCB.PIX0114+55549963341285204000053039865802BR5925Laisa Schneider Espindola6009SAO PAULO62140510nwqssMW5146304B033";

            using var qrGenerator = new QRCodeGenerator();
            using var qrData = qrGenerator.CreateQrCode(pixCodigo, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new PngByteQRCode(qrData);
            byte[] qrBytes = qrCode.GetGraphic(20);

            ViewBag.QRCodeBase64 = Convert.ToBase64String(qrBytes);
            ViewBag.ValorPix = conta.Valor.ToString("F2");
            conta.PixCodigo = pixCodigo;

            return View("Pix", conta);
        }
    }
}
