# ENUNCIADO

Debe crear un portal WEB que permita llevar el control de gastos de una persona.
El objetivo es llevar el control de ingresos y egresos por fondo monetario.

## ESPECTATIVA DEL MENU

### Mantenimientos:

Tipos de Gasto
Fondo Monetario

### Movimientos

- Presupuesto por tipo de gasto
- Registros de gastos
- Depósitos
- Consultas y Reportes
- Consulta de movimientos
- Gráfico Comparativo de Presupuesto y Ejecución

## PARAMETROS:

### Mantenimiento de tipo de gastos:

- Debe calcular el código siguiente del gasto de forma automática.

### Mantenimiento de Fondo Monetario

- Pueden ser cuentas bancarias o fondos de caja menuda

### Movimiento presupuesto por usuario y tipo de gasto:

- Debe solicitar un mes específico para poder indicar el gasto y presupuesto

### Movimiento Registro de gastos: (Encabezado y Detalle)

- Debe manejar en transacción el encabezado y detalle.  
- No se guarda el encabezado sin su detalle  
- En el encabezado debe poder ingresar los siguientes datos:
- Fecha, Fondo Monetario, Observaciones, Nombre de Comercio, Tipo de Documento (Comprobante, Factura, Otro).  
- En el detalle, debe colocar el Tipo de Gasto y el monto (ya que en una misma factura pueden venir diferentes gastos).
- Al dar GUARDAR en un registro de gastos. El sistema debe validar si se está sobregirando su presupuesto en algún tipo de gasto y enviara un alerta indicando que su presupuesto esta sobregirado en X gastos. Indicando el monto presupuestado y el monto que se está sobregirando.

#### Registro de depósitos:

Debe ingresar Fecha, Fondo Monetario, Monto.

### Consulta de movimientos.

Solicitar un rango de fechas y poder visualizar todos los movimientos (tanto de depósitos como gastos).
Gráfico comparativo de presupuestos y ejecución: debe solicitar un rango de fechas y el sistema debe mostrar un grafico tipo barras de lo presupuestado y ejecutado por tipo de gasto


🧩 Servicios por Módulo
🔧 MANTENIMIENTOS
1. Tipos de Gasto
GET /expense-types – Listar tipos de gasto.

POST /expense-types – Crear nuevo tipo de gasto (código generado automáticamente).

PUT /expense-types/{id} – Editar tipo de gasto.

DELETE /expense-types/{id} – Eliminar tipo de gasto.

2. Fondos Monetarios
GET /funds – Listar fondos monetarios.

POST /funds – Crear fondo monetario (cuenta bancaria o caja chica).

PUT /funds/{id} – Editar fondo monetario.

DELETE /funds/{id} – Eliminar fondo monetario.

💼 MOVIMIENTOS
3. Presupuesto por tipo de gasto y mes
GET /budgets?month=YYYY-MM – Obtener presupuestos por mes.

POST /budgets – Crear o actualizar presupuesto (requiere: usuario, tipo de gasto, mes, monto).

DELETE /budgets/{id} – Eliminar presupuesto.

4. Registro de Gastos (Encabezado y Detalle - Transaccional)
GET /expenses?from=YYYY-MM-DD&to=YYYY-MM-DD – Listar gastos por rango de fechas.

POST /expenses – Crear gasto con encabezado y detalles.
⚠️ Debe incluir validación de sobregiro en presupuesto.

GET /expenses/{id} – Ver gasto específico (con detalles).

DELETE /expenses/{id} – Eliminar gasto completo.

Datos requeridos:
Encabezado: Fecha, Fondo, Observaciones, Comercio, Tipo de Documento

Detalle: Tipo de Gasto, Monto (1 o más)

5. Registro de Depósitos
GET /deposits?from=YYYY-MM-DD&to=YYYY-MM-DD – Listar depósitos por fecha.

POST /deposits – Crear depósito (requiere: fecha, fondo, monto).

DELETE /deposits/{id} – Eliminar depósito.

📊 CONSULTAS Y REPORTES
6. Consulta de movimientos
GET /movements?from=YYYY-MM-DD&to=YYYY-MM-DD – Lista todos los movimientos (gastos y depósitos) en un rango de fechas.

7. Gráfico Comparativo Presupuesto vs Ejecución
GET /reports/budget-vs-execution?from=YYYY-MM-DD&to=YYYY-MM-DD
– Devuelve datos agregados por tipo de gasto para graficar:
{ type: 'Transporte', budgeted: 100000, spent: 130000 }

✅ Extras recomendados (no mencionados pero útiles)
Autenticación de usuario:

POST /auth/login

POST /auth/register

Usuarios (si se maneja multicuenta):

GET /users/{id}

PUT /users/{id}