using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
   public class VeterinarioConfiguration : IEntityTypeConfiguration<Veterinario>
    {
        public void Configure(EntityTypeBuilder<Veterinario> builder)
        {
            builder.ToTable("Veterinario");

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(50);
            
            builder.Property(p => p.CorreoElectronico)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(p => p.Telefono)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.Especialidad)
            .IsRequired()
            .HasMaxLength(100);

        }
    }
