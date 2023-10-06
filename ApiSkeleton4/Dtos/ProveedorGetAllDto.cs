using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSkeleton4.Dtos;
    public class ProveedorGetAllDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public ICollection<MedicamentoProveedorDto> MedicamentoProveedores { get; set; }
    }
