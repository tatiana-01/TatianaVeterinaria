using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class LaboratorioRepository : GenericRepository<Laboratorio>, ILaboratorio
{
    private readonly Skeleton4CapasContext _context;

    public LaboratorioRepository(Skeleton4CapasContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<(int totalRegistros, IEnumerable<Laboratorio> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Laboratorios as IQueryable<Laboratorio>;

        if (!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search.ToLower()));
        }
         var totalRegistros=await query.CountAsync();
        var registros = await query
                                .Include(p=>p.Medicamentos)                
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
                                
        return (totalRegistros,registros);
    }

     public override async Task<Laboratorio> GetByIdAsync(int id)
    {
        return await _context.Set<Laboratorio>()
        .Include(p => p.Medicamentos)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}