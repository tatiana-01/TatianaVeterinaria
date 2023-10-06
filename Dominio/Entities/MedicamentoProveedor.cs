using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class MedicamentoProveedor
    {
        public Medicamento Medicamento { get; set; }
        public int IdMedicamento { get; set; }
        public Proveedor Proveedor { get; set; }
        public int IdProveedor { get; set; }
    }
