using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Persistencia;

namespace Aplicacion.Repositories;
public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamento
{
    private readonly Skeleton4CapasContext _context;

    public MedicamentoRepository(Skeleton4CapasContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<(int totalRegistros, IEnumerable<Medicamento> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Medicamentos as IQueryable<Medicamento>;

        if (!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search.ToLower()));
        }
         var totalRegistros=await query.CountAsync();
        var registros = await query
                                .Include(p=>p.TratamientoMedicos)
                                .Include(p=>p.DetalleMovimientos)
                                .Skip((pageIndex-1)*pageSize)
                                .Take(pageSize)
                                .ToListAsync();
                                
        return (totalRegistros,registros);
    }

    public override async Task<Medicamento> GetByIdAsync(int id)
    {
        return await _context.Set<Medicamento>()
        .Include(p=>p.TratamientoMedicos)
        .Include(p=>p.DetalleMovimientos)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}