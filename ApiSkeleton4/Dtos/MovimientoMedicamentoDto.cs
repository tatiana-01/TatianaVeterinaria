using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSkeleton4.Dtos;
    public class MovimientoMedicamentoDto
    {
        public int Id { get; set; }
        public int IdTipoMovimiento { get; set; }
        public DateTime Fecha { get; set; }
    }
