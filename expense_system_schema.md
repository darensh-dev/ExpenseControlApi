# 📄 Database Schema – Expense Control System

**Última actualización:** 2025-05-30

> Este documento describe la estructura de las tablas de la base de datos para el sistema de control de gastos.

## 📘 Tabla: `users`
| Campo         | Tipo           | Descripción                                 |
|---------------|----------------|---------------------------------------------|
| id            | `BIGINT`       | Identificador único del usuario             |
| username      | `VARCHAR(150)` | Nombre de usuario                           |
| password      | `VARCHAR(MAX)` | Contraseña (hash)                           |
| created_at    | `DATETIME`     | Fecha de creación del registro              |
| updated_at    | `DATETIME`     | Última fecha de modificación                |
| deleted_at    | `DATETIME`     | Fecha de eliminación lógica (soft delete)   |

## 📘 Tabla: `fund_types`
| Campo         | Tipo           | Descripción                              |
|---------------|----------------|------------------------------------------|
| id            | `BIGINT`       | Identificador del tipo de fondo          |
| name          | `NVARCHAR(100)`| Nombre del tipo de fondo (Ej: Caja, Banco) |
| created_at    | `DATETIME`     | Fecha de creación                        |
| updated_at    | `DATETIME`     | Última modificación                      |
| deleted_at    | `DATETIME`     | Eliminación lógica                       |

## 💰 Tabla: `monetary_funds`
| Campo         | Tipo            | Descripción                               |
|---------------|-----------------|-------------------------------------------|
| id            | `BIGINT`        | Identificador del fondo                   |
| user_id       | `BIGINT`        | Usuario propietario del fondo             |
| fund_type_id  | `BIGINT`        | Tipo de fondo                             |
| name          | `NVARCHAR(150)` | Nombre del fondo (Ej: Cuenta BAC)         |
| initial_balance | `DECIMAL(18,2)` | Saldo inicial del fondo                  |
| created_at    | `DATETIME`      | Fecha de creación                         |
| updated_at    | `DATETIME`      | Última modificación                       |
| deleted_at    | `DATETIME`      | Eliminación lógica                        |

## 📘 Tabla: `document_types`
| Campo         | Tipo            | Descripción                                 |
|---------------|-----------------|---------------------------------------------|
| id            | `BIGINT`        | Identificador del tipo de documento         |
| name          | `NVARCHAR(100)` | Nombre del tipo (Ej: Factura, Comprobante)  |
| created_at    | `DATETIME`      | Fecha de creación                           |
| updated_at    | `DATETIME`      | Última modificación                         |
| deleted_at    | `DATETIME`      | Eliminación lógica                          |

## 💸 Tabla: `expense_types`
| Campo         | Tipo             | Descripción                                 |
|---------------|------------------|---------------------------------------------|
| id            | `BIGINT`         | Identificador del tipo de gasto             |
| name          | `NVARCHAR(100)`  | Nombre (Ej: Transporte, Alimentos)          |
| code          | `NVARCHAR(50)`   | Código único (generado por el sistema)      |
| description   | `NVARCHAR(255)`  | Descripción opcional del tipo de gasto      |
| created_at    | `DATETIME`       | Fecha de creación                           |
| updated_at    | `DATETIME`       | Última modificación                         |
| deleted_at    | `DATETIME`       | Eliminación lógica                          |

## 📦 Tabla: `expense_headers`
| Campo              | Tipo             | Descripción                                  |
|--------------------|------------------|----------------------------------------------|
| id                 | `BIGINT`         | ID del encabezado del gasto                  |
| user_id            | `BIGINT`         | Usuario que registra el gasto                |
| monetary_fund_id   | `BIGINT`         | Fondo desde el cual se realizó el gasto      |
| document_type_id   | `BIGINT`         | Tipo de documento asociado                   |
| document_other     | `NVARCHAR(150)`  | Texto libre si el tipo de documento es Otro |
| store_name         | `NVARCHAR(150)`  | Nombre del comercio donde se realizó el gasto|
| notes              | `NVARCHAR(255)`  | Observaciones adicionales                    |
| expense_date       | `DATE`           | Fecha del gasto ingresada por el usuario     |
| created_at         | `DATETIME`       | Fecha de creación                            |
| updated_at         | `DATETIME`       | Última modificación                          |
| deleted_at         | `DATETIME`       | Eliminación lógica                           |

## 📑 Tabla: `expense_details`
| Campo              | Tipo           | Descripción                              |
|--------------------|----------------|------------------------------------------|
| id                 | `BIGINT`       | ID del detalle de gasto                  |
| expense_header_id  | `BIGINT`       | Encabezado al que pertenece              |
| expense_type_id    | `BIGINT`       | Tipo de gasto                            |
| amount             | `DECIMAL(18,2)`| Monto del gasto en esa categoría         |
| created_at         | `DATETIME`     | Fecha de creación                        |
| updated_at         | `DATETIME`     | Última modificación                      |
| deleted_at         | `DATETIME`     | Eliminación lógica                       |

## 🏦 Tabla: `deposits`
| Campo              | Tipo           | Descripción                              |
|--------------------|----------------|------------------------------------------|
| id                 | `BIGINT`       | Identificador del depósito               |
| user_id            | `BIGINT`       | Usuario que registra el depósito         |
| monetary_fund_id   | `BIGINT`       | Fondo al que se hizo el depósito         |
| deposit_date       | `DATE`         | Fecha del depósito                       |
| amount             | `DECIMAL(18,2)`| Monto depositado                         |
| created_at         | `DATETIME`     | Fecha de creación                        |
| updated_at         | `DATETIME`     | Última modificación                      |
| deleted_at         | `DATETIME`     | Eliminación lógica                       |

## 📊 Tabla: `budgets`
| Campo              | Tipo           | Descripción                              |
|--------------------|----------------|------------------------------------------|
| id                 | `BIGINT`       | Identificador del presupuesto            |
| user_id            | `BIGINT`       | Usuario que define el presupuesto        |
| expense_type_id    | `BIGINT`       | Tipo de gasto                            |
| budget_month       | `DATE`         | Mes de aplicación del presupuesto        |
| amount             | `DECIMAL(18,2)`| Monto presupuestado                      |
| created_at         | `DATETIME`     | Fecha de creación                        |
| updated_at         | `DATETIME`     | Última modificación                      |
| deleted_at         | `DATETIME`     | Eliminación lógica                       |

## 📎 Tabla: `attachments`
| Campo              | Tipo             | Descripción                               |
|--------------------|------------------|-------------------------------------------|
| id                 | `BIGINT`         | Identificador del archivo                 |
| expense_header_id  | `BIGINT`         | Encabezado al que pertenece el archivo    |
| file_name          | `NVARCHAR(255)`  | Nombre del archivo original               |
| file_url           | `NVARCHAR(1000)` | URL del archivo en S3 u otro storage      |
| content_type       | `NVARCHAR(100)`  | Tipo MIME del archivo                     |
| uploaded_by_user_id| `BIGINT`         | Usuario que cargó el archivo              |
| created_at         | `DATETIME`       | Fecha de carga                            |
| updated_at         | `DATETIME`       | Última modificación                       |
| deleted_at         | `DATETIME`       | Eliminación lógica                        |

## 📋 Tabla: `audit_logs`
| Campo              | Tipo             | Descripción                              |
|--------------------|------------------|------------------------------------------|
| id                 | `BIGINT`         | Identificador del log                    |
| table_name         | `NVARCHAR(100)`  | Nombre de la tabla afectada              |
| record_id          | `BIGINT`         | ID del registro afectado                 |
| action             | `NVARCHAR(20)`   | Tipo de acción: INSERT, UPDATE, DELETE   |
| changed_by_user_id | `BIGINT`         | Usuario que hizo el cambio               |
| changes            | `NVARCHAR(MAX)`  | JSON con los cambios realizados          |
| change_date        | `DATETIME`       | Fecha y hora del cambio                  |
| created_at         | `DATETIME`       | Fecha de creación                        |
| updated_at         | `DATETIME`       | Última modificación                      |
| deleted_at         | `DATETIME`       | Eliminación lógica                       |
