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
public class TipoMovimientoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public TipoMovimientoController(IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<Pager<TipoMovimientoGetAllDto>>> GetAll([FromQuery] Params rolParams)
    {
        var roles = await _unitOfWork.TipoMovimientos.GetAllAsync(rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
        var lstTipoPersonaDto = _mapper.Map<List<TipoMovimientoGetAllDto>>(roles.registros);
        return new Pager<TipoMovimientoGetAllDto>(lstTipoPersonaDto, roles.totalRegistros, rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoMovimientoGetAllDto>> GetById(int id)
    {
        var rol = await _unitOfWork.TipoMovimientos.GetByIdAsync(id);
        if (rol == null) {
            return NotFound();
        }
        return _mapper.Map<TipoMovimientoGetAllDto>(rol);
    }

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoMovimientoDto>> Post(TipoMovimientoPostDto rolDto)
    {
        var rol = _mapper.Map<TipoMovimiento>(rolDto);
        _unitOfWork.TipoMovimientos.Add(rol);
        await _unitOfWork.SaveAsync();
        if (rol == null) {
            return BadRequest();
        }
        return _mapper.Map<TipoMovimientoDto>(rol);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoMovimientoDto>> Put(int id, [FromBody] TipoMovimientoDto rolDto)
    {
        if (rolDto == null) {
            return NotFound();
        }
        var rol = _mapper.Map<TipoMovimiento>(rolDto);
        rol.Id = id;
        _unitOfWork.TipoMovimientos.Update(rol);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<TipoMovimientoDto>(rol);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoMovimientoDto>> Delete(int id)
    {
        var rol = await _unitOfWork.TipoMovimientos.GetByIdAsync(id);
        if (rol == null) {
            return NotFound();
        }
        _unitOfWork.TipoMovimientos.Remove(rol);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}