using Microsoft.EntityFrameworkCore;
using CondominioApp.Models;

namespace CondominioApp.Context
{
    public class CondominioContext : DbContext
    {
        public CondominioContext(DbContextOptions<CondominioContext> options) : base(options) { }

        public DbSet<ContaMensal> ContasMensais { get; set; }
    }
}
