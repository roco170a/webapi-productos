# Web API .NET Core 8 + C #

This solution is a **RESTful API** developed in **.NET Core 8**. It provides a set of endpoints for product management, including CRUD (Create, Read, Update and Delete) operations. The project is object-oriented, includes validations, and uses SQLite as the default database.


![Swagger final screen](https://github.com/roco170a/webapi-productos/blob/master/raw/swagger.jpg "Swagger")

## Main Features

- Development in **.NET Core 8**.
- Uses Entity Framework Core.
- Uses Migrations and Data Seeding to initialize the db.
- Uses model validations with Data Annotations.
- Contains a service layer and Dependency Injection.
- Documentation of each endpoint with **Swagger**.
- Unit tests with **xUnit**.

---

## Prerequisites

Before running the application, make sure you have the following components installed:

- [Git Client](https://git-scm.com/downloads)
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

---

## Project Setup

### 1. Clone repositorio

```bash
git clone https://github.com/roco170a/webapi-productos.git
cd webapi-productos
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Compile

```bash
dotnet build
```

### 4. Trust in SSL

```bash
dotnet dev-certs https --trust
```
---

## Run 

### 1. Use a SSL Port

```bash
dotnet run --launch-profile https --project apiProductos
```

### 2. Browse 

Use web browser 

> [!TIP]
> https://localhost:7213/swagger 

![Execution screen](https://github.com/roco170a/webapi-productos/blob/master/raw/swagger2.jpg "Datos por default")

---
## Run Tests

### 1. Go to Test Project 

```bash
cd ProductServiceTests
```

### 2. Run report

```bash
dotnet test --logger "html;logfilename=testResults.html"
```

### 3. Check results

Use web browser to see report

> [!TIP]
> file:///RUTARELATIVA/webapi-productos/ProductServiceTests/TestResults/testResults.html


![Test report](https://github.com/roco170a/webapi-productos/blob/master/raw/reporte.jpg "Ejecución de pruebas")


## Contact

Have questions, please get in touch

- **Correo**: [roco170@gmail.com](mailto:roco170@gmail.com)
- **GitHub**: [@roco170a](https://github.com/roco170a)
