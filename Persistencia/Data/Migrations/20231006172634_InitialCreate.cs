﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Especie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especie", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Laboratorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorio", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Propietario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoElectronico = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimiento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Veterinario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoElectronico = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Especialidad = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Raza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdEspecie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Raza_Especie_IdEspecie",
                        column: x => x.IdEspecie,
                        principalTable: "Especie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CantidadDisponible = table.Column<int>(type: "int", nullable: false),
                    PrecioVenta = table.Column<double>(type: "double", nullable: false),
                    IdLaboratorio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicamento_Laboratorio_IdLaboratorio",
                        column: x => x.IdLaboratorio,
                        principalTable: "Laboratorio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovimientoMedicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdTipoMovimiento = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoMedicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimientoMedicamento_TipoMovimiento_IdTipoMovimiento",
                        column: x => x.IdTipoMovimiento,
                        principalTable: "TipoMovimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioRol",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRol", x => new { x.UsuarioId, x.RolId });
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mascota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPropietario = table.Column<int>(type: "int", nullable: false),
                    IdEspecie = table.Column<int>(type: "int", nullable: false),
                    IdRaza = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mascota_Especie_IdEspecie",
                        column: x => x.IdEspecie,
                        principalTable: "Especie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mascota_Propietario_IdPropietario",
                        column: x => x.IdPropietario,
                        principalTable: "Propietario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mascota_Raza_IdRaza",
                        column: x => x.IdRaza,
                        principalTable: "Raza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicamentoProveedor",
                columns: table => new
                {
                    IdMedicamento = table.Column<int>(type: "int", nullable: false),
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentoProveedor", x => new { x.IdMedicamento, x.IdProveedor });
                    table.ForeignKey(
                        name: "FK_MedicamentoProveedor_Medicamento_IdMedicamento",
                        column: x => x.IdMedicamento,
                        principalTable: "Medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicamentoProveedor_Proveedor_IdProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetalleMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdMedicamento = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IdMovimientoMedicamento = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleMovimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleMovimiento_Medicamento_IdMedicamento",
                        column: x => x.IdMedicamento,
                        principalTable: "Medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleMovimiento_MovimientoMedicamento_IdMovimientoMedicame~",
                        column: x => x.IdMovimientoMedicamento,
                        principalTable: "MovimientoMedicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdMascota = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Hora = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    Motivo = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdVeterinario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cita_Mascota_IdMascota",
                        column: x => x.IdMascota,
                        principalTable: "Mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_Veterinario_IdVeterinario",
                        column: x => x.IdVeterinario,
                        principalTable: "Veterinario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TratamientoMedico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCita = table.Column<int>(type: "int", nullable: false),
                    IdMedicamento = table.Column<int>(type: "int", nullable: true),
                    Dosis = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaAdministracion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Observacion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamientoMedico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TratamientoMedico_Cita_IdCita",
                        column: x => x.IdCita,
                        principalTable: "Cita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TratamientoMedico_Medicamento_IdMedicamento",
                        column: x => x.IdMedicamento,
                        principalTable: "Medicamento",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Especie",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Felina" },
                    { 2, "Canina" }
                });

            migrationBuilder.InsertData(
                table: "Laboratorio",
                columns: new[] { "Id", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Calle 13 #45-67", "Genfar", "6543789" },
                    { 2, "Calle 45 #45-67", "Agro", "3107856432" }
                });

            migrationBuilder.InsertData(
                table: "Propietario",
                columns: new[] { "Id", "CorreoElectronico", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "juliana@gmail.com", "Juliana Calderon", "3456789012" },
                    { 2, "paula@gmail.com", "Paula Porras", "3456789012" }
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Gerente" },
                    { 3, "Empleado" },
                    { 4, "Persona" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { 1, "admin@gmail.com", "AQAAAAIAAYagAAAAEBcv4Cb2mRKF+b1eVGp/y98/EeyGhbdkvSopjMM15ZsVi+lnrgYfX8vP5XgGtOjCxA==", "Admin" });

            migrationBuilder.InsertData(
                table: "Veterinario",
                columns: new[] { "Id", "CorreoElectronico", "Especialidad", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "juan@gmail.com", "Cirujano Vascular", "Juan Perez", "3452143567" },
                    { 2, "adriana@gmail.com", "Cirujano Vascular", "Adriana Velasquez", "3452154567" },
                    { 3, "julian@gmail.com", "General", "Julian Gomez", "3102143567" }
                });

            migrationBuilder.InsertData(
                table: "Medicamento",
                columns: new[] { "Id", "CantidadDisponible", "IdLaboratorio", "Nombre", "PrecioVenta" },
                values: new object[,]
                {
                    { 1, 0, 1, "Aciflux", 55000.0 },
                    { 2, 0, 1, "Doxiciclina", 70000.0 },
                    { 3, 0, 2, "Meloxicam", 35000.0 },
                    { 4, 0, 2, "Triple Felina", 80000.0 },
                    { 5, 0, 2, "Octuple", 80000.0 }
                });

            migrationBuilder.InsertData(
                table: "Raza",
                columns: new[] { "Id", "IdEspecie", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Siamés" },
                    { 2, 2, "Pastor Aleman" }
                });

            migrationBuilder.InsertData(
                table: "UsuarioRol",
                columns: new[] { "RolId", "UsuarioId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Mascota",
                columns: new[] { "Id", "FechaNacimiento", "IdEspecie", "IdPropietario", "IdRaza", "Nombre" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, "Botas" },
                    { 2, new DateTime(2020, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, "Bigotes" },
                    { 3, new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 2, "Bruno" }
                });

            migrationBuilder.InsertData(
                table: "Cita",
                columns: new[] { "Id", "Fecha", "Hora", "IdMascota", "IdVeterinario", "Motivo" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 2, 5), new TimeOnly(10, 15, 0), 2, 3, "Vacunacion Triple Felina" },
                    { 2, new DateOnly(2023, 1, 5), new TimeOnly(15, 15, 0), 1, 3, "Revisión rutinaria" },
                    { 3, new DateOnly(2023, 6, 5), new TimeOnly(12, 15, 0), 3, 3, "Vacunacion Octuple" }
                });

            migrationBuilder.InsertData(
                table: "TratamientoMedico",
                columns: new[] { "Id", "Dosis", "FechaAdministracion", "IdCita", "IdMedicamento", "Observacion" },
                values: new object[,]
                {
                    { 1, "Una dosis de 8ml", new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, "Recibio bien la vacuna se programa siguiente vacuna para dentro de 6 meses" },
                    { 2, "No se receto medicamento", new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, "El paciente se encontraba en excelente estado" },
                    { 3, "Una dosis de 12ml", new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, "Recibio bien la vacuna se programa siguiente vacuna para dentro de 4 meses" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IdMascota",
                table: "Cita",
                column: "IdMascota");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IdVeterinario",
                table: "Cita",
                column: "IdVeterinario");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMovimiento_IdMedicamento",
                table: "DetalleMovimiento",
                column: "IdMedicamento");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMovimiento_IdMovimientoMedicamento",
                table: "DetalleMovimiento",
                column: "IdMovimientoMedicamento");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_IdEspecie",
                table: "Mascota",
                column: "IdEspecie");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_IdPropietario",
                table: "Mascota",
                column: "IdPropietario");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_IdRaza",
                table: "Mascota",
                column: "IdRaza");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_IdLaboratorio",
                table: "Medicamento",
                column: "IdLaboratorio");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentoProveedor_IdProveedor",
                table: "MedicamentoProveedor",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoMedicamento_IdTipoMovimiento",
                table: "MovimientoMedicamento",
                column: "IdTipoMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Raza_IdEspecie",
                table: "Raza",
                column: "IdEspecie");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UsuarioId",
                table: "RefreshTokens",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientoMedico_IdCita",
                table: "TratamientoMedico",
                column: "IdCita");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientoMedico_IdMedicamento",
                table: "TratamientoMedico",
                column: "IdMedicamento");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_RolId",
                table: "UsuarioRol",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleMovimiento");

            migrationBuilder.DropTable(
                name: "MedicamentoProveedor");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "TratamientoMedico");

            migrationBuilder.DropTable(
                name: "UsuarioRol");

            migrationBuilder.DropTable(
                name: "MovimientoMedicamento");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoMovimiento");

            migrationBuilder.DropTable(
                name: "Mascota");

            migrationBuilder.DropTable(
                name: "Veterinario");

            migrationBuilder.DropTable(
                name: "Laboratorio");

            migrationBuilder.DropTable(
                name: "Propietario");

            migrationBuilder.DropTable(
                name: "Raza");

            migrationBuilder.DropTable(
                name: "Especie");
        }
    }
}
