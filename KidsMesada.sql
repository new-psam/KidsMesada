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



 /* procedure de insert tabelas pais e filhos  views*/
create view [vwPais_Filhos] as
	SELECT p.nome as pais, p.email, p.celular as phone_pais, f.nome, f.total_pontos, f.saldo_dinheiro 
	FROM PAIS P
	INNER JOIN filhos F
	ON IDPAIS = ID_PAIS
GO

-- drop procedure [cadastro_pais]


create procedure [cadastro_pais] @nome varchar(120),
								 @email NVARCHAR(180),
								 @senha NVARCHAR(40),
								 @celular NVARCHAR(30),
								 @id UNIQUEIDENTIFIER OUTPUT
as
	
	insert into [pais] 
	--output inserted.idPais into @id
	values(newid(), @nome, @email, @senha, @celular)
	select @ID = idPais from pais 
	
go
declare @SAIDA uniqueidentifier
exec [cadastro_pais] 'marcelino', 'marcelinops@gmail', 'senha', '997522014', @saida output
 
select @saida
go


select * from [pais] 
go


exec cadastro_pais 'josé', 'jose@bol.com', '125', '3621489'
select scope_identity() as idpais
go




select * from filhos
go

insert into [filhos] values(
newid(), 'joaquim', 'quimo', '30/04/1970', 'skldjf', null, -98, 102, 'B566C3BA-ACE3-4DC0-896C-D4D05ABE6F22')


--delete from [filhos]

update [pais] set celular = '16997522013' where idPais = 'B566C3BA-ACE3-4DC0-896C-D4D05ABE6F22'

insert into [filhos] ([idFilhos], [nome], [userName], [data_nascimento], [senha], [id_pais]) values(
newid(), 'João Candido', 'JCandido', '27/07/2015', 'silva', 'B566C3BA-ACE3-4DC0-896C-D4D05ABE6F22')
insert into [filhos] ([idFilhos], [nome], [userName], [data_nascimento], [senha], [id_pais])values(
newid(), 'Maria Thereza', 'Tete', '02/09/2013', 'sampaio', 'B566C3BA-ACE3-4DC0-896C-D4D05ABE6F22')
select * from filhos
go

select * from vwPais_Filhos
go

/* criando index nas tabelas pais e filhos */
create nonclustered index [IX_Pais_Email] ON [Pais]([Email])
create nonclustered index [IX_Pais_Celular] ON [Pais]([Celular])
create nonclustered index [IX_Filhos_UserName] ON [Filhos]([UserName])
go

/* tabela pontuacao */

create table [acoes](
	[idAcoes] UNIQUEIDENTIFIER not null,
	[nome] NVARCHAR(120) not null,
	[valor] INT not null,

	CONSTRAINT [pk_acoes] PRIMARY KEY([IdAcoes])
)

ALTER TABLE [acoes] 
	ADD CONSTRAINT [uq_nome] UNIQUE ([nome])
go

/* teses*/
insert into [acoes] values(newid(), 'não arrumou quarto', 1)
insert into [acoes] values(newid(), 'estou piano extra', 2)
update [acoes] set [valor] = -1 where [idAcoes] = '89C4E509-9291-401E-94D3-84CFADAA65A2'
update [acoes] set [nome] = 'estudou piano extra' where [idacoes] = 'FAC50BCD-213B-4909-AB6B-D19A09381B4E'
select * from [acoes]
go
create table [pontuacao](
	[idPontuacao] uniqueidentifier not null,
	[data] DATETIME not null default getdate(),
	[pontos] INT,
	[id_acoes] uniqueidentifier not null,
	[id_parents] uniqueidentifier not null,
	[id_filhos] uniqueidentifier not null,

	CONSTRAINT [pk_pontuacao] PRIMARY KEY([idPontuacao]),
		CONSTRAINT [fk_pontuacao_acoes] FOREIGN KEY([id_acoes]) REFERENCES [acoes] ([idacoes]),
		CONSTRAINT [fk_pontuacao_pais] FOREIGN KEY([id_parents]) REFERENCES [pais] ([idPais]),
		CONSTRAINT [Fk_pontuacao_filhos] FOREIGN KEY([id_filhos]) REFERENCES [filhos] ([idfilhos])
)
go


/* testes */
select * from pontuacao
select * from acoes

select * from filhos


insert into [pontuacao]([idPontuacao], [pontos], [id_acoes], [id_parents], [id_filhos])
 values(newid(), null, '89C4E509-9291-401E-94D3-84CFADAA65A2', 'B566C3BA-ACE3-4DC0-896C-D4D05ABE6F22',
  '1FE9501E-8670-4051-A1BD-FABF45D6D484')
insert into [pontuacao] values(
newid(), '01/12/2024 13:00', -2, '89C4E509-9291-401E-94D3-84CFADAA65A2', 'B566C3BA-ACE3-4DC0-896C-D4D05ABE6F22',
  '1FE9501E-8670-4051-A1BD-FABF45D6D484')