using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class EspecieRepository : GenericRepository<Especie>, IEspecie
{
    private readonly Skeleton4CapasContext _context;

    public EspecieRepository(Skeleton4CapasContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<(int totalRegistros, IEnumerable<Especie> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Especies as IQueryable<Especie>;

        if (!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search.ToLower()));
        }
         var totalRegistros=await query.CountAsync();
        var registros = await query
                                .Include(p=>p.Mascotas)
                                .Include(p=>p.Razas)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
                                
        return (totalRegistros,registros);
    }

     public override async Task<Especie> GetByIdAsync(int id)
    {
        return await _context.Set<Especie>()
        .Include(p => p.Mascotas)
        .Include(p=>p.Razas)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}