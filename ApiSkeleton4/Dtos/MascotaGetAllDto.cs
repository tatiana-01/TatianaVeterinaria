using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace ApiSkeleton4.Dtos;
public class MascotaGetAllDto
{
    public int Id { get; set; }
    public int IdPropietario { get; set; }
    public int IdEspecie { get; set; }
    public int IdRaza { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public ICollection<CitaDto> Citas { get; set; }
}
