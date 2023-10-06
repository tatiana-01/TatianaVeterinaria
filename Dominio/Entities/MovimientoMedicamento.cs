using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class MovimientoMedicamento:BaseEntity   
    {
        public TipoMovimiento TipoMovimiento { get; set; }
        public int IdTipoMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }
    }
