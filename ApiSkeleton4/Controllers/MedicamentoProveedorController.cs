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
public class MedicamentoProveedorController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MedicamentoProveedorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<MedicamentoProveedorDto>>> GetPaginaMedicamentoProveedor([FromQuery] Params usuarioParams)
    {
        var usuariosRoles = await _unitOfWork.MedicamentoProveedores.GetAllAsync(usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);

        var lstUsuRolDto = _mapper.Map<List<MedicamentoProveedorDto>>(usuariosRoles.registros);

        return new Pager<MedicamentoProveedorDto>(lstUsuRolDto, usuariosRoles.totalRegistros, usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
    }

    [HttpGet("{idMedicamento}/{idProveedor}")]
    ////[Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MedicamentoProveedorDto>> GetByIdMedicamentoProveedor( int idMedicamento, int idProveedor)
    {
        var usuarioRol = await _unitOfWork.MedicamentoProveedores.GetByIdAsync(idMedicamento, idProveedor);

        if (usuarioRol == null) {
            return NotFound();
        }

        return _mapper.Map<MedicamentoProveedorDto>(usuarioRol);
    }

    [HttpPost]
    ////[Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MedicamentoProveedorDto>> Post(MedicamentoProveedorDto usuarioRolDto)
    {
        var usuarioRol = _mapper.Map<MedicamentoProveedor>(usuarioRolDto);
        _unitOfWork.MedicamentoProveedores.Add(usuarioRol);
        await _unitOfWork.SaveAsync();

        if (usuarioRol == null) {
            return BadRequest();
        }

        return _mapper.Map<MedicamentoProveedorDto>(usuarioRol);
    }

    [HttpPut("{idMedicamento}/{idProveedor}")]
    ////[Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MedicamentoProveedorDto>> Put(int idMedicamento, int idProveedor, [FromBody] MedicamentoProveedorDto usuarioRolDto)
    {
        if (usuarioRolDto == null) {
            return NotFound();
        }

        var usuarioRol = _mapper.Map<MedicamentoProveedor>(usuarioRolDto);
        usuarioRol.IdMedicamento = idMedicamento;
        usuarioRol.IdProveedor = idProveedor;
        _unitOfWork.MedicamentoProveedores.Update(usuarioRol);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<MedicamentoProveedorDto>(usuarioRol);        
    }

    [HttpDelete("{idMedicamento}/{idProveedor}")]
    ////[Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MedicamentoProveedorDto>> Delete(int idMedicamento, int idProveedor)
    {
        var usuarioRol = await _unitOfWork.MedicamentoProveedores.GetByIdAsync (idMedicamento, idProveedor);
        
        if (usuarioRol == null) {
            return NotFound();
        }

        _unitOfWork.MedicamentoProveedores.Remove(usuarioRol);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
