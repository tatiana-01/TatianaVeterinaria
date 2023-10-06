using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSkeleton4.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace ApiSkeleton4.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Rol, RolDto>().ReverseMap();
        CreateMap<Rol, RolPostDto>().ReverseMap();
        CreateMap<Rol, RolGetAllDto>().ReverseMap();

        CreateMap<Usuario, UsuarioDto>().ReverseMap();
        CreateMap<Usuario, UsuarioGetAllDto>().ReverseMap();

        CreateMap<UsuarioRol, UsuarioRolDto>().ReverseMap();

        CreateMap<Cita, CitaDto>().ReverseMap();
        CreateMap<Cita, CitaPostDto>().ReverseMap();
        CreateMap<Cita, CitaGetAllDto>().ReverseMap();

        CreateMap<DetalleMovimiento, DetalleMovimientoDto>().ReverseMap();
        CreateMap<DetalleMovimiento, DetalleMovimientoPostDto>().ReverseMap();
       
       CreateMap<Especie, EspecieDto>().ReverseMap();
        CreateMap<Especie, EspeciePostDto>().ReverseMap();
        CreateMap<Especie, EspecieGetAllDto>().ReverseMap();
        
        CreateMap<Laboratorio, LaboratorioDto>().ReverseMap();
        CreateMap<Laboratorio, LaboratorioPostDto>().ReverseMap();
        CreateMap<Laboratorio, LaboratorioGetAllDto>().ReverseMap();

        CreateMap<Mascota, MascotaDto>().ReverseMap();
        CreateMap<Mascota, MascotaPostDto>().ReverseMap();
        CreateMap<Mascota, MascotaGetAllDto>().ReverseMap();

        CreateMap<Medicamento, MedicamentoDto>().ReverseMap();
        CreateMap<Medicamento, MedicamentoPostDto>().ReverseMap();
        CreateMap<Medicamento, MedicamentoGetAllDto>().ReverseMap();

        CreateMap<MedicamentoProveedor, MedicamentoProveedorDto>().ReverseMap();
       
       CreateMap<MovimientoMedicamento, MovimientoMedicamentoDto>().ReverseMap();
        CreateMap<MovimientoMedicamento, MovimientoMedicamentoPostDto>().ReverseMap();
        CreateMap<MovimientoMedicamento, MovimientoMedicamentoGetAllDto>().ReverseMap();

        CreateMap<Propietario, PropietarioDto>().ReverseMap();
        CreateMap<Propietario, PropietarioPostDto>().ReverseMap();
        CreateMap<Propietario, PropietarioGetAllDto>().ReverseMap();

        CreateMap<Proveedor, ProveedorDto>().ReverseMap();
        CreateMap<Proveedor, ProveedorPostDto>().ReverseMap();
        CreateMap<Proveedor, ProveedorGetAllDto>().ReverseMap();

        CreateMap<Raza, RazaDto>().ReverseMap();
        CreateMap<Raza, RazaPostDto>().ReverseMap();
        CreateMap<Raza, RazaGetAllDto>().ReverseMap();

        CreateMap<TipoMovimiento, TipoMovimientoDto>().ReverseMap();
        CreateMap<TipoMovimiento, TipoMovimientoPostDto>().ReverseMap();
        CreateMap<TipoMovimiento, TipoMovimientoGetAllDto>().ReverseMap();

        CreateMap<TratamientoMedico, TratamientoMedicoDto>().ReverseMap();
        CreateMap<TratamientoMedico, TratamientoMedicoPostDto>().ReverseMap();
        
        CreateMap<Veterinario, VeterinarioDto>().ReverseMap();
        CreateMap<Veterinario, VeterinarioPostDto>().ReverseMap();
        CreateMap<Veterinario, VeterinarioGetAllDto>().ReverseMap();

    }
}