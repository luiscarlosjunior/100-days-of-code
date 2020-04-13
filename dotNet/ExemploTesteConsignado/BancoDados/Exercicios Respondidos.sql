USE ExemploTeste
GO
-- Listar todos os clientes do estado de SP que tenham mais de 60% das parcelas pagas.
SELECT c.Nome, c.Celular, uf.Descricao FROM Cliente as c LEFT JOIN UnidadeFederativa as uf
	ON c.UF = uf.UFID
	WHERE c.ClienteID IN (SELECT ClienteID FROM Financiamento as f
		WHERE FinanciamentoID IN (SELECT FinanciamentoID FROM ParcelasFinanciamento
		GROUP BY FinanciamentoID
		HAVING COUNT(DataPagamento)*100/COUNT(ParcelasFinanciamentoID) >= 60))

-- Listar os primeiros 4 clientes que tenham alguma parcela com mais de 05 dias atrasadas 
-- (Data Vencimento maior que data atual E data pagamento nula)
SELECT TOP 4 c.Nome, c.Celular, uf.Descricao FROM Cliente as c LEFT JOIN UnidadeFederativa as uf
	ON c.UF = uf.UFID
	WHERE c.ClienteID IN (SELECT ClienteID FROM Financiamento as f
		WHERE FinanciamentoID IN (SELECT FinanciamentoID FROM ParcelasFinanciamento 
			WHERE DataPagamento > DATEADD(DAY, 5, DataVencimento) OR DataPagamento is NULL))

-- Listar todos os clientes que já atrasaram em algum momento duas ou mais parcelas em mais de 10 dias, 
-- e que o valor do financiamento seja maior que R$ 10.000,00.
SELECT c.Nome, c.Celular, uf.Descricao 
	FROM Cliente as c LEFT JOIN UnidadeFederativa as uf
	ON c.UF = uf.UFID
	WHERE c.ClienteID IN (SELECT ClienteID FROM Financiamento as f
	WHERE ValorTotal > 10000 AND FinanciamentoID IN (SELECT FinanciamentoID FROM ParcelasFinanciamento 
			WHERE DataPagamento > DATEADD(DAY, 10, DataVencimento)
			GROUP BY FinanciamentoID
			HAVING COUNT(FinanciamentoID) >= 2))
