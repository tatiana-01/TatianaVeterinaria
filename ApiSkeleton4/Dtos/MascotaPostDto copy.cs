using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSkeleton4.Dtos;
public class MascotaPostDto
{
    public int IdPropietario { get; set; }
    public int IdEspecie { get; set; }
    public int IdRaza { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }

}
