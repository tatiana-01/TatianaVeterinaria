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
public class EspecieController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public EspecieController(IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<Pager<EspecieGetAllDto>>> GetAll([FromQuery] Params rolParams)
    {
        var roles = await _unitOfWork.Especies.GetAllAsync(rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
        var lstTipoPersonaDto = _mapper.Map<List<EspecieGetAllDto>>(roles.registros);
        return new Pager<EspecieGetAllDto>(lstTipoPersonaDto, roles.totalRegistros, rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EspecieGetAllDto>> GetById(int id)
    {
        var rol = await _unitOfWork.Especies.GetByIdAsync(id);
        if (rol == null) {
            return NotFound();
        }
        return _mapper.Map<EspecieGetAllDto>(rol);
    }

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EspecieDto>> Post(EspeciePostDto rolDto)
    {
        var rol = _mapper.Map<Especie>(rolDto);
        _unitOfWork.Especies.Add(rol);
        await _unitOfWork.SaveAsync();
        if (rol == null) {
            return BadRequest();
        }
        return _mapper.Map<EspecieDto>(rol);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EspecieDto>> Put(int id, [FromBody] EspecieDto rolDto)
    {
        if (rolDto == null) {
            return NotFound();
        }
        var rol = _mapper.Map<Especie>(rolDto);
        rol.Id = id;
        _unitOfWork.Especies.Update(rol);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<EspecieDto>(rol);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EspecieDto>> Delete(int id)
    {
        var rol = await _unitOfWork.Especies.GetByIdAsync(id);
        if (rol == null) {
            return NotFound();
        }
        _unitOfWork.Especies.Remove(rol);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}