using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Repositories;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly Skeleton4CapasContext _context;
    private RolRepository _roles;
    private UsuarioRepository _usuarios;
    private UsuarioRolRepository _usuarioRoles;
    private CitaRepository _citas;
    private DetalleMovimientoRepository _detalleMovimientos;

    public UnitOfWork(Skeleton4CapasContext context)
    {
        _context = context;
    }
    public IRol Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }

    public IUsuario Usuarios
    {
        get
        {
            if (_usuarios == null)
            {
                _usuarios = new UsuarioRepository(_context);
            }
            return _usuarios;
        }
    }
    public IUsuarioRol UsuarioRoles
    {
        get
        {
            if (_usuarioRoles == null)
            {
                _usuarioRoles = new UsuarioRolRepository(_context);
            }
            return _usuarioRoles;
        }
    }
    public ICita Citas
    {
        get
        {
            if (_citas == null)
            {
                _citas = new CitaRepository(_context);
            }
            return _citas;
        }
    }

    public IDetalleMovimiento DetalleMovimientos
    {
        get
        {
            if (_detalleMovimientos == null)
            {
                _detalleMovimientos = new DetalleMovimientoRepository(_context);
            }
            return _detalleMovimientos;
        }
    }

    private EspecieRepository _especies;
    public IEspecie Especies
    {
        get
        {
            if (_especies == null)
            {
                _especies = new EspecieRepository(_context);
            }
            return _especies;
        }
    }

    private LaboratorioRepository _laboratorios;
    public ILaboratorio Laboratorios
    {
        get
        {
            if (_laboratorios == null)
            {
                _laboratorios = new LaboratorioRepository(_context);
            }
            return _laboratorios;
        }
    }

    private MascotaRepository _mascotas;
    public IMascota Mascotas
    {
        get
        {
            if (_mascotas == null)
            {
                _mascotas = new MascotaRepository(_context);
            }
            return _mascotas;
        }
    }

    private MedicamentoRepository _medicamentos;
    public IMedicamento Medicamentos
    {
        get
        {
            if (_medicamentos == null)
            {
                _medicamentos = new MedicamentoRepository(_context);
            }
            return _medicamentos;
        }
    }

    private MedicamentoProveedorRepository _medicamentoProveedores;
    public IMedicamentoProveedor MedicamentoProveedores
    {
        get
        {
            if (_medicamentoProveedores == null)
            {
                _medicamentoProveedores = new MedicamentoProveedorRepository(_context);
            }
            return _medicamentoProveedores;
        }
    }

    private MovimientoMedicamentoRepository _movimientoMedicamentos;
    public IMovimientoMedicamento MovimientoMedicamentos
    {
        get
        {
            if (_movimientoMedicamentos == null)
            {
                _movimientoMedicamentos = new MovimientoMedicamentoRepository(_context);
            }
            return _movimientoMedicamentos;
        }
    }

    private PropietarioRepository _propietarios;
    public IPropietario Propietarios
    {
        get
        {
            if (_propietarios == null)
            {
                _propietarios = new PropietarioRepository(_context);
            }
            return _propietarios;
        }
    }

    private ProveedorRepository _proveedores;
    public IProveedor Proveedores
    {
        get
        {
            if (_proveedores == null)
            {
                _proveedores = new ProveedorRepository(_context);
            }
            return _proveedores;
        }
    }

    private RazaRepository _razas;
    public IRaza Razas
    {
        get
        {
            if (_razas == null)
            {
                _razas = new RazaRepository(_context);
            }
            return _razas;
        }
    }

    private TipoMovimientoRepository _tipoMovimientos;
    public ITipoMovimiento TipoMovimientos
    {
        get
        {
            if (_tipoMovimientos == null)
            {
                _tipoMovimientos = new TipoMovimientoRepository(_context);
            }
            return _tipoMovimientos;
        }
    }
    private TratamientoMedicoRepository _tratamientoMedicos;
    public ITratamientoMedico TratamientoMedicos
    {
        get
        {
            if (_tratamientoMedicos == null)
            {
                _tratamientoMedicos = new TratamientoMedicoRepository(_context);
            }
            return _tratamientoMedicos;
        }
    }

    private VeterinarioRepository _veterinarios;
    public IVeterinario Veterinarios
    {
        get
        {
            if (_veterinarios == null)
            {
                _veterinarios = new VeterinarioRepository(_context);
            }
            return _veterinarios;
        }
    }

    private ConsultaRepository _consultas;
    public IConsulta Consultas
    {
        get
        {
            if (_consultas == null)
            {
                _consultas = new ConsultaRepository(_context);
            }
            return _consultas;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}