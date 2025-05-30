CREATE DATABASE expense_control;

GO
USE expense_control;

GO
CREATE TABLE
    users (
        id BIGINT IDENTITY (1, 1),
        username NVARCHAR (150) NOT NULL,
        password NVARCHAR (MAX) NOT NULL,
        created_at DATETIME NOT NULL DEFAULT GETDATE (),
        updated_at DATETIME,
        deleted_at DATETIME,
        CONSTRAINT users__pk PRIMARY KEY (id)
    );

GO
CREATE TABLE
    document_types (
        id INT IDENTITY (1, 1),
        name NVARCHAR (100) NOT NULL,
        created_at DATETIME NOT NULL DEFAULT GETDATE (),
        updated_at DATETIME,
        deleted_at DATETIME,
        CONSTRAINT document_types__pk PRIMARY KEY (id)
    );

GO
CREATE TABLE
    fund_types (
        id INT IDENTITY (1, 1),
        name NVARCHAR (100) NOT NULL,
        created_at DATETIME NOT NULL DEFAULT GETDATE (),
        updated_at DATETIME,
        deleted_at DATETIME,
        CONSTRAINT fund_types__pk PRIMARY KEY (id)
    );

GO
CREATE TABLE
    monetary_funds (
        id BIGINT IDENTITY (1, 1),
        user_id BIGINT NOT NULL,
        fund_type_id INT NOT NULL,
        name NVARCHAR (150) NOT NULL,
        initial_balance DECIMAL(18, 2) NOT NULL DEFAULT 0,
        created_at DATETIME NOT NULL DEFAULT GETDATE (),
        updated_at DATETIME,
        deleted_at DATETIME,
        CONSTRAINT monetary_funds__pk PRIMARY KEY (id),
        CONSTRAINT monetary_funds__user_id_fk FOREIGN KEY (user_id) REFERENCES dbo.users (id),
        CONSTRAINT monetary_funds__fund_type_id_fk FOREIGN KEY (fund_type_id) REFERENCES dbo.fund_types (id)
    );

GO
CREATE TABLE
    expense_types (
        id INT IDENTITY (1, 1),
        code NVARCHAR (10) NOT NULL,
        name NVARCHAR (150) NOT NULL,
        description NVARCHAR (500),
        created_at DATETIME NOT NULL DEFAULT GETDATE (),
        updated_at DATETIME,
        deleted_at DATETIME,
        CONSTRAINT expense_types__pk PRIMARY KEY (id),
        CONSTRAINT expense_types__code_uq UNIQUE (code)
    );

GO
CREATE TABLE
    budgets (
        id BIGINT IDENTITY (1, 1),
        user_id BIGINT NOT NULL,
        expense_type_id INT NOT NULL,
        month DATE NOT NULL,
        amount DECIMAL(18, 2) NOT NULL,
        created_at DATETIME NOT NULL DEFAULT GETDATE (),
        updated_at DATETIME,
        deleted_at DATETIME,
        CONSTRAINT budgets__pk PRIMARY KEY (id),
        CONSTRAINT budgets__user_id_fk FOREIGN KEY (user_id) REFERENCES dbo.users (id),
        CONSTRAINT budgets__expense_type_id_fk FOREIGN KEY (expense_type_id) REFERENCES dbo.expense_types (id)
    );

GO
CREATE TABLE
    expense_headers (
        id BIGINT IDENTITY (1, 1),
        user_id BIGINT NOT NULL,
        monetary_fund_id BIGINT NOT NULL,
        date DATE NOT NULL,
        merchant_name NVARCHAR (200),
        document_type_id INT NOT NULL,
        other_document_type_text NVARCHAR (200),
        notes NVARCHAR (1000),
        created_at DATETIME NOT NULL DEFAULT GETDATE (),
        updated_at DATETIME,
        deleted_at DATETIME,
        CONSTRAINT expense_headers__pk PRIMARY KEY (id),
        CONSTRAINT expense_headers__user_id_fk FOREIGN KEY (user_id) REFERENCES dbo.users (id),
        CONSTRAINT expense_headers__monetary_fund_id_fk FOREIGN KEY (monetary_fund_id) REFERENCES dbo.monetary_funds (id),
        CONSTRAINT expense_headers__document_type_id_fk FOREIGN KEY (document_type_id) REFERENCES dbo.document_types (id)
    );

GO
CREATE TABLE
    attachments (
        id BIGINT IDENTITY (1, 1),
        expense_header_id BIGINT NOT NULL,
        file_name NVARCHAR (255) NOT NULL,
        file_url NVARCHAR (1000) NOT NULL,
        content_type NVARCHAR (100),
        uploaded_by_user_id BIGINT NOT NULL,
        created_at DATETIME NOT NULL DEFAULT GETDATE (),
        updated_at DATETIME,
        deleted_at DATETIME,
        CONSTRAINT attachments__pk PRIMARY KEY (id),
        CONSTRAINT attachments__expense_header_id_fk FOREIGN KEY (expense_header_id) REFERENCES dbo.expense_headers (id),
        CONSTRAINT attachments__uploaded_by_user_id_fk FOREIGN KEY (uploaded_by_user_id) REFERENCES dbo.users (id)
    );

GO
CREATE TABLE
    expense_details (
        id BIGINT IDENTITY (1, 1),
        expense_header_id BIGINT NOT NULL,
        expense_type_id INT NOT NULL,
        amount DECIMAL(18, 2) NOT NULL,
        created_at DATETIME NOT NULL DEFAULT GETDATE (),
        updated_at DATETIME,
        deleted_at DATETIME,
        CONSTRAINT expense_details__pk PRIMARY KEY (id),
        CONSTRAINT expense_details__expense_header_id_fk FOREIGN KEY (expense_header_id) REFERENCES dbo.expense_headers (id),
        CONSTRAINT expense_details__expense_type_id_fk FOREIGN KEY (expense_type_id) REFERENCES dbo.expense_types (id)
    );

GO
CREATE TABLE
    deposits (
        id BIGINT IDENTITY (1, 1),
        user_id BIGINT NOT NULL,
        monetary_fund_id BIGINT NOT NULL,
        date DATE NOT NULL,
        amount DECIMAL(18, 2) NOT NULL,
        created_at DATETIME NOT NULL DEFAULT GETDATE (),
        updated_at DATETIME,
        deleted_at DATETIME,
        CONSTRAINT deposits__pk PRIMARY KEY (id),
        CONSTRAINT deposits__user_id_fk FOREIGN KEY (user_id) REFERENCES dbo.users (id),
        CONSTRAINT deposits__monetary_fund_id_fk FOREIGN KEY (monetary_fund_id) REFERENCES dbo.monetary_funds (id)
    );

GO
CREATE TABLE
    audit_logs (
        id BIGINT IDENTITY (1, 1),
        table_name NVARCHAR (100) NOT NULL,
        record_id BIGINT NOT NULL,
        action NVARCHAR (20) NOT NULL,
        changed_by_user_id BIGINT,
        changes NVARCHAR (MAX),
        change_date DATETIME NOT NULL DEFAULT GETDATE (),
        created_at DATETIME NOT NULL DEFAULT GETDATE (),
        updated_at DATETIME,
        deleted_at DATETIME,
        CONSTRAINT audit_logs__pk PRIMARY KEY (id),
        CONSTRAINT audit_logs__changed_by_user_id_fk FOREIGN KEY (changed_by_user_id) REFERENCES dbo.users (id),
        CONSTRAINT audit_logs__action_ck CHECK (action IN ('INSERT', 'UPDATE', 'DELETE'))
    );

GO
CREATE TABLE
    login_log (
        id BIGINT IDENTITY (1, 1),
        user_id BIGINT NOT NULL,
        token TEXT NOT NULL,
        ip VARCHAR(30),
        created_at DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
        CONSTRAINT login_log__pk PRIMARY KEY (id)
    );

GO
INSERT INTO
    expense_control.dbo.users (username, password)
VALUES
    (
        N'admin',
        N'$2a$11$8SUWfm5lByTEotxIteP2suWhXGyni0zVNFEQFhGfDDzHHOE8PL4PS'
    );

GO
INSERT INTO
    document_types (name, created_at)
VALUES
    (N'Invoice', GETDATE ()),
    (N'Receipt', GETDATE ()),
    (N'Other', GETDATE ());

GO
INSERT INTO
    fund_types (name, created_at)
VALUES
    (N'Bank Account', GETDATE ()),
    (N'Petty Cash', GETDATE ());