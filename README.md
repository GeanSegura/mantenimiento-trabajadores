# mantenimiento-trabajadores
Solución para la gestión y mantenimiento de trabajadores

# creado por :
Gean Segura Sánchez

# Sistema de Mantenimiento de Trabajadores

Este repositorio contiene dos proyectos: un **frontend en ASP.NET Core MVC** y un **backend en ASP.NET Core Web API**, ambos desarrollados sobre **.NET 8**, siguiendo principios **SOLID** y utilizando **Entity Framework Core** con **SQL Server** como base de datos.

## Estructura del Proyecto

- **Frontend**: `GestionTrabajadores.Web`  
  Proyecto ASP.NET Core MVC con Razor, Bootstrap, JavaScript, HTML y CSS. Interfaz moderna con uso de modals para mantenimiento de trabajadores.

- **Backend**: `GestionTrabajadores.API`  
  API RESTful en ASP.NET Core que expone endpoints para operaciones CRUD sobre los trabajadores.

- **Base de datos**: SQL Server  
  Acceso a datos mediante **Entity Framework Core**, con posibilidad de usar procedimientos almacenados (`Stored Procedures`).

---

## Tecnologías y Herramientas

- .NET 8 (ASP.NET Core)
- C# 12
- Entity Framework Core
- SQL Server
- Bootstrap 5
- Razor Pages (para la vista MVC)
- JavaScript / HTML / CSS
- Principios SOLID
- Patrón por capas (N-Layers)
- Inyección de dependencias (`ITrabajadorRepository`)
- Repositorio privado o público en GitHub

---

## Funcionalidades principales

- Listado de trabajadores
- Crear trabajador (mediante modal)
- Actualizar trabajador (mediante modal)
- Eliminar trabajador (con confirmación)
- Filtro por sexo en la bandeja
- Colores en filas: Azul (masculino) / Naranja (femenino)

---

##  Cómo ejecutar

1. Clonar el repositorio:
```bash
git clone https://github.com/GeanSegura/mantenimiento-trabajadores.git

