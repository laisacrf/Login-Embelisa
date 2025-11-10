using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace CondominioApp.Services
{
    public class PixService
    {
        private readonly PixConfiguracoes _config;
        private readonly HttpClient _client;

        public PixService(IOptions<PixConfiguracoes> config)
        {
            _config = config.Value;

            var handler = new HttpClientHandler();
            var cert = new X509Certificate2(_config.CaminhoCertificado, _config.SenhaCertificado);
            handler.ClientCertificates.Add(cert);

            _client = new HttpClient(handler)
            {
                BaseAddress = new Uri(_config.UrlBase)
            };
        }

        /// <summary>
        /// Cria uma cobrança Pix no BB
        /// </summary>
        public async Task<string> CriarCobrancaAsync(decimal valor, string txId, string infoAdicional)
        {
            var payload = new
            {
                calendario = new { expiracao = 3600 }, // 1 hora
                devedor = new { cpf = "00000000000", nome = "Cliente Teste" },
                valor = new { original = valor.ToString("F2") },
                chave = "SEU_PIX_AQUI",
                solicitacaoPagador = infoAdicional
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Exemplo: endpoint de criação de cobrança (BB sandbox ou produção varia)
            var response = await _client.PostAsync($"/pix/cob/{txId}", content);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Retorna o QR Code Pix a partir de um txId
        /// </summary>
        public async Task<string> ObterQrCodeAsync(string txId)
        {
            var response = await _client.GetAsync($"/pix/cob/{txId}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            var qrCode = doc.RootElement.GetProperty("loc").GetProperty("id").GetString(); // depende da resposta do BB
            return qrCode;
        }
    }
}
