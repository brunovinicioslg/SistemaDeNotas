using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeNotas.Models;

namespace SistemaDeNotas.Data.Map
{
    public class NotaMap : IEntityTypeConfiguration<NotaModel>
    {
        public void Configure(EntityTypeBuilder<NotaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Usuario);
        }

    }
}
