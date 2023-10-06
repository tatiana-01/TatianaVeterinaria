using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSkeleton4.Dtos;
public class RazaGetAllDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int IdEspecie { get; set; }
    public ICollection<MascotaGetAllDto> Mascotas { get; set; }
}
