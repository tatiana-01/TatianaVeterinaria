using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class RazaRepository : GenericRepository<Raza>, IRaza
{
    private readonly Skeleton4CapasContext _context;

    public RazaRepository(Skeleton4CapasContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<(int totalRegistros, IEnumerable<Raza> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Razas as IQueryable<Raza>;

        if (!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search.ToLower()));
        }
         var totalRegistros=await query.CountAsync();
        var registros = await query
                                .Include(p=>p.Mascotas)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
                                
        return (totalRegistros,registros);
    }

     public override async Task<Raza> GetByIdAsync(int id)
    {
        return await _context.Set<Raza>()
        .Include(p => p.Mascotas)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}