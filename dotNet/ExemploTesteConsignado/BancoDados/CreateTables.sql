CREATE DATABASE ExemploTeste
GO
USE ExemploTeste
GO
CREATE TABLE UnidadeFederativa (
	UFID INTEGER IDENTITY (1,1) NOT NULL,
	Descricao VARCHAR (50),
	CONSTRAINT PK_UnidadeFederativa PRIMARY KEY (UFID)
)
GO
CREATE TABLE TipoFinanciamento (
	TipoFinanciamentoID INTEGER IDENTITY (1,1) NOT NULL,
	Descricao VARCHAR (50),
	CONSTRAINT PK_TipoFinanciamento PRIMARY KEY (TipoFinanciamentoID)
)
GO
CREATE TABLE Cliente (
	ClienteID INTEGER IDENTITY (1,1) NOT NULL,
	Nome NVARCHAR (150),
	UF CHAR(2),
	Celular CHAR(15),
	CONSTRAINT PK_Cliente PRIMARY KEY (ClienteID)
)
GO
CREATE TABLE Financiamento (
	FinanciamentoID INTEGER IDENTITY (1,1) NOT NULL,
	ClienteID INTEGER NOT NULL,
	TipoFinanciamentoID INTEGER NOT NULL,
	ValorTotal DECIMAL (12,2),
	DataVencimento DATE,
	CONSTRAINT PK_FinanciamentoID PRIMARY KEY (FinanciamentoID),
	CONSTRAINT FK_Financiamento_Cliente FOREIGN KEY (ClienteID)
		REFERENCES Cliente (ClienteID),
	CONSTRAINT FK_TipoFinanciamento FOREIGN KEY (TipoFinanciamentoID)
		REFERENCES TipoFinanciamento (TipoFinanciamentoID)		
)
GO
CREATE TABLE ParcelasFinanciamento (
	ParcelasFinanciamentoID INTEGER IDENTITY (1,1) NOT NULL,
	FinanciamentoID INTEGER NOT NULL,
	NumeroParcela INTEGER NOT NULL,
	ValorParcela DECIMAL (12, 2) NULL,
	DataVencimento DATE NOT NULL,
	DataPagamento DATE NULL,
	CONSTRAINT PK_ParcelasFinanciamente PRIMARY KEY (ParcelasFinanciamentoID),
	CONSTRAINT FK_Financiamento_Parcelas FOREIGN KEY (FinanciamentoID)
		REFERENCES Financiamento (FinanciamentoID)
)
