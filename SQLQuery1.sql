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


insert into [pais] values(
	NEWID(),
	'marcelino', 
	'marcelino@gmail',
	'senha',
	'84372957'
) 

select * from pais
