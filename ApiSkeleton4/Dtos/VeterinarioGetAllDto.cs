using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace ApiSkeleton4.Dtos;
    public class VeterinarioGetAllDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Especialidad { get; set; }
        public ICollection<CitaGetAllDto> Citas {get; set;}
    }
