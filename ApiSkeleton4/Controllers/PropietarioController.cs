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
public class PropietarioController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PropietarioController(IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<Pager<PropietarioGetAllDto>>> GetAll([FromQuery] Params rolParams)
    {
        var roles = await _unitOfWork.Propietarios.GetAllAsync(rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
        var lstTipoPersonaDto = _mapper.Map<List<PropietarioGetAllDto>>(roles.registros);
        return new Pager<PropietarioGetAllDto>(lstTipoPersonaDto, roles.totalRegistros, rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PropietarioGetAllDto>> GetById(int id)
    {
        var rol = await _unitOfWork.Propietarios.GetByIdAsync(id);
        if (rol == null) {
            return NotFound();
        }
        return _mapper.Map<PropietarioGetAllDto>(rol);
    }

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PropietarioDto>> Post(PropietarioPostDto rolDto)
    {
        var rol = _mapper.Map<Propietario>(rolDto);
        _unitOfWork.Propietarios.Add(rol);
        await _unitOfWork.SaveAsync();
        if (rol == null) {
            return BadRequest();
        }
        return _mapper.Map<PropietarioDto>(rol);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PropietarioDto>> Put(int id, [FromBody] PropietarioDto rolDto)
    {
        if (rolDto == null) {
            return NotFound();
        }
        var rol = _mapper.Map<Propietario>(rolDto);
        rol.Id = id;
        _unitOfWork.Propietarios.Update(rol);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<PropietarioDto>(rol);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PropietarioDto>> Delete(int id)
    {
        var rol = await _unitOfWork.Propietarios.GetByIdAsync(id);
        if (rol == null) {
            return NotFound();
        }
        _unitOfWork.Propietarios.Remove(rol);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}