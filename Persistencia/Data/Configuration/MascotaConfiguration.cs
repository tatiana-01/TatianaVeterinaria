using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
   public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> builder)
        {
            builder.ToTable("Mascota");

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.FechaNacimiento)
            .IsRequired();
            
            builder.HasOne(p => p.Propietario)
            .WithMany(p => p.Mascotas)
            .HasForeignKey(p => p.IdPropietario);

            builder.HasOne(p => p.Especie)
            .WithMany(p => p.Mascotas)
            .HasForeignKey(p => p.IdEspecie);

            builder.HasOne(p => p.Raza)
            .WithMany(p => p.Mascotas)
            .HasForeignKey(p => p.IdRaza);
            
        }
    }
