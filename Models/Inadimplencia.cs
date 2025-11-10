using System;
using System.ComponentModel.DataAnnotations;

namespace login_e_cadastro.Models
{
    public class ClienteInadimplente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome do Cliente")]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Vencimento")]
        public DateTime Vencimento { get; set; }

        [Required]
        [Display(Name = "Valor (R$)")]
        [Range(0, double.MaxValue)]
        public decimal Valor { get; set; }

        [Required]
        [Display(Name = "Dias em Atraso")]
        [Range(0, int.MaxValue)]
        public int Atraso { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}
