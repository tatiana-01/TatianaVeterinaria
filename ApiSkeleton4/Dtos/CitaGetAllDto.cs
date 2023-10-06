using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSkeleton4.Dtos;
    public class CitaGetAllDto
    {
         public int IdMascota { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly Hora { get; set; }
        public string Motivo { get; set; }
        public int IdVeterinario { get; set; }
        public ICollection<TratamientoMedicoDto> TratamientoMedicos { get; set; }
    }
