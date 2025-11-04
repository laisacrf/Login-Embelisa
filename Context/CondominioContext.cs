using Microsoft.EntityFrameworkCore;
using CondominioApp.Models;
using System;
using System.Collections.Generic;
using login_e_cadastro.Models;

namespace CondominioApp.Context
{
    public class CondominioContext : DbContext
    {
        public CondominioContext(DbContextOptions<CondominioContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Morador> Moradores { get; set; }

    }
}
