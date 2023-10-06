using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class CitaConfiguration : IEntityTypeConfiguration<Cita>
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            builder.ToTable("Cita");

            builder.Property(p => p.Motivo)
            .IsRequired()
            .HasMaxLength(300);

            builder.Property(p => p.Fecha)
            .IsRequired();
            
            builder.HasOne(p => p.Mascota)
            .WithMany(p => p.Citas)
            .HasForeignKey(p => p.IdMascota);

            builder.HasOne(p => p.Veterinario)
            .WithMany(p => p.Citas)
            .HasForeignKey(p => p.IdVeterinario);
        }
    }
