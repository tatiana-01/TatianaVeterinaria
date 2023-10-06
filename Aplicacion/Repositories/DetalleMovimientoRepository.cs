using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class DetalleMovimientoRepository : GenericRepository<DetalleMovimiento>, IDetalleMovimiento
{
    private readonly Skeleton4CapasContext _context;

    public DetalleMovimientoRepository(Skeleton4CapasContext context) : base(context)
    {
        _context = context;
    }

}