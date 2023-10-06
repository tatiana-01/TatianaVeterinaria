using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
   public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedor");

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
