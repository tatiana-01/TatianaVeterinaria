using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;
public class MedicamentoProveedorRepository : IMedicamentoProveedor
{
    private readonly Skeleton4CapasContext _context;

    public MedicamentoProveedorRepository(Skeleton4CapasContext context)
    {
        _context = context;
    }

     public virtual void Add(MedicamentoProveedor entity)
        {
            _context.Set<MedicamentoProveedor>().Add(entity);
        }
    
        public virtual void AddRange(IEnumerable<MedicamentoProveedor> entities)
        {
            _context.Set<MedicamentoProveedor>().AddRange(entities);
        }
    
        public virtual IEnumerable<MedicamentoProveedor> Find(Expression<Func<MedicamentoProveedor, bool>> expression)
        {
            return _context.Set<MedicamentoProveedor>().Where(expression);
        }
    
         public virtual async Task<(int totalRegistros, IEnumerable<MedicamentoProveedor> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.MedicamentoProveedores as IQueryable<MedicamentoProveedor>;
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
    
        public virtual async Task<MedicamentoProveedor> GetByIdAsync(int idMedicamento, int idProveedor)
        {
            return await _context.Set<MedicamentoProveedor>().FirstOrDefaultAsync(x=>x.IdProveedor==idProveedor &&  x.IdMedicamento==idMedicamento);
        }
    
        public virtual void Remove(MedicamentoProveedor entity)
        {
            _context.Set<MedicamentoProveedor>().Remove(entity);
        }
    
        public virtual void RemoveRange(IEnumerable<MedicamentoProveedor> entities)
        {
            _context.Set<MedicamentoProveedor>().RemoveRange(entities);
        }
    
        public virtual void Update(MedicamentoProveedor entity)
        {
            _context.Set<MedicamentoProveedor>()
                .Update(entity);
        }
}