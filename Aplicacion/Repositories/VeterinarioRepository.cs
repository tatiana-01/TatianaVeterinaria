using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class VeterinarioRepository : GenericRepository<Veterinario>, IVeterinario
{
    private readonly Skeleton4CapasContext _context;

    public VeterinarioRepository(Skeleton4CapasContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<(int totalRegistros, IEnumerable<Veterinario> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Veterinarios as IQueryable<Veterinario>;

        if (!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search.ToLower()));
        }
         var totalRegistros=await query.CountAsync();
        var registros = await query
                                .Include(p=>p.Citas).ThenInclude(p=>p.TratamientoMedicos)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
                                
        return (totalRegistros,registros);
    }

     public override async Task<Veterinario> GetByIdAsync(int id)
    {
        return await _context.Set<Veterinario>()
        .Include(p => p.Citas)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}