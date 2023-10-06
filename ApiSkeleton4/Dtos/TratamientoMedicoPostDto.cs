using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSkeleton4.Dtos;
public class TratamientoMedicoPostDto
{
    public int IdCita { get; set; }
    public int IdMedicamento { get; set; }
    public string Dosis { get; set; }
    public DateTime FechaAdministracion { get; set; }
    public string Observacion { get; set; }
}
