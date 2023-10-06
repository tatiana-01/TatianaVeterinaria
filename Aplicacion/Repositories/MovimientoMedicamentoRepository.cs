using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class MovimientoMedicamentoRepository : GenericRepository<MovimientoMedicamento>, IMovimientoMedicamento
{
    private readonly Skeleton4CapasContext _context;

    public MovimientoMedicamentoRepository(Skeleton4CapasContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<(int totalRegistros, IEnumerable<MovimientoMedicamento> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
      
         var totalRegistros = await _context.Set<MovimientoMedicamento>().CountAsync();
        var registros = await _context.Set<MovimientoMedicamento>()
            .Include(p=>p.DetalleMovimientos)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

     public override async Task<MovimientoMedicamento> GetByIdAsync(int id)
    {
        return await _context.Set<MovimientoMedicamento>()
        .Include(p => p.DetalleMovimientos)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}