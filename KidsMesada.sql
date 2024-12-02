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



