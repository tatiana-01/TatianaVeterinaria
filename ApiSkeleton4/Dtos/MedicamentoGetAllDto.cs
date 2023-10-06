using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSkeleton4.Dtos;
public class MedicamentoGetAllDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int CantidadDisponible { get; set; }
    public double PrecioVenta { get; set; }
    public int IdLaboratorio { get; set; }
    public ICollection<TratamientoMedicoDto> TratamientoMedicos { get; set; }
    public ICollection<MedicamentoProveedorDto> MedicamentoProveedores { get; set; }
    public ICollection<DetalleMovimientoDto> DetalleMovimientos { get; set; }

}
