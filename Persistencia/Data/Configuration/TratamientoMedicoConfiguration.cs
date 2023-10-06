using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
   public class TratamientoMedicoConfiguration : IEntityTypeConfiguration<TratamientoMedico>
    {
        public void Configure(EntityTypeBuilder<TratamientoMedico> builder)
        {
            builder.ToTable("TratamientoMedico");

            builder.Property(p => p.Dosis)
            .IsRequired()
            .HasMaxLength(200);

            builder.Property(p => p.Observacion)
            .IsRequired()
            .HasMaxLength(200);

            builder.Property(p => p.FechaAdministracion)
            .IsRequired();

            builder.HasOne(p => p.Cita)
            .WithMany(p => p.TratamientoMedicos)
            .HasForeignKey(p => p.IdCita);

            builder.HasOne(p => p.Medicamento)
            .WithMany(p => p.TratamientoMedicos)
            .HasForeignKey(p => p.IdMedicamento);

        }
    }
