using Microsoft.EntityFrameworkCore;
using SistemaDeNotas.Data.Map;
using SistemaDeNotas.Models;

namespace SistemaDeNotas.Data
{
    public class BancoContext : DbContext

    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
            
        }

        public DbSet<NotaModel> Notas { get; set; }
        public DbSet<UsuarioModel>  Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NotaMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
