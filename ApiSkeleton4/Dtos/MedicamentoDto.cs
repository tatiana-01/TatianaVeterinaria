using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSkeleton4.Dtos;
public class MedicamentoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int CantidadDisponible { get; set; }
    public double PrecioVenta { get; set; }
    public int IdLaboratorio { get; set; }

}
