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
public class MedicamentoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public MedicamentoController(IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<Pager<MedicamentoGetAllDto>>> GetAll([FromQuery] Params rolParams)
    {
        var roles = await _unitOfWork.Medicamentos.GetAllAsync(rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
        var lstTipoPersonaDto = _mapper.Map<List<MedicamentoGetAllDto>>(roles.registros);
        return new Pager<MedicamentoGetAllDto>(lstTipoPersonaDto, roles.totalRegistros, rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MedicamentoGetAllDto>> GetById(int id)
    {
        var rol = await _unitOfWork.Medicamentos.GetByIdAsync(id);
        if (rol == null) {
            return NotFound();
        }
        return _mapper.Map<MedicamentoGetAllDto>(rol);
    }

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MedicamentoDto>> Post(MedicamentoPostDto rolDto)
    {
        var rol = _mapper.Map<Medicamento>(rolDto);
        _unitOfWork.Medicamentos.Add(rol);
        await _unitOfWork.SaveAsync();
        if (rol == null) {
            return BadRequest();
        }
        return _mapper.Map<MedicamentoDto>(rol);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MedicamentoDto>> Put(int id, [FromBody] MedicamentoDto rolDto)
    {
        if (rolDto == null) {
            return NotFound();
        }
        var rol = _mapper.Map<Medicamento>(rolDto);
        rol.Id = id;
        _unitOfWork.Medicamentos.Update(rol);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<MedicamentoDto>(rol);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MedicamentoDto>> Delete(int id)
    {
        var rol = await _unitOfWork.Medicamentos.GetByIdAsync(id);
        if (rol == null) {
            return NotFound();
        }
        _unitOfWork.Medicamentos.Remove(rol);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}