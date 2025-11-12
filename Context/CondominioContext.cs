using Microsoft.EntityFrameworkCore;
using login_e_cadastro.Models; // ajusta se necessário
using CondominioApp.Models; // já tem isso

namespace CondominioApp.Context
{
    public class CondominioContext : DbContext
    {
        public CondominioContext(DbContextOptions<CondominioContext> options) : base(options) { }

        public DbSet<ContaMensal> ContasMensais { get; set; }
        public DbSet<ClienteInadimplente> ClientesInadimplentes { get; set; } // <-- adiciona aqui
    }
}
