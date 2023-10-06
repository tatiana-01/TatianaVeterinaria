using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSkeleton4.Dtos;
public class DetalleMovimientoDto
{
    public int Id { get; set; }
    public int IdMedicamento { get; set; }
    public int Cantidad { get; set; }
    public int IdMovimientoMedicamento { get; set; }
    public double Precio { get; set; }
}
