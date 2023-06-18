using Microsoft.EntityFrameworkCore;
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

    }
}
