namespace CondominioApp.Models
{
    public class ContaMensal
    {
        public int Id { get; set; }

        // 🔹 Descrição da conta (ex: "Luz", "Água", etc.)
        public string Descricao { get; set; }

        // 🔹 Valor da conta
        public decimal Valor { get; set; }

        // 🔹 Data de vencimento da conta
        public DateTime DataVencimento { get; set; }

        // 🔹 Identificação e código do PIX
        public string PixId { get; set; }
        public string PixCodigo { get; set; }

        // 🔹 Status de pagamento
        public bool Pago { get; set; } = false;
    }
}
