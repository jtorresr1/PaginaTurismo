using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos.Config
{
    public class LugarConfiguration : IEntityTypeConfiguration<Lugar>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Lugar> builder)
        {
            builder.Property(l => l.Id).IsRequired();
            builder.Property(l => l.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(l => l.Descripcion).IsRequired();
            builder.Property(l => l.GastoAproximado).IsRequired();


            // RelationShips

            builder.HasOne(c => c.Categoria).WithMany()
                   .HasForeignKey(l => l.CategoriaId);

            builder.HasOne(p => p.Pais).WithMany()
                   .HasForeignKey(l => l.PaisId);
        }
    }
}