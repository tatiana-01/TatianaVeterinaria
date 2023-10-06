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
public class CitaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CitaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<CitaGetAllDto>>> GetAll([FromQuery] Params rolParams)
    {
        var roles = await _unitOfWork.Citas.GetAllAsync(rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
        var lstTipoPersonaDto = _mapper.Map<List<CitaGetAllDto>>(roles.registros);
        return new Pager<CitaGetAllDto>(lstTipoPersonaDto, roles.totalRegistros, rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CitaGetAllDto>> GetById(int id)
    {
        var rol = await _unitOfWork.Citas.GetByIdAsync(id);
        if (rol == null) {
            return NotFound();
        }
        return _mapper.Map<CitaGetAllDto>(rol);
    }

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CitaDto>> Post(CitaPostDto rolDto)
    {
        var rol = _mapper.Map<Cita>(rolDto);
        _unitOfWork.Citas.Add(rol);
        await _unitOfWork.SaveAsync();
        if (rol == null) {
            return BadRequest();
        }
        return _mapper.Map<CitaDto>(rol);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CitaDto>> Put(int id, [FromBody] CitaDto rolDto)
    {
        if (rolDto == null) {
            return NotFound();
        }
        var rol = _mapper.Map<Cita>(rolDto);
        rol.Id = id;
        _unitOfWork.Citas.Update(rol);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<CitaDto>(rol);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CitaDto>> Delete(int id)
    {
        var rol = await _unitOfWork.Citas.GetByIdAsync(id);
        if (rol == null) {
            return NotFound();
        }
        _unitOfWork.Citas.Remove(rol);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}