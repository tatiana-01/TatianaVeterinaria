using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;
public class MascotaRepository : GenericRepository<Mascota>, IMascota
{
    private readonly Skeleton4CapasContext _context;

    public MascotaRepository(Skeleton4CapasContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<(int totalRegistros, IEnumerable<Mascota> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Mascotas as IQueryable<Mascota>;

        if (!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search.ToLower()));
        }
         var totalRegistros=await query.CountAsync();
        var registros = await query
                                .Include(p=>p.Citas)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
                                
        return (totalRegistros,registros);
    }

    public override async Task<Mascota> GetByIdAsync(int id)
    {
        return await _context.Set<Mascota>()
        .Include(p => p.Citas)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}