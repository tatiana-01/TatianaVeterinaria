using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSkeleton4.Dtos;
    public class TipoMovimientoGetAllDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public ICollection<MovimientoMedicamentoDto> MovimientoMedicamentos { get; set; }
    }
