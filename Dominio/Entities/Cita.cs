using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class Cita:BaseEntity
    {
        public int IdMascota { get; set; }  
        public Mascota Mascota { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly Hora { get; set; }
        public string Motivo { get; set; }
        public Veterinario Veterinario { get; set; }
        public int IdVeterinario { get; set; } 
        public ICollection<TratamientoMedico> TratamientoMedicos { get; set; }
    }
