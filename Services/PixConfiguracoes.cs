namespace CondominioApp.Services
{
    public class PixConfiguracoes
    {
        public string UrlBase { get; set; }             // URL da API do BB
        public string CaminhoCertificado { get; set; }  // Local do arquivo .pfx
        public string SenhaCertificado { get; set; }    // Senha do certificado
    }
}
