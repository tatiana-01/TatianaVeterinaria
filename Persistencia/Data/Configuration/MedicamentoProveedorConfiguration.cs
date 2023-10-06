using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
   public class MedicamentoProveedorConfiguration : IEntityTypeConfiguration<MedicamentoProveedor>
    {
        public void Configure(EntityTypeBuilder<MedicamentoProveedor> builder)
        {
            builder.ToTable("MedicamentoProveedor");

            builder.HasOne(p => p.Medicamento)
            .WithMany(p => p.MedicamentoProveedores)
            .HasForeignKey(p => p.IdMedicamento);

            builder.HasOne(p => p.Proveedor)
            .WithMany(p => p.MedicamentoProveedores)
            .HasForeignKey(p => p.IdProveedor);

            builder.HasKey(p => new { p.IdMedicamento, p.IdProveedor });
            
        }
    }
