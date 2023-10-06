using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class Medicamento:BaseEntity
    {
        public string Nombre { get; set; }
        public int CantidadDisponible { get; set; }
        public double PrecioVenta { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public int IdLaboratorio { get; set; }
        public ICollection<TratamientoMedico> TratamientoMedicos { get; set; }
        public ICollection<MedicamentoProveedor> MedicamentoProveedores { get; set; }
        public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }
    }
