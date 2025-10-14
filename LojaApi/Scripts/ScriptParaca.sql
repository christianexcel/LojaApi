-- Script para criar as tabelas com relacionamentos 
CREATE TABLE "TB_CATEGORIAS" ( 
    "id_categoria" SERIAL PRIMARY KEY, 
    "nome_categoria" VARCHAR(100) NOT NULL UNIQUE 
); 
CREATE TABLE "TB_PRODUTOS" ( 
    "id_produto" SERIAL PRIMARY KEY, 
    "nome_produto" VARCHAR(150) NOT NULL, 
    "preco_produto" DECIMAL(10, 2) NOT NULL, 
    "estoque_produto" INT NOT NULL, 
    "id_categoria" INT NOT NULL, 
    CONSTRAINT "fk_categoria" FOREIGN KEY ("id_categoria") REFERENCES 
"TB_CATEGORIAS"("id_categoria") 
); 
INSERT INTO "TB_CATEGORIAS" ("nome_categoria") VALUES ('Eletrônicos'), ('Livros'), 
('Vestuário'); 
INSERT INTO "TB_PRODUTOS" ("nome_produto", "preco_produto", "estoque_produto", 
"id_categoria") VALUES 
('Smartphone XYZ', 1999.99, 50, 1), 
('Notebook Gamer ABC', 7500.00, 15, 1), 
('O Senhor dos Anéis', 120.50, 100, 2), 
('Camiseta Básica', 49.90, 200, 3); 

-- Script do "DBA" 
-- Table: public.TB_CLIENTES

-- DROP TABLE IF EXISTS public."TB_CLIENTES";

CREATE TABLE IF NOT EXISTS public."TB_CLIENTES"
(
    id_cliente SERIAL PRIMARY KEY,
    nome_cliente character varying(150) COLLATE pg_catalog."default" NOT NULL,
    email_cliente character varying(150) COLLATE pg_catalog."default" NOT NULL,
    ativo boolean NOT NULL DEFAULT true,
    data_cadastro timestamp with time zone NOT NULL,
    CONSTRAINT "TB_CLIENTES_pkey" PRIMARY KEY (id_cliente),
    CONSTRAINT "TB_CLIENTES_email_cliente_key" UNIQUE (email_cliente)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."TB_CLIENTES"
    OWNER to postgres;
-- Inserindo alguns dados iniciais 
INSERT INTO "TB_CLIENTES" ("nome_cliente", "email_cliente", "ativo", "data_cadastro") 
VALUES 
('ALICE SILVA', 'alice@mail.com', true, NOW()), 
('BRUNO COSTA', 'bruno@mail.com', true, NOW()), 
('CARLOS SANTOS', 'carlos@mail.com', false, NOW()); 