--
-- PostgreSQL database dump
--

-- Dumped from database version 16.9
-- Dumped by pg_dump version 16.9

-- Started on 2025-10-14 07:47:59

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 4910 (class 1262 OID 42476)
-- Name: lojaapi; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE lojaapi WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Portuguese_Brazil.1252';


ALTER DATABASE lojaapi OWNER TO postgres;

\connect lojaapi

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 4 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: pg_database_owner
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO pg_database_owner;

--
-- TOC entry 4911 (class 0 OID 0)
-- Dependencies: 4
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: pg_database_owner
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 220 (class 1259 OID 42498)
-- Name: TB_CATEGORIAS; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."TB_CATEGORIAS" (
    id_categoria integer NOT NULL,
    descricao character varying(150) NOT NULL,
    ativo boolean DEFAULT true NOT NULL
);


ALTER TABLE public."TB_CATEGORIAS" OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 42497)
-- Name: TB_CATEGORIA_id_categoria_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."TB_CATEGORIA_id_categoria_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."TB_CATEGORIA_id_categoria_seq" OWNER TO postgres;

--
-- TOC entry 4912 (class 0 OID 0)
-- Dependencies: 219
-- Name: TB_CATEGORIA_id_categoria_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."TB_CATEGORIA_id_categoria_seq" OWNED BY public."TB_CATEGORIAS".id_categoria;


--
-- TOC entry 216 (class 1259 OID 42478)
-- Name: TB_CLIENTES; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."TB_CLIENTES" (
    id_cliente integer NOT NULL,
    nome_cliente character varying(150) NOT NULL,
    email_cliente character varying(150) NOT NULL,
    ativo boolean DEFAULT true NOT NULL,
    data_cadastro timestamp with time zone NOT NULL
);


ALTER TABLE public."TB_CLIENTES" OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 42477)
-- Name: TB_CLIENTES_id_cliente_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."TB_CLIENTES_id_cliente_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."TB_CLIENTES_id_cliente_seq" OWNER TO postgres;

--
-- TOC entry 4913 (class 0 OID 0)
-- Dependencies: 215
-- Name: TB_CLIENTES_id_cliente_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."TB_CLIENTES_id_cliente_seq" OWNED BY public."TB_CLIENTES".id_cliente;


--
-- TOC entry 218 (class 1259 OID 42488)
-- Name: TB_PRODUTOS; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."TB_PRODUTOS" (
    id_produto integer NOT NULL,
    descricao character varying(150) NOT NULL,
    valor numeric(20,4) DEFAULT 0.00 NOT NULL,
    estoque numeric(20,4) DEFAULT 0.00 NOT NULL,
    ativo boolean DEFAULT true NOT NULL,
    id_categoria integer NOT NULL
);


ALTER TABLE public."TB_PRODUTOS" OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 42487)
-- Name: TB_PRODUTOS_id_produto_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."TB_PRODUTOS_id_produto_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."TB_PRODUTOS_id_produto_seq" OWNER TO postgres;

--
-- TOC entry 4914 (class 0 OID 0)
-- Dependencies: 217
-- Name: TB_PRODUTOS_id_produto_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."TB_PRODUTOS_id_produto_seq" OWNED BY public."TB_PRODUTOS".id_produto;


--
-- TOC entry 4751 (class 2604 OID 42501)
-- Name: TB_CATEGORIAS id_categoria; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TB_CATEGORIAS" ALTER COLUMN id_categoria SET DEFAULT nextval('public."TB_CATEGORIA_id_categoria_seq"'::regclass);


--
-- TOC entry 4745 (class 2604 OID 42481)
-- Name: TB_CLIENTES id_cliente; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TB_CLIENTES" ALTER COLUMN id_cliente SET DEFAULT nextval('public."TB_CLIENTES_id_cliente_seq"'::regclass);


--
-- TOC entry 4747 (class 2604 OID 42491)
-- Name: TB_PRODUTOS id_produto; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TB_PRODUTOS" ALTER COLUMN id_produto SET DEFAULT nextval('public."TB_PRODUTOS_id_produto_seq"'::regclass);


--
-- TOC entry 4760 (class 2606 OID 42504)
-- Name: TB_CATEGORIAS TB_CATEGORIA_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TB_CATEGORIAS"
    ADD CONSTRAINT "TB_CATEGORIA_pkey" PRIMARY KEY (id_categoria);


--
-- TOC entry 4754 (class 2606 OID 42486)
-- Name: TB_CLIENTES TB_CLIENTES_email_cliente_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TB_CLIENTES"
    ADD CONSTRAINT "TB_CLIENTES_email_cliente_key" UNIQUE (email_cliente);


--
-- TOC entry 4756 (class 2606 OID 42484)
-- Name: TB_CLIENTES TB_CLIENTES_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TB_CLIENTES"
    ADD CONSTRAINT "TB_CLIENTES_pkey" PRIMARY KEY (id_cliente);


--
-- TOC entry 4758 (class 2606 OID 42496)
-- Name: TB_PRODUTOS TB_PRODUTOS_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TB_PRODUTOS"
    ADD CONSTRAINT "TB_PRODUTOS_pkey" PRIMARY KEY (id_produto);


--
-- TOC entry 4761 (class 2606 OID 42507)
-- Name: TB_PRODUTOS fk_tb_produtos_categoria_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TB_PRODUTOS"
    ADD CONSTRAINT fk_tb_produtos_categoria_id FOREIGN KEY (id_categoria) REFERENCES public."TB_CATEGORIAS"(id_categoria) NOT VALID;


-- Completed on 2025-10-14 07:47:59

--
-- PostgreSQL database dump complete
--

