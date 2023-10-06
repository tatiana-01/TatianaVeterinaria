using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class Raza:BaseEntity
    {
        public string Nombre { get; set; }
        public Especie Especie { get; set; }
        public int IdEspecie { get; set; }
        public ICollection<Mascota> Mascotas { get; set; }
    }
