using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
   public class DetalleMovimientoConfiguration : IEntityTypeConfiguration<DetalleMovimiento>
    {
        public void Configure(EntityTypeBuilder<DetalleMovimiento> builder)
        {
            builder.ToTable("DetalleMovimiento");

            builder.Property(p => p.Cantidad)
            .IsRequired();

            builder.Property(p => p.Precio)
            .IsRequired();
            
           builder.HasOne(p => p.Medicamento)
           .WithMany(p => p.DetalleMovimientos)
           .HasForeignKey(p => p.IdMedicamento);
           
           builder.HasOne(p => p.MovimientoMedicamento)
           .WithMany(p => p.DetalleMovimientos)
           .HasForeignKey(p => p.IdMovimientoMedicamento);
        }
    }

