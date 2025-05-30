# ENUNCIADO

Debe crear un portal WEB que permita llevar el control de gastos de una persona.
El objetivo es llevar el control de ingresos y egresos por fondo monetario.

## ESPECTATIVA DEL MENU

### Mantenimientos:

Tipos de Gasto
Fondo Monetario

### Movimientos

Presupuesto por tipo de gasto
Registros de gastos
Depósitos
Consultas y Reportes
Consulta de movimientos
Gráfico Comparativo de Presupuesto y Ejecución

## PARAMETROS:

### Mantenimiento de tipo de gastos:

Debe calcular el código siguiente del gasto de forma automática.

### Mantenimiento de Fondo Monetario

Pueden ser cuentas bancarias o fondos de caja menuda

### Movimiento presupuesto por usuario y tipo de gasto:

Debe solicitar un mes específico para poder indicar el gasto y presupuesto

### Movimiento Registro de gastos: (Encabezado y Detalle)

Debe manejar en transacción el encabezado y detalle.  
No se guarda el encabezado sin su detalle  
En el encabezado debe poder ingresar los siguientes datos:
Fecha, Fondo Monetario, Observaciones, Nombre de Comercio, Tipo de Documento (Comprobante, Factura, Otro).  
En el detalle, debe colocar el Tipo de Gasto y el monto (ya que en una misma factura pueden venir diferentes gastos).
Al dar GUARDAR en un registro de gastos. El sistema debe validar si se está sobregirando su presupuesto en algún tipo de gasto y enviara un alerta indicando que su presupuesto esta sobregirado en X gastos. Indicando el monto presupuestado y el monto que se está sobregirando.

#### Registro de depósitos:

Debe ingresar Fecha, Fondo Monetario, Monto.

### Consulta de movimientos.

Solicitar un rango de fechas y poder visualizar todos los movimientos (tanto de depósitos como gastos).
Gráfico comparativo de presupuestos y ejecución: debe solicitar un rango de fechas y el sistema debe mostrar un grafico tipo barras de lo presupuestado y ejecutado por tipo de gasto
