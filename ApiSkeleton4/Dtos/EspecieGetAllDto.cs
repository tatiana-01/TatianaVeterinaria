using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSkeleton4.Dtos;
    public class EspecieGetAllDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<RazaDto> Razas { get; set; }
        public ICollection<MascotaDto> Mascotas { get; set; }
    }
