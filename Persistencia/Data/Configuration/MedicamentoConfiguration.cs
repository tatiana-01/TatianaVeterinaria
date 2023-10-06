using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
   public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
    {
        public void Configure(EntityTypeBuilder<Medicamento> builder)
        {
            builder.ToTable("Medicamento");

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(p => p.CantidadDisponible)
            .IsRequired();

            builder.Property(p => p.PrecioVenta)
            .IsRequired();

            builder.HasOne(p => p.Laboratorio)
            .WithMany(p => p.Medicamentos)
            .HasForeignKey(p => p.IdLaboratorio);
        }
    }
