using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Seeding;
public class SeedingInicial
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var AdministradorRol = new Rol()
            {
                Id = 1,
                Nombre = "Administrador"
            };
            var GerenteRol = new Rol()
            {
                Id = 2,
                Nombre = "Gerente"
            };
            var EmpleadoRol = new Rol()
            {
                Id = 3,
                Nombre = "Empleado"
            };
            var PersonaRol = new Rol()
            {
                Id = 4,
                Nombre = "Persona"
            };
            var Administrador = new Usuario()
            {
                Id=1,
                Username="Admin",
                Email="admin@gmail.com",
            };
            var _passwordHasher = new PasswordHasher<Usuario>();
            Administrador.Password = _passwordHasher.HashPassword(Administrador, "123456");
            var AdminUsuarioRol = new UsuarioRol()
            {
                RolId = 1,
                UsuarioId = 1
            };
            modelBuilder.Entity<Usuario>().HasData(Administrador);
            modelBuilder.Entity<Rol>().HasData(AdministradorRol, EmpleadoRol, PersonaRol, GerenteRol);
            modelBuilder.Entity<UsuarioRol>().HasData(AdminUsuarioRol);
            var veterinarioCirujanoVascular1= new Veterinario(){
                Id=1,
                Nombre="Juan Perez",
                CorreoElectronico="juan@gmail.com",
                Telefono="3452143567",
                Especialidad="Cirujano Vascular"
            };
            var veterinarioCirujanoVascular2= new Veterinario(){
                Id=2,
                Nombre="Adriana Velasquez",
                CorreoElectronico="adriana@gmail.com",
                Telefono="3452154567",
                Especialidad="Cirujano Vascular"
            };
            var veterinario3= new Veterinario(){
                Id=3,
                Nombre="Julian Gomez",
                CorreoElectronico="julian@gmail.com",
                Telefono="3102143567",
                Especialidad="General"
            };
           modelBuilder.Entity<Veterinario>().HasData(veterinarioCirujanoVascular1, veterinarioCirujanoVascular2, veterinario3);
           var laboratorioGenfar=new Laboratorio(){
                Id=1,
                Nombre="Genfar",
                Direccion="Calle 13 #45-67",
                Telefono="6543789"
           };
           var laboratorioAgro=new Laboratorio(){
                Id=2,
                Nombre="Agro",
                Direccion="Calle 45 #45-67",
                Telefono="3107856432"
           };
           var medicamento1=new Medicamento(){
                Id=1,
                Nombre="Aciflux",
                PrecioVenta=55000,
                IdLaboratorio=1
           };
           var medicamento2=new Medicamento(){
                Id=2,
                Nombre="Doxiciclina",
                PrecioVenta=70000,
                IdLaboratorio=1
           };
           var medicamento3=new Medicamento(){
                Id=3,
                Nombre="Meloxicam",
                PrecioVenta=35000,
                IdLaboratorio=2
           };
           var medicamento4=new Medicamento(){
                Id=4,
                Nombre="Triple Felina",
                PrecioVenta=80000,
                IdLaboratorio=2
           };
           var medicamento5=new Medicamento(){
                Id=5,
                Nombre="Octuple",
                PrecioVenta=80000,
                IdLaboratorio=2
           };
           modelBuilder.Entity<Laboratorio>().HasData(laboratorioGenfar, laboratorioAgro);
           modelBuilder.Entity<Medicamento>().HasData(medicamento1, medicamento2, medicamento3,medicamento4,medicamento5);
           var especie1=new Especie(){
                Id=1,
                Nombre="Felina"
           };
           var especie2=new Especie(){
                Id=2,
                Nombre="Canina"
           };
           modelBuilder.Entity<Especie>().HasData(especie1, especie2);
           var raza1=new Raza(){
                Id=1,
                IdEspecie=1,
                Nombre="Siamés"
           };
           var raza2=new Raza(){
                Id=2,
                IdEspecie=2,
                Nombre="Pastor Aleman"
           };
           modelBuilder.Entity<Raza>().HasData(raza1, raza2);
           var propietario1=new Propietario(){
                Id=1,
                Nombre="Juliana Calderon",
                CorreoElectronico="juliana@gmail.com",
                Telefono="3456789012"
           };
           var propietario2=new Propietario(){
                Id=2,
                Nombre="Paula Porras",
                CorreoElectronico="paula@gmail.com",
                Telefono="3456789012"
           };
           modelBuilder.Entity<Propietario>().HasData(propietario1, propietario2);
           var mascota1=new Mascota(){
                Id=1,
                IdPropietario=1,
                IdEspecie=1,
                IdRaza=1,
                Nombre="Botas",
                FechaNacimiento=new DateTime(2020,09,06)
           };
           var mascota2=new Mascota(){
                Id=2,
                IdPropietario=1,
                IdEspecie=1,
                IdRaza=1,
                Nombre="Bigotes",
                FechaNacimiento=new DateTime(2020,09,15)
           };
           var mascota3=new Mascota(){
                Id=3,
                IdPropietario=2,
                IdEspecie=2,
                IdRaza=2,
                Nombre="Bruno",
                FechaNacimiento=new DateTime(2019,10,06)
           };
           modelBuilder.Entity<Mascota>().HasData(mascota1, mascota2, mascota3);
            var cita1=new Cita(){
                Id=1,
                IdMascota=2,
                Fecha=new DateOnly(2023,02,05),
                Hora=new TimeOnly(10,15),
                Motivo="Vacunacion Triple Felina",
                IdVeterinario=3
            };
            var cita2=new Cita(){
                Id=2,
                IdMascota=1,
                Fecha=new DateOnly(2023,01,05),
                Hora=new TimeOnly(15,15),
                Motivo="Revisión rutinaria",
                IdVeterinario=3
            };
            var cita3=new Cita(){
                Id=3,
                IdMascota=3,
                Fecha=new DateOnly(2023,06,05),
                Hora=new TimeOnly(12,15),
                Motivo="Vacunacion Octuple",
                IdVeterinario=3
            };
            modelBuilder.Entity<Cita>().HasData(cita1, cita2, cita3);
            var tratamiento1=new TratamientoMedico(){
                Id=1,
                IdCita=1,
                IdMedicamento=4,
                Dosis="Una dosis de 8ml",
                FechaAdministracion=new DateTime(2023,02,05),
                Observacion="Recibio bien la vacuna se programa siguiente vacuna para dentro de 6 meses"
            };
            var tratamiento2=new TratamientoMedico(){
                Id=2,
                IdCita=2,
                IdMedicamento=null,
                Dosis="No se receto medicamento",
                FechaAdministracion=new DateTime(2023,01,05),
                Observacion="El paciente se encontraba en excelente estado"
            };
            var tratamiento3=new TratamientoMedico(){
                Id=3,
                IdCita=3,
                IdMedicamento=5,
                Dosis="Una dosis de 12ml",
                FechaAdministracion=new DateTime(2023,06,05),
                Observacion="Recibio bien la vacuna se programa siguiente vacuna para dentro de 4 meses"
            };
            modelBuilder.Entity<TratamientoMedico>().HasData(tratamiento1, tratamiento2, tratamiento3);
        }
    }