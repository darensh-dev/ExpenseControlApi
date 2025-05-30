# Resumen del Proyecto

Desarrollar un portal web para que una persona pueda controlar sus ingresos y egresos, clasificándolos por fondo monetario (cuentas bancarias o caja chica). El sistema manejará presupuestos, registros de gastos, depósitos, y permitirá consultas y reportes gráficos.

# Estructura del Menú

## Mantenimientos

1. Tipos de Gasto: Categorías como "alimentación", "transporte", etc.
2. Fondos Monetarios: Pueden ser cuentas bancarias o caja chica.

## Movimientos

1. Presupuesto por tipo de gasto: Asignación de monto por mes y tipo de gasto.
2. Registros de gastos: Registro detallado de los gastos reales.
3. Depósitos: Registro de ingresos en cada fondo.
4. Consultas y reportes:

   * Consulta de movimientos (gastos y depósitos) entre fechas.
   * Gráfico comparativo de presupuesto vs ejecución.

# Detalles Funcionales

1. Mantenimiento de Tipos de Gasto

---

* El sistema genera automáticamente un código para cada nuevo tipo de gasto.

2. Mantenimiento de Fondos Monetarios

---

* Registro de fondos, que pueden ser cuentas bancarias o caja chica.

3. Presupuesto por Usuario y Tipo de Gasto

---

* Registro del presupuesto mensual por tipo de gasto.
* Se solicita el mes específico al registrar.

4. Registro de Gastos (Encabezado y Detalle)

---

* Registro transaccional: no se guarda el encabezado sin detalle.
* Encabezado incluye:

  * Fecha
  * Fondo Monetario
  * Observaciones
  * Nombre del Comercio
  * Tipo de Documento (Comprobante, Factura, Otro)
* Detalle incluye:

  * Tipo de Gasto
  * Monto (pueden haber varios tipos por documento)
* Validación:

  * Verifica si se supera el presupuesto mensual por tipo de gasto.
  * Muestra alerta con el monto presupuestado y el sobregiro si aplica.

5. Registro de Depósitos

---

* Se ingresan:

  * Fecha
  * Fondo Monetario
  * Monto

6. Consulta de Movimientos

---

* Selección de un rango de fechas.
* Visualización de todos los movimientos (gastos y depósitos).

7. Gráfico Comparativo Presupuesto vs Ejecución

---

* Selección de un rango de fechas.
* Gráfico de barras comparando lo presupuestado vs lo ejecutado por tipo de gasto.
