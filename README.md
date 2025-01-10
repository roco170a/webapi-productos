# Web API con .NET Core 8

Esta solución es una **API RESTful** desarrollada en **.NET Core 8**. Proporciona un conjunto de endpoints para la gestión de productos, incluyendo operaciones CRUD (Crear, Leer, Actualizar y Eliminar), El proyecto esta orientado a objetos, e incluye validaciones, y como base de datos por default usa SQLite.


![Swagger final screen](https://github.com/roco170a/webapi-productos/blob/master/raw/swagger.jpg "Swagger")

## Características principales

- Desarrollo en **.NET Core 8**.
- Usa Entity Framework Core.
- Usa Migrations y Data Seeding para inicializar la db.
- Utiliza validaciones de modelos con Data Annotations.
- Contiene una capa de servicio y Dependency Injection.
- Documentación de cada endpoint con **Swagger**.
- Pruebas unitarias con **xUnit**.

---

## Requisitos previos

Antes de ejecutar la aplicación, asegúrate de tener instalados los siguientes componentes:

- [Git Client](https://git-scm.com/downloads)
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

---

## Configuración inicial

### 1. Clonar el repositorio
```bash
git clone https://github.com/roco170a/webapi-productos.git
cd webapi-productos
```

### 2. Restaurar dependencias
```bash
dotnet restore
```

### 3. Compilar el proyecto
```bash
dotnet build
```
