using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
   public class MovimientoMedicamentoConfiguration : IEntityTypeConfiguration<MovimientoMedicamento>
    {
        public void Configure(EntityTypeBuilder<MovimientoMedicamento> builder)
        {
            builder.ToTable("MovimientoMedicamento");

            builder.Property(p => p.Fecha)
            .IsRequired();
            
            builder.HasOne(p => p.TipoMovimiento)
            .WithMany(p => p.MovimientoMedicamentos)
            .HasForeignKey(p => p.IdTipoMovimiento);
            
        }
    }
