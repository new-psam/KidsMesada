CREATE DATABASE kidsmesada
GO

use [kidsmesada]
go

CREATE TABLE pais(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[Nome] NVARCHAR(120) NOT NULL,
	[Email] NVARCHAR(180) NOT NULL,
	[Senha] NVARCHAR(40) NOT NULL,
	[Celular] NVARCHAR(30) NOT NULL,

	CONSTRAINT [PK_Pais] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_Pais_email] UNIQUE ([Email])
);
go

CREATE NONCLUSTERED INDEX [IX_Pais_Email] ON [Pais]([Email])

CREATE TABLE [Filhos](
	[Id] INT NOT NULL IDENTITY(1, 1),
	[Nome] NVARCHAR(120) NOT NULL,
	[UserName] NVARCHAR(50) NOT NULL,
	[Data_nascimento] DATETIME NOT NULL,
	[Senha] NVARCHAR(40) NOT NULL,
	[Celular] NVARCHAR(30),
	[TotalPontos] INT DEFAULT 0,
	[SaldoDinheiro] DECIMAL(14, 2) DEFAULT 0.00,
	[IdPais] INT NOT NULL,

	CONSTRAINT [PK_Filhos] PRIMARY KEY([Id]),
		CONSTRAINT [FK_Filhos_Pais] FOREIGN KEY([idPais]) REFERENCES [Pais] ([Id]),
    CONSTRAINT [UQ_Filhos_UserName] UNIQUE ([UserName])    
);

CREATE NONCLUSTERED INDEX [IX_Filhos_UserName] ON [Filhos]([UserName])

go

-- ----------------------------------

/* tabela acoes */

create table [Acoes](
	[Id] INT NOT NULL IDENTITY(1, 1),
	[Nome] NVARCHAR(120) NOT NULL,
	[Valor] INT NOT NULL,

	CONSTRAINT [PK_Acoes] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Acoes_Nome] UNIQUE ([Nome])
)

CREATE NONCLUSTERED INDEX [IX_Acoes_Nome] ON [Acoes] ([Nome])
go

 /* tabela pontuacao */


create table [Pontuacao](
	--[idPontuacao] uniqueidentifier not null,
	[Data] DATETIME NOT NULL DEFAULT GETDATE(),
	[Pontos] INT NOT NULL,
	[IdAcoes] INT NOT NULL,
	[IdParents] INT NOT NULL,
	[idFilhos] INT NOT NULL,

	CONSTRAINT [PK_pontuacao] PRIMARY KEY([IdAcoes], [IdParents], [idFilhos])

)
go
/* mudando a chave primaria */
ALTER TABLE [Pontuacao]
DROP CONSTRAINT [PK_pontuacao]
GO

-- DELETE FROM [Pontuacao]


ALTER TABLE [Pontuacao]
ADD [Id] INT NOT NULL IDENTITY(1, 1)

ALTER TABLE [Pontuacao]
ADD CONSTRAINT [PK_pontuacao] PRIMARY KEY([Id])

select * from [Pontuacao]
GO

select p.[id], p.[data], f.[Nome] as criança, pa.[Nome] as Responsável, a.[Nome], p.[pontos]
FROM [Pontuacao] p 
INNER JOIN [Filhos] f ON p.[idFilhos] = f.[Id]
INNER JOIN [pais] pa ON p.[IdParents] = pa.[Id]
INNER JOIN [Acoes] a ON p.[IdAcoes] = a.[Id]

select * from [vwPais_Filhos]

 /* procedure de insert tabelas pais e filhos  views*/
create view [vwPais_Filhos] as
	SELECT p.[Nome] as Pais, p.[Email], p.[Celular] as Phone_pais, f.[Nome], f.[TotalPontos], f.[SaldoDinheiro] 
	FROM [Pais] P
	INNER JOIN [Filhos] F
	ON P.[Id] = [IdPais]
GO
/* automatizando a coluna [Filhos] para que o Saldo seja calculado pelo pontos*/

SELECT name 
FROM sys.default_constraints 
WHERE parent_object_id = OBJECT_ID('Filhos') 
AND parent_column_id = COLUMNPROPERTY(OBJECT_ID('Filhos'), 'SaldoDinheiro', 'ColumnId');

ALTER TABLE [Filhos]
DROP CONSTRAINT [DF__Filhos__SaldoDin__3C69FB99]

--delete from [Filhos]

ALTER TABLE [Filhos]
DROP COLUMN [SaldoDinheiro]

ALTER TABLE [Filhos]
ADD [SaldoDinheiro]  AS ([TotalPontos] * 0.1)

select * from [Filhos]
GO

/* fazendo a trigger de atualização de pontos e valor dinheiro */

ALTER TRIGGER [TR_Atualiza_Pontos_Saldo]
ON [Pontuacao]
FOR INSERT, UPDATE
AS

BEGIN
    UPDATE f
    SET f.[TotalPontos] = f.[TotalPontos] + (ISNULL(i.[Pontos], 0) - ISNULL(d.[Pontos], 0))
    FROM [Filhos] f
    INNER JOIN [Inserted] i ON f.[Id] = i.[IdFilhos]
    FULL OUTER JOIN [deleted] d ON f.[Id] = d.[IdFilhos]
END
/*BEGIN
	
	update [filhos]
	set [SaldoDinheiro] = (select [TotalPontos] from [Filhos]) * 0.1
	where [Id] = (select [idfilhos] from inserted)
END*/
GO

-- testes

Insert into [Pais] VALUES ('Marcelino', 'marcelino@gmail', '123', '123456');
Insert into [Pais] VALUES ('Poly', 'poly@gmail', '258', '9123456');
Insert into [Pais] VALUES ('Piro', 'piro@hotmail', 'pirado', '199456');
select * from [pais];
GO

insert into [filhos] ([Nome], [UserName], [Data_nascimento], [Senha], [IdPais]) 
    values('joaquim', 'quimo', '03/04/1970', 'skldjf',  3);
insert into [filhos] ([Nome], [UserName], [Data_nascimento], [Senha], [IdPais]) values('Maria Thereza', 'tete', '09/02/2013', 's4kldjf', 1);
insert into [filhos] ([Nome], [UserName], [Data_nascimento], [Senha], [IdPais]) values('João Candido', 'ArmadaCandido', '07/27/2015', 's96ldjf', 1);
select * from [Filhos]
select * from [vwPais_Filhos]
GO


/*[Id] INT NOT NULL IDENTITY(1, 1),
	[Nome] NVARCHAR(120) NOT NULL,
	[UserName] NVARCHAR(50) NOT NULL,
	[Data_nascimento] DATETIME NOT NULL,
	[Senha] NVARCHAR(40) NOT NULL,
	[Celular] NVARCHAR(30),
	[TotalPontos] INT DEFAULT 0,
	[SaldoDinheiro] DECIMAL(14, 2) DEFAULT 0.00,
	[IdPais] INT NOT NULL,*/

insert into [acoes] values('não arrumou quarto', -1)
insert into [acoes] values('estou piano extra', 2)
select * from [Acoes]
Go




/*[Data] DATETIME NOT NULL DEFAULT GETDATE(),
	[Pontos] INT NOT NULL,
	[IdAcoes] INT NOT NULL,
	[IdParents] INT NOT NULL,
	[idFilhos] INT NOT NULL,     */

insert into [pontuacao] ([pontos], [IdAcoes], [IdParents], [IdFilhos])
    values( -20, 1, 3, 10);

insert into [pontuacao] ([pontos], [IdAcoes], [IdParents], [IdFilhos])
    values( 100, 2, 1, 7);


UPDATE [Pontuacao] set [Pontos] = 10 WHERE [Id] = 3;
select * from [Pontuacao]
select * from [vwPais_Filhos]
select * from [Filhos]
Go

/* fazendo a trigger de delete Pontuação */

create trigger [tr_atualiza_pontos_delete]
ON [pontuacao]
FOR DELETE
AS
BEGIN
	DECLARE
		@pontos_deletado int
		
		BEGIN
		SET @pontos_deletado = (select ISNULL(SUM([pontos]), 0) FROM [deleted])


		UPDATE [filhos]
		SET [TotalPontos] = [TotalPontos] - @pontos_deletado
		WHERE [Id] = (select [idFilhos] FROM deleted)
		END
	
			
END
GO

DELETE FROM [Pontuacao] WHERE [Id] = 2

select * from [vwPais_Filhos]

Go

select* from [acoes]
select * from [pais]
select * from [Filhos]
select * from [Pontuacao]

UPDATE [Pontuacao] set [Data] = '03/01/2025' WHERE [Id] = 3;