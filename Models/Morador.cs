using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using login_e_cadastro.Models;
using CondominioApp.Models;

namespace CondominioApp.Models
{
    public class Morador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string NumeroApartamento { get; set; }
        public string Telefone { get; set; }
    }
    }
