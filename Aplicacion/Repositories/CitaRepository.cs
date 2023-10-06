using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class CitaRepository : GenericRepository<Cita>, ICita
{
    private readonly Skeleton4CapasContext _context;

    public CitaRepository(Skeleton4CapasContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<(int totalRegistros, IEnumerable<Cita> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
      
         var totalRegistros = await _context.Set<Cita>().CountAsync();
        var registros = await _context.Set<Cita>()
            .Include(p=>p.TratamientoMedicos)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

     public override async Task<Cita> GetByIdAsync(int id)
    {
        return await _context.Set<Cita>()
        .Include(p => p.TratamientoMedicos)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}