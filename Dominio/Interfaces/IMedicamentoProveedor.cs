using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IMedicamentoProveedor
    {
         Task<MedicamentoProveedor> GetByIdAsync(int idMedicamento, int idProveedor);
        //Task<IEnumerable<MedicamentoProveedor>> GetAllAsync();
        IEnumerable<MedicamentoProveedor> Find(Expression<Func<MedicamentoProveedor, bool>> expression);
        Task<(int totalRegistros, IEnumerable<MedicamentoProveedor> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
        void Add(MedicamentoProveedor entity);
        void AddRange(IEnumerable<MedicamentoProveedor> entities);
        void Remove(MedicamentoProveedor entity);
        void RemoveRange(IEnumerable<MedicamentoProveedor> entities);
        void Update(MedicamentoProveedor entity);
    }
