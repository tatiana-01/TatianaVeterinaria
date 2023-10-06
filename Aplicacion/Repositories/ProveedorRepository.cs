using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Persistencia;

namespace Aplicacion.Repositories;

public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
{
    private readonly Skeleton4CapasContext _context;

    public ProveedorRepository(Skeleton4CapasContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<(int totalRegistros, IEnumerable<Proveedor> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Proveedores as IQueryable<Proveedor>;

        if (!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search.ToLower()));
        }
         var totalRegistros=await query.CountAsync();
        var registros = await query
                                .Include(p=>p.MedicamentoProveedores)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
                                
        return (totalRegistros,registros);
    }

     public override async Task<Proveedor> GetByIdAsync(int id)
    {
        return await _context.Set<Proveedor>()
        .Include(p => p.MedicamentoProveedores)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}