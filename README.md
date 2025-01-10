# Web API con .NET Core 8

Esta solución es una **API RESTful** desarrollada en **.NET Core 8**. Proporciona un conjunto de endpoints para la gestión de productos, incluyendo operaciones CRUD (Crear, Leer, Actualizar y Eliminar), El proyecto esta orientado a objetos, e incluye validaciones, y como base de datos por default usa SQLite.


![Swagger final screen](https://github.com/roco170a/webapi-productos/blob/master/raw/swagger.jpg "Swagger")

## Características principales

- Desarrollo en **.NET Core 8**.
- Usa Entity Framework Core.
- Usa Migrations y Data Seeding para inicializar la db.
- Utiliza validaciones de modelos con Data Annotations.
- Documentación de cada endpoint con **Swagger**.
- Pruebas unitarias con **xUnit**.

---

## Requisitos previos

Antes de ejecutar la aplicación, asegúrate de tener instalados los siguientes componentes:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/sql-server) u otro proveedor de bases de datos compatible.
- Opcional: [Postman](https://www.postman.com/) o **cURL** para probar los endpoints.

---

## Configuración inicial

### 1. Clonar el repositorio
```bash
git clone https://github.com/tuusuario/tu-repositorio.git
cd tu-repositorio
