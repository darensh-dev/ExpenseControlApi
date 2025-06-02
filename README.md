# Documentación del Proyecto de Control de Gastos Personales

## Tabla de Contenido

1. [Resumen del Proyecto](#resumen-del-proyecto)
2. [Arquitectura](#arquitectura)
3. [Tecnologías Utilizadas](#tecnologías-utilizadas)
4. [Estructura de Carpetas](#estructura-de-carpetas)
5. [Módulos Principales](#módulos-principales)
6. [Base de Datos](#base-de-datos)
7. [Endpoints de la API](#endpoints-de-la-api)
8. [Despliegue](#despliegue)
9. [Consideraciones de Seguridad](#consideraciones-de-seguridad)
10. [Próximos Pasos](#próximos-pasos)

---

## Resumen del Proyecto

Este sistema tiene como objetivo permitir a los usuarios controlar sus gastos personales, clasificarlos por tipo, asignar presupuestos mensuales, registrar depósitos y visualizar reportes comparativos entre lo presupuestado y lo ejecutado.

---

## Arquitectura

Se implementó una arquitectura **Clean Architecture** (también conocida como Arquitectura Hexagonal), que permite una alta cohesión y bajo acoplamiento entre componentes. Esta arquitectura está compuesta por:

- **Capa de Dominio**: Define las entidades y las reglas de negocio puras.
- **Capa de Aplicación**: Contiene los casos de uso y orquesta la lógica del negocio.
- **Capa de Infraestructura**: Implementa detalles técnicos como la persistencia y servicios externos.
- **Capa de Presentación / Entrada**: Implementa los controladores y expone los endpoints.

Esta separación permite:

- Mayor mantenibilidad.
- Independencia de frameworks.
- Facilidad para pruebas unitarias.

---

## Tecnologías Utilizadas

| Componente              | Tecnología                            |
| ----------------------- | ------------------------------------- |
| Lenguaje principal      | C# .NET 8                             |
| Framework backend       | ASP.NET Core Web API                  |
| ORM                     | Entity Framework Core                 |
| Base de datos           | SQL Server                            |
| Autenticación           | JWT (JSON Web Tokens)                 |
| Almacenamiento archivos | Amazon S3 (opcional en esta fase)     |
| Infraestructura         | Azure / AWS / (según despliegue real) |
| Frontend (opcional)     | Angular / React / u otro              |

---

## Estructura de Carpetas

```txt
src/
├── Domain/                 # Entidades y contratos (interfaces)
├── Application/            # Casos de uso y DTOs
├── Infrastructure/         # EF Core, Repositorios, Configuración
├── WebApi/                 # Controladores, Middlewares, Configuración
```

---

## Módulos Principales

### Usuarios

- Registro y autenticación de usuarios.
- Soporte para roles si se amplía en el futuro.

### Fondos Monetarios (Monetary Funds)

- Cada usuario puede definir múltiples cuentas o fondos.
- Asociadas a tipos de fondos personalizados.

### Tipos de Documentos y Tipos de Gastos

- El sistema permite crear tipos genéricos por usuario.
- Separación clara entre tipos de gasto y tipo de documento.

### Presupuestos

- Los usuarios pueden definir presupuestos mensuales por tipo de gasto.
- Se calculan automáticamente los ejecutados para reportes.

### Gastos

- Registro de encabezado y detalle.
- Se pueden adjuntar documentos como comprobantes.

### Depósitos

- Registro de ingresos a fondos.

### Reportes

- Movimientos por rango de fecha.
- Gráfico comparativo de presupuesto vs ejecución.

---

## Base de Datos

Todas las tablas incluyen campos comunes:

- `created_at`, `updated_at`, `deleted_at`

Tablas principales:

- `users`
- `monetary_funds`
- `fund_types`
- `expense_headers`, `expense_details`
- `expense_types`
- `document_types`
- `deposits`
- `budgets`
- `attachments`
- `audit_logs`

---

## Endpoints de la API

- `POST /api/auth/register`
- `POST /api/auth/login`
- `GET /api/funds`
- `POST /api/funds`
- `GET /api/expenses?start=2025-01-01&end=2025-01-31`
- `POST /api/expenses`
- `GET /api/reports/budget-vs-execution`

Y muchos más, estructurados por entidad.

---

## Despliegue

- La app ha sido desplegada en la nube.
- Usa SQL Server como backend.
- Está protegida mediante JWT.
- El almacenamiento de archivos puede conectarse a S3.
- Logs centralizados y tracking de errores pueden integrarse con Application Insights o CloudWatch.

---

## Consideraciones de Seguridad

- Autenticación vía JWT.
- Validación de inputs con DTOs y anotaciones.
- Uso de soft delete (`deleted_at`) en vez de borrar registros.
- Los recursos están filtrados por `user_id` para seguridad multiusuario.

---

## Próximos Pasos

- Soporte para múltiples roles (admin, usuario, etc.).
- Exportación de reportes en PDF o Excel.
- Sincronización con apps bancarias.
- Notificaciones por sobrepasar presupuestos.
- Interfaz web o móvil.

---

¿Dudas, sugerencias o mejoras? ¡Estás listo para seguir iterando!

# ExpenseControlApi

The project was generated using the [Clean.Architecture.Solution.Template](https://github.com/jasontaylordev/CleanArchitecture) version 9.0.10.

## Build

Run `dotnet build -tl` to build the solution.

## Run

To run the web application:

```bash
cd .\src\Web\
dotnet watch run
```

Navigate to https://localhost:5001. The application will automatically reload if you change any of the source files.

## Code Styles & Formatting

The template includes [EditorConfig](https://editorconfig.org/) support to help maintain consistent coding styles for multiple developers working on the same project across various editors and IDEs. The **.editorconfig** file defines the coding styles applicable to this solution.

## Code Scaffolding

The template includes support to scaffold new commands and queries.

Start in the `.\src\Application\` folder.

Create a new command:

```
dotnet new ca-usecase --name CreateTodoList --feature-name TodoLists --usecase-type command --return-type int
```

Create a new query:

```
dotnet new ca-usecase -n GetTodos -fn TodoLists -ut query -rt TodosVm
```

If you encounter the error _"No templates or subcommands found matching: 'ca-usecase'."_, install the template and try again:

```bash
dotnet new install Clean.Architecture.Solution.Template::9.0.10
```

## Test

The solution contains unit, integration, functional, and acceptance tests.

To run the unit, integration, and functional tests (excluding acceptance tests):

```bash
dotnet test --filter "FullyQualifiedName!~AcceptanceTests"
```

To run the acceptance tests, first start the application:

```bash
cd .\src\Web\
dotnet run
```

Then, in a new console, run the tests:

```bash
cd .\src\Web\
dotnet test
```

## Help

To learn more about the template go to the [project website](https://github.com/jasontaylordev/CleanArchitecture). Here you can find additional guidance, request new features, report a bug, and discuss the template with other users.

dotnet ef dbcontext scaffold "Server=localhost;Database=expense_control;User Id=sa;Password=1StrongPwd\*1;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models --schema dbo --force
