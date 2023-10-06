using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiSkeleton4.Dtos;
using ApiSkeleton4.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiSkeleton4.Controllers;
[ApiVersion("1.0")] 
[ApiVersion("1.1")] 
public class ConsultasController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ConsultasController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    [HttpGet("cirujanosVasculares")]
    //[Authorize]
    //[MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<VeterinarioGetAllDto>>> GetCirujanos([FromQuery] Params rolParams)
    {
        var veterinarios = await _unitOfWork.Consultas.GetAllCirujanosVasculares(rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
        var lstVeterinariosDto = _mapper.Map<List<VeterinarioGetAllDto>>(veterinarios.registros);
        return new Pager<VeterinarioGetAllDto>(lstVeterinariosDto, veterinarios.totalRegistros, rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
    }

    [HttpGet("medicamentosGenfar")]
    //[Authorize]
    //[MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<MedicamentoGetAllDto>>> GetGenfar([FromQuery] Params rolParams)
    {
        var veterinarios = await _unitOfWork.Consultas.GetAllMedsGenfar(rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
        var lstVeterinariosDto = _mapper.Map<List<MedicamentoGetAllDto>>(veterinarios.registros);
        return new Pager<MedicamentoGetAllDto>(lstVeterinariosDto, veterinarios.totalRegistros, rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
    }

    [HttpGet("propietarioMascotas")]
    //[Authorize]
    //[MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<PropietarioGetAllDto>>> GetPropetarioMascota([FromQuery] Params rolParams)
    {
        var veterinarios = await _unitOfWork.Propietarios.GetAllAsync(rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
        var lstVeterinariosDto = _mapper.Map<List<PropietarioGetAllDto>>(veterinarios.registros);
        return new Pager<PropietarioGetAllDto>(lstVeterinariosDto, veterinarios.totalRegistros, rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
    }

    [HttpGet("especieFelina")]
    //[Authorize]
    //[MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<MascotaDto>>> GetEspecieFelina([FromQuery] Params rolParams)
    {
        var veterinarios = await _unitOfWork.Consultas.GetAllEspecieFelina(rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
        var lstVeterinariosDto = _mapper.Map<List<MascotaDto>>(veterinarios.registros);
        return new Pager<MascotaDto>(lstVeterinariosDto, veterinarios.totalRegistros, rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
    }

    [HttpGet("medsMayor50000")]
    //[Authorize]
    //[MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<MedicamentoDto>>> GetMeds50000([FromQuery] Params rolParams)
    {
        var veterinarios = await _unitOfWork.Consultas.GetMore50000(rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
        var lstVeterinariosDto = _mapper.Map<List<MedicamentoDto>>(veterinarios.registros);
        return new Pager<MedicamentoDto>(lstVeterinariosDto, veterinarios.totalRegistros, rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
    }

    [HttpGet("mascotasVacunaTrimestre")]
    //[Authorize]
    //[MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<MascotaGetAllDto>>> GetMascotaVacunaTrimestres([FromQuery] Params rolParams)
    {
        var veterinarios = await _unitOfWork.Consultas.GetMascotasVacunaTrimestre(rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
        var lstVeterinariosDto = _mapper.Map<List<MascotaGetAllDto>>(veterinarios.registros);
        return new Pager<MascotaGetAllDto>(lstVeterinariosDto, veterinarios.totalRegistros, rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
    }
}