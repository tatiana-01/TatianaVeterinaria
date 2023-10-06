using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces;
    public interface IUnitOfWork
    {
        IRol Roles{get;}
        IUsuario Usuarios{get;}
        IUsuarioRol UsuarioRoles {get;}
        Task<int> SaveAsync();
    }
