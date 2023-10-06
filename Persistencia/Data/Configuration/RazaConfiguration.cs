using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
   public class RazaConfiguration : IEntityTypeConfiguration<Raza>
    {
        public void Configure(EntityTypeBuilder<Raza> builder)
        {
            builder.ToTable("Raza");
            
            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(p => p.Especie)
            .WithMany(p => p.Razas)
            .HasForeignKey(p => p.IdEspecie);

        }
    }
