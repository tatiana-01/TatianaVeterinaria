
# TatianaVeterinaria
Sistema de administración para una veterinaria. Este sistema permitirá a los administradores y al personal de la veterinaria gestionar de manera eficiente y efectiva todas las actividades relacionadas con la atención de mascotas y la gestión de clientes.


## Cambios en la base de datos

- Se elimino el atributo cantidad de la tabla movimientomedicamento ya que este dato se encuentra en detalle movimiento al igual que el idMedicamento.
- En detalle movimiento se añadio la relacion con tipo movimiento para poder clasificar y relacionar el detalle de movimiento.

## Endpoints

Todas los consultas son tipo GET:

**1.** Crear un consulta que permita visualizar los veterinarios cuya especialidad sea Cirujano vascular.

    http://localhost:5291/api/consultas/cirujanosVasculares

**2.** Listar los medicamentos que pertenezcan a el laboratorio Genfar.

    http://localhost:5291/api/consultas/medicamentosGenfar

**3.** Mostrar las mascotas que se encuentren registradas cuya especie sea felina.

    http://localhost:5291/api/Consultas/especieFelina

**4.** Listar los propietarios y sus mascotas.

    http://localhost:5291/api/consultas/propietarioMascotas

**5.** Listar los medicamentos que tenga un precio de venta mayor a 50000.

    http://localhost:5291/api/Consultas/medsMayor50000

**6.** Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre del 2023.

    http://localhost:5291/api/Consultas/mascotasVacunaTrimestre

En este endpoint se puede comprobar la autorización para esto debe usar el endpoint de token tipo POST:

    http://localhost:5291/api/usuario/token
    
con el body:
```
{
  "username":"Admin",
  "password":"123456"
}
```
y usar el dato del campo token en la consulta.

Este endpoint de vacunas tambien tiene versionado por favor asegurese de insertar en los headers x-version 1.1
## Información

- El proyecto tiene implementado el rate limit permite 10 peticiones cada 10 segundos.
- El token esta configurado con vencimiento de 1 minuto, puede hacer uso del refresh token para obtener uno nuevo, para esto debe usar el endpoint tipo POST: 

         http://localhost:5291/api/usuario/refresh-token

- Todos los endpoints de paginación tienen autorizancion y versionado para usarlos correctamente debe seguir estos pasos

    1. Debe usar el endpoint de token tipo POST:

            http://localhost:5291/api/usuario/token
        
    con el body:
    ```
    {
    "username":"Admin",
    "password":"123456"
    }
    ```
    este le devolvera el token.

    2. Ingrese a un endpoint de paginación tipo GET por ejemplo:

            http://localhost:5291/api/usuario/mascota

    3. Copie el token que le devolvio el primer endpoint y coloquelo en el campo de autorizacion.
    4. En los headers ingrese el dato:  x-version 1.1
## Seeding

El proyetco cuenta con una semilla con información acerca de usuario, rol, veterinarios, medicamentos, mascotas, especie, raza, propietario, cita y tratamiento medico.

- Datos veterinarios, citas y tratamientos medicos:
```
    {
      "id": 1,
      "nombre": "Juan Perez",
      "correoElectronico": "juan@gmail.com",
      "telefono": "3452143567",
      "especialidad": "Cirujano Vascular",
      "citas": []
    },
    {
      "id": 2,
      "nombre": "Adriana Velasquez",
      "correoElectronico": "adriana@gmail.com",
      "telefono": "3452154567",
      "especialidad": "Cirujano Vascular",
      "citas": []
    },
    {
      "id": 3,
      "nombre": "Julian Gomez",
      "correoElectronico": "julian@gmail.com",
      "telefono": "3102143567",
      "especialidad": "General",
      "citas": [
        {
          "id": 1,
          "idMascota": 2,
          "fecha": "2023-02-05",
          "hora": "10:15:00",
          "motivo": "Vacunacion Triple Felina",
          "idVeterinario": 3,
          "tratamientoMedicos": [
            {
              "id": 1,
              "idCita": 1,
              "idMedicamento": 4,
              "dosis": "Una dosis de 8ml",
              "fechaAdministracion": "2023-02-05T00:00:00",
              "observacion": "Recibio bien la vacuna se programa siguiente vacuna para dentro de 6 meses"
            }
          ]
        },
        {
          "id": 2,
          "idMascota": 1,
          "fecha": "2023-01-05",
          "hora": "15:15:00",
          "motivo": "Revisión rutinaria",
          "idVeterinario": 3,
          "tratamientoMedicos": [
            {
              "id": 2,
              "idCita": 2,
              "idMedicamento": 0,
              "dosis": "No se receto medicamento",
              "fechaAdministracion": "2023-01-05T00:00:00",
              "observacion": "El paciente se encontraba en excelente estado"
            }
          ]
        },
        {
          "id": 3,
          "idMascota": 3,
          "fecha": "2023-06-05",
          "hora": "12:15:00",
          "motivo": "Vacunacion Octuple",
          "idVeterinario": 3,
          "tratamientoMedicos": [
            {
              "id": 3,
              "idCita": 3,
              "idMedicamento": 5,
              "dosis": "Una dosis de 12ml",
              "fechaAdministracion": "2023-06-05T00:00:00",
              "observacion": "Recibio bien la vacuna se programa siguiente vacuna para dentro de 4 meses"
            }
          ]
        }
      ]
    }
```

- Datos mascota, propietario, cita y tratamiento Medicos
```
 {
      "id": 1,
      "idPropietario": 1,
      "idEspecie": 1,
      "idRaza": 1,
      "nombre": "Botas",
      "fechaNacimiento": "2020-09-06T00:00:00",
      "citas": [
        {
          "id": 2,
          "idMascota": 1,
          "fecha": "2023-01-05",
          "hora": "15:15:00",
          "motivo": "Revisión rutinaria",
          "idVeterinario": 3,
          "tratamientoMedicos": [
            {
              "id": 2,
              "idCita": 2,
              "idMedicamento": 0,
              "dosis": "No se receto medicamento",
              "fechaAdministracion": "2023-01-05T00:00:00",
              "observacion": "El paciente se encontraba en excelente estado"
            }
          ]
        }
      ]
    },
    {
      "id": 2,
      "idPropietario": 1,
      "idEspecie": 1,
      "idRaza": 1,
      "nombre": "Bigotes",
      "fechaNacimiento": "2020-09-15T00:00:00",
      "citas": [
        {
          "id": 1,
          "idMascota": 2,
          "fecha": "2023-02-05",
          "hora": "10:15:00",
          "motivo": "Vacunacion Triple Felina",
          "idVeterinario": 3,
          "tratamientoMedicos": [
            {
              "id": 1,
              "idCita": 1,
              "idMedicamento": 4,
              "dosis": "Una dosis de 8ml",
              "fechaAdministracion": "2023-02-05T00:00:00",
              "observacion": "Recibio bien la vacuna se programa siguiente vacuna para dentro de 6 meses"
            }
          ]
        }
      ]
    },
    {
      "id": 3,
      "idPropietario": 2,
      "idEspecie": 2,
      "idRaza": 2,
      "nombre": "Bruno",
      "fechaNacimiento": "2019-10-06T00:00:00",
      "citas": [
        {
          "id": 3,
          "idMascota": 3,
          "fecha": "2023-06-05",
          "hora": "12:15:00",
          "motivo": "Vacunacion Octuple",
          "idVeterinario": 3,
          "tratamientoMedicos": [
            {
              "id": 3,
              "idCita": 3,
              "idMedicamento": 5,
              "dosis": "Una dosis de 12ml",
              "fechaAdministracion": "2023-06-05T00:00:00",
              "observacion": "Recibio bien la vacuna se programa siguiente vacuna para dentro de 4 meses"
            }
          ]
        }
      ]
    }
```
- Datos Especie, Raza y Mascotas
```
 {
      "id": 1,
      "nombre": "Felina",
      "razas": [
        {
          "id": 1,
          "nombre": "Siamés",
          "idEspecie": 1
        }
      ],
      "mascotas": [
        {
          "id": 1,
          "idPropietario": 1,
          "idEspecie": 1,
          "idRaza": 1,
          "nombre": "Botas",
          "fechaNacimiento": "2020-09-06T00:00:00"
        },
        {
          "id": 2,
          "idPropietario": 1,
          "idEspecie": 1,
          "idRaza": 1,
          "nombre": "Bigotes",
          "fechaNacimiento": "2020-09-15T00:00:00"
        }
      ]
    },
    {
      "id": 2,
      "nombre": "Canina",
      "razas": [
        {
          "id": 2,
          "nombre": "Pastor Aleman",
          "idEspecie": 2
        }
      ],
      "mascotas": [
        {
          "id": 3,
          "idPropietario": 2,
          "idEspecie": 2,
          "idRaza": 2,
          "nombre": "Bruno",
          "fechaNacimiento": "2019-10-06T00:00:00"
        }
      ]
    }
```
- Datos Usuario y rol:
```
  {
      "id": 1,
      "username": "Admin",
      "email": "admin@gmail.com",
      "password": "AQAAAAIAAYagAAAAEBcv4Cb2mRKF+b1eVGp/y98/EeyGhbdkvSopjMM15ZsVi+lnrgYfX8vP5XgGtOjCxA==",
      "roles": [
        {
          "id": 1,
          "nombre": "Administrador"
        }
      ]
    }
```

