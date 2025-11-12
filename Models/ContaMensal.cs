namespace CondominioApp.Models
{
    public class ContaMensal
    {
        public int Id { get; set; }
        public string Morador { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Mes { get; set; }
        public DateTime Vencimento { get; set; }
        public string PixId { get; set; }
        public string PixCodigo { get; set; }
        public bool Pago { get; set; } = false;
    }
}
