using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;
public class ConsultaRepository : IConsulta
{
    private readonly Skeleton4CapasContext _context;

    public ConsultaRepository(Skeleton4CapasContext context) 
    {
        _context = context;
    }

    public virtual async Task<(int totalRegistros, IEnumerable<Veterinario> registros)> GetAllCirujanosVasculares(int pageIndex, int pageSize, string search)
    {
        
        var registros = await _context.Veterinarios.Where(p=>p.Especialidad.ToLower().Contains("cirujano vascular"))
            .Include(p=>p.Citas)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        var totalRegistros = registros.Count();
        return (totalRegistros, registros);
    }

    public virtual async Task<(int totalRegistros, IEnumerable<Medicamento> registros)> GetAllMedsGenfar(int pageIndex, int pageSize, string search)
    {
        
        var registros = await _context.Medicamentos.Include(p=>p.Laboratorio).Where(p=>p.Laboratorio.Nombre.ToLower().Contains("genfar"))
            .Include(p=>p.TratamientoMedicos)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        var totalRegistros = registros.Count();
        return (totalRegistros, registros);
    }

    public virtual async Task<(int totalRegistros, IEnumerable<Mascota> registros)> GetAllEspecieFelina(int pageIndex, int pageSize, string search)
    {
        
        var registros = await _context.Mascotas.Include(p=>p.Especie).Where(p=>p.Especie.Nombre.ToLower().Contains("felina"))
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        var totalRegistros = registros.Count();
        return (totalRegistros, registros);
    }

    public virtual async Task<(int totalRegistros, IEnumerable<Medicamento> registros)> GetMore50000(int pageIndex, int pageSize, string search)
    {
        
        var registros = await _context.Medicamentos.Where(p=>p.PrecioVenta>50000)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        var totalRegistros = registros.Count();
        return (totalRegistros, registros);
    }

    public virtual async Task<(int totalRegistros, IEnumerable<Mascota> registros)> GetMascotasVacunaTrimestre(int pageIndex, int pageSize, string search)
    {
        
        var mascotas=_context.Mascotas.Include(p=>p.Citas.Where(p=>p.Fecha.CompareTo(new DateOnly(2023,04,01))<0 && p.Motivo.Contains("vacunacion") )).ThenInclude(p=>p.TratamientoMedicos);
        var registros=await mascotas.Where(p=>p.Citas.Where(p=>p.Fecha.CompareTo(new DateOnly(2023,04,01))<0 && p.Motivo.Contains("vacunacion")).Count()>0)
        //var registros=await mascotas.Where(p=>p.Citas.Count()>0)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        var totalRegistros = registros.Count();
        return (totalRegistros, registros);

    }
}
