using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class TratamientoMedico:BaseEntity
    {
        public Cita Cita { get; set; }
        public int IdCita { get; set; }
        public Medicamento Medicamento { get; set; }
        public int ? IdMedicamento { get; set; }
        public string Dosis { get; set; }
        public DateTime FechaAdministracion { get; set; }
        public string Observacion { get; set; }
    }
