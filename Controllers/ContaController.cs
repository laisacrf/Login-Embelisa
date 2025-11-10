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
            new ContaMensal { Id = 1, Descricao = "Luz - Novembro", Valor = 180.75M },
            new ContaMensal { Id = 2, Descricao = "Água - Novembro", Valor = 95.30M },
            new ContaMensal { Id = 3, Descricao = "Condomínio - Novembro", Valor = 350.00M }
        };

        public IActionResult Index()
        {
            return View(contas);
        }

        [HttpPost]
        public IActionResult GerarPix(int id)
        {
            var conta = contas.FirstOrDefault(c => c.Id == id);
            if (conta == null) return NotFound();

            string pixCodigo = "00020126360014BR.GOV.BCB.PIX0114+55549963341285204000053039865802BR5925Laisa Schneider Espindola6009SAO PAULO62140510k0RJUvWBBx63047E81";

            using var qrGenerator = new QRCodeGenerator();
            using var qrData = qrGenerator.CreateQrCode(pixCodigo, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new PngByteQRCode(qrData);
            var bytes = qrCode.GetGraphic(20);
            string qrBase64 = Convert.ToBase64String(bytes);

            ViewBag.QRCodeBase64 = qrBase64;
            ViewBag.ValorPix = conta.Valor.ToString("F2");
            conta.PixCodigo = pixCodigo;

            return View("Pix", conta);
        }
    }
}
