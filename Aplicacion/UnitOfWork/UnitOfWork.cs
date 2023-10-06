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
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}