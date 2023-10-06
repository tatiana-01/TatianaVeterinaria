using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class TipoMovimientoRepository : GenericRepository<TipoMovimiento>, ITipoMovimiento
{
    private readonly Skeleton4CapasContext _context;

    public TipoMovimientoRepository(Skeleton4CapasContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<(int totalRegistros, IEnumerable<TipoMovimiento> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.TipoMovimientos as IQueryable<TipoMovimiento>;

        if (!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Descripcion.ToLower().Contains(search.ToLower()));
        }
         var totalRegistros=await query.CountAsync();
        var registros = await query
                                .Include(p=>p.MovimientoMedicamentos).ThenInclude(p=>p.DetalleMovimientos)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
                                
        return (totalRegistros,registros);
    }

     public override async Task<TipoMovimiento> GetByIdAsync(int id)
    {
        return await _context.Set<TipoMovimiento>()
        .Include(p => p.MovimientoMedicamentos).ThenInclude(p=>p.DetalleMovimientos)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}