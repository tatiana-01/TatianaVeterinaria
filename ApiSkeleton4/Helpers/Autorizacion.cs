using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSkeleton4.Helpers;
  public class Autorizacion
  {
    public enum Roles
    {
        Administrador,
        Gerente,
        Empleado,
        Persona
    }
    public const Roles rol_predeterminado = Roles.Persona;
  }
