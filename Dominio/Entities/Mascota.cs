using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class Mascota:BaseEntity
    {
        public Propietario Propietario { get; set; }  
        public int IdPropietario { get; set; }
        public Especie Especie { get; set; }
        public int IdEspecie { get; set; }
        public Raza Raza { get; set; }
        public int IdRaza { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public ICollection<Cita> Citas { get; set; }
    }
