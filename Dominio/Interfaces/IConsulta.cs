using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IConsulta
    {
        Task<(int totalRegistros, IEnumerable<Veterinario> registros)> GetAllCirujanosVasculares(int pageIndex, int pageSize, string search);
        Task<(int totalRegistros, IEnumerable<Medicamento> registros)> GetAllMedsGenfar(int pageIndex, int pageSize, string search);
        Task<(int totalRegistros, IEnumerable<Mascota> registros)> GetAllEspecieFelina(int pageIndex, int pageSize, string search);
        Task<(int totalRegistros, IEnumerable<Medicamento> registros)> GetMore50000(int pageIndex, int pageSize, string search);
        Task<(int totalRegistros, IEnumerable<Mascota> registros)> GetMascotasVacunaTrimestre(int pageIndex, int pageSize, string search);
    
    }
