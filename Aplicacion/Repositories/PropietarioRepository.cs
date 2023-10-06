using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class PropietarioRepository : GenericRepository<Propietario>, IPropietario
{
    private readonly Skeleton4CapasContext _context;

    public PropietarioRepository(Skeleton4CapasContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<(int totalRegistros, IEnumerable<Propietario> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Propietarios as IQueryable<Propietario>;

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

     public override async Task<Propietario> GetByIdAsync(int id)
    {
        return await _context.Set<Propietario>()
        .Include(p => p.Mascotas)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}