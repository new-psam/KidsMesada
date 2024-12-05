CREATE DATABASE kidsmesada
GO

use kidsmesada
go

CREATE TABLE pais(
	[idPais] UNIQUEIDENTIFIER NOT NULL,
	[nome] NVARCHAR(120) NOT NULL,
	[email] NVARCHAR(180) NOT NULL,
	[senha] NVARCHAR(40) NOT NULL,
	[celular] NVARCHAR(30) NOT NULL
	CONSTRAINT [PK_pais] PRIMARY KEY ([idPais])
)
go

ALTER TABLE [pais]
 ADD CONSTRAINT [uc_pais_email] UNIQUE ([email])
ALTER TABLE [pais]
	ADD CONSTRAINT[uc_pais_celular] UNIQUE([celular])
go



insert into [pais] values(
	NEWID(),
	'marcelino', 
	'marcelino@gmail',
	'senha',
	'84372957'
) 

select * from pais

CREATE TABLE [filhos](
	[idFilhos] UNIQUEIDENTIFIER not null,
	[nome] NVARCHAR(120) NOT NULL,
	[userName] NVARCHAR(50) NOT NULL,
	[data_nascimento] DATETIME NOT NULL,
	[senha] NVARCHAR(40) NOT NULL,
	[celular] NVARCHAR(30),
	[total_pontos] INT DEFAULT 0,
	[saldo_dinheiro] MONEY DEFAULT 0.00,
	[id_pais] uniqueidentifier NOT NULL,
	CONSTRAINT [pk_filhos] PRIMARY KEY([idFilhos]),
		CONSTRAINT [FK_filhos_pais] FOREIGN KEY([id_pais]) REFERENCES [pais] ([idPais])
)

ALTER TABLE [filhos]
 ADD CONSTRAINT [uc_filhos_userName] UNIQUE ([userName])

go

SELECT PAIS.*, FILHOS.* FROM PAIS
INNER JOIN filhos
ON IDPAIS = ID_PAIS
GO

SELECT * FROM PAIS
GO

/* TESTANDO - UNIQUE  DA TABELA PAIS */
INSERT INTO PAIS VALUES(NEWID(), 'RAUL', 'marcelinops@gmail.com', 'sila', '84372957')
/*Violação da restrição UNIQUE KEY 'uc_pais_celular'. Não é possível inserir a chave duplicada no objeto 'dbo.pais'.
 O valor de chave duplicada é (84372957).*/
INSERT INTO PAIS VALUES(NEWID(), 'RAUL', 'raul@gmail.com', 'sila', '84372957')
/*Violação da restrição UNIQUE KEY 'uc_pais_celular'. Não é possível inserir a chave duplicada no objeto 'dbo.pais'.
 O valor de chave duplicada é (84372957).*/
INSERT INTO PAIS VALUES(NEWID(), 'RAUL', 'marcelino@gmail.com', 'sila', '87172957')
/*Violação da restrição UNIQUE KEY 'uc_pais_email'. Não é possível inserir a chave duplicada no objeto 'dbo.pais'.
 O valor de chave duplicada é (marcelino@gmail.com).*/
 go

 /*delete from [pais]
 select * from [pais]
 go*/

 /* procedure de insert tabelas pais e filhos */
SELECT PAIS.*, FILHOS.* FROM PAIS
INNER JOIN filhos
ON IDPAIS = ID_PAIS
GO

create procedure [cadastro_pais] --@id uniqueidentifier, 
								 @nome varchar(120),
								 @email NVARCHAR(180),
								 @senha NVARCHAR(40),
								 @celular NVARCHAR(30)
as
	insert into [pais] values(newid(), @nome, @email, @senha, @celular)
	
go

[cadastro_pais] 'marcelino', 'marcelinops@gmail', 'senha', '997522014'
go

select * from [pais] 