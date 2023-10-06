using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class DetalleMovimiento:BaseEntity
    {
        public Medicamento Medicamento { get; set; }
        public int IdMedicamento { get; set; }
        public int Cantidad  { get; set; }
        public MovimientoMedicamento MovimientoMedicamento { get; set; }
        public int IdMovimientoMedicamento { get; set; }
        public double Precio { get; set; }
    }
