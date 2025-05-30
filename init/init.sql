CREATE DATABASE expense_control;

GO
USE expense_control;

GO
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
INSERT INTO
    expense_control.dbo.users (
        ID,
        username,
        password,
        created_at,
        updated_at,
        register_state
    )
VALUES
    (
        1,
        N'admin',
        N'$2a$11$8SUWfm5lByTEotxIteP2suWhXGyni0zVNFEQFhGfDDzHHOE8PL4PS',
        N'2025-05-29 16:31:04.000',
        N'2025-05-29 21:31:08.887',
        1
    );

GO