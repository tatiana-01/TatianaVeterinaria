using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
   public class LaboratorioConfiguration : IEntityTypeConfiguration<Laboratorio>
    {
        public void Configure(EntityTypeBuilder<Laboratorio> builder)
        {
            builder.ToTable("Laboratorio");

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.Direccion)
            .IsRequired()
            .HasMaxLength(100);
            
            builder.Property(p => p.Telefono)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
