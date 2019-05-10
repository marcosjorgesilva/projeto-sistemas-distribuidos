SET LANGUAGE 'brazilian'
USE master;

------------------------------------------------------------

IF DB_ID('MELOCHICOUT') IS NOT NULL
   DROP DATABASE MELOCHICOUT;
CREATE DATABASE MELOCHICOUT;
GO
USE MELOCHICOUT;

------------------------------------------------------------

CREATE TABLE usuario (
id_usuario			INTEGER			NOT NULL	PRIMARY KEY,
tipo_usuario		CHAR(3)			NOT NULL,
nome				VARCHAR(150)	NOT NULL,
login				VARCHAR(50)		NOT NULL,
senha				VARCHAR(20)		NOT NULL,
cpf					VARCHAR(11)		NOT NULL,
email				VARCHAR(150)	NOT NULL,
data_nascimento		DATE			NOT NULL,
tel_celular			VARCHAR(12)		NOT NULL,
tel_fixo			VARCHAR(12)
)

------------------------------------------------------------

CREATE TABLE endereco (
id_endereco		VARCHAR(10)		NOT NULL	PRIMARY KEY,
id_usuario		INTEGER			NOT NULL,
logradouro		VARCHAR(150)	NOT NULL,
numero			INTEGER			NOT NULL,
cidade			VARCHAR(20)		NOT NULL,
bairro			VARCHAR(50)		NOT NULL,
estado			CHAR(2)			NOT NULL,
cep				INTEGER			NOT NULL,
complemento		VARCHAR(150),
referencia		VARCHAR(150),
FOREIGN KEY(id_usuario) REFERENCES usuario(id_usuario)
)

------------------------------------------------------------

CREATE TABLE formaPagamento (
id_formaPagamento	INTEGER		NOT NULL	PRIMARY KEY,
descricao_fp		VARCHAR(50)	NOT NULL,
tipo_fp				VARCHAR(50)	NOT NULL
)

------------------------------------------------------------

CREATE TABLE pedido (
id_pedido				INTEGER		NOT NULL	PRIMARY KEY,
id_usuario				INTEGER		NOT NULL,
id_formaPagamento		INTEGER		NOT NULL,
data_pedido				DATETIME	NOT NULL,
data_entrega			DATETIME	NOT NULL,
valor_pedido			FLOAT		NOT NULL,
FOREIGN KEY(id_usuario) REFERENCES usuario(id_usuario),
FOREIGN KEY(id_formaPagamento) REFERENCES formaPagamento(id_formaPagamento)
)

------------------------------------------------------------

CREATE TABLE categoria (
id_categoria	INTEGER		NOT NULL	PRIMARY KEY,
tipo_categoria	VARCHAR(50)	NOT NULL
)

------------------------------------------------------------

CREATE TABLE produto (
id_produto		INTEGER			NOT NULL	PRIMARY KEY,
id_categoria	INTEGER			NOT NULL,
nome			VARCHAR(150)	NOT NULL,
valor_produto	FLOAT			NOT NULL,
estoque			INTEGER			NOT NULL,
tamanho			CHAR(3),
FOREIGN KEY(id_categoria) REFERENCES categoria (id_categoria)
)

------------------------------------------------------------

CREATE TABLE itensPedido (
id_pedido	INTEGER		NOT NULL,
id_produto	INTEGER		NOT NULL,
quantidade	INTEGER		NOT NULL,
valor_itens FLOAT		NOT NULL,
descricao	VARCHAR(150),
FOREIGN KEY(id_pedido) REFERENCES pedido(id_pedido),
FOREIGN KEY(id_produto) REFERENCES produto(id_produto)
)