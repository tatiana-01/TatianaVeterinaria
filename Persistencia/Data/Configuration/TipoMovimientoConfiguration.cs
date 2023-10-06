using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
   public class TipoMovimientoConfiguration : IEntityTypeConfiguration<TipoMovimiento>
    {
        public void Configure(EntityTypeBuilder<TipoMovimiento> builder)
        {
            builder.ToTable("TipoMovimiento");

            builder.Property(p => p.Descripcion)
            .IsRequired()
            .HasMaxLength(200);

        }
    }
