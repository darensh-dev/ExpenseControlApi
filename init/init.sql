-- Crear la base de datos
CREATE DATABASE expense_control;

GO
-- Usar la base de datos
USE expense_control;

GO
-- Crear la tabla users
CREATE TABLE
    users (
        ID bigint IDENTITY (1, 1) PRIMARY KEY,
        username varchar(150) NOT NULL,
        password VARCHAR(MAX) NOT NULL,
        created_at datetime DEFAULT CURRENT_TIMESTAMP NOT NULL,
        updated_at datetime DEFAULT CURRENT_TIMESTAMP NOT NULL,
        register_state int DEFAULT 1 NOT NULL
    );

GO