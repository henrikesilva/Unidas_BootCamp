USE ECommerce;

SELECT 
	Id,
	Descricao,
	Preco,
	PrecoVenda,
	(PrecoVenda - Preco) AS MargemLucro
FROM
	Produto

SELECT 
	P.Id,
	P.Descricao,
	P.Preco,
	P.PrecoVenda,
	(PrecoVenda - Preco) AS MargemLucro
FROM
	Produto AS P
JOIN Estoque AS E
	ON P.Id = E.IdProduto

SELECT 
	SUM((P.Preco * E.Quantidade)) AS TotalInvestido
FROM Produto AS P
JOIN Estoque AS E
	ON P.Id = E.IdProduto

SELECT 
	P.Id,
	P.Descricao,
	P.Preco,
	P.PrecoVenda,
	E.Quantidade* (PrecoVenda - Preco) AS LucroEstimado
FROM
	Produto AS P
INNER JOIN Estoque AS E
	ON P.Id = E.IdProduto

SELECT 
	SUM(E.Quantidade * (PrecoVenda - Preco)) as LucroEstimado
FROM 
	Produto P
INNER JOIN Estoque E
	ON P.Id = E.IdProduto

SELECT 
	100*((P.Preco - PrecoVenda)/Preco) as LucroEstimadoPercentual
FROM 
	Produto P

SELECT 
	(SUM(100*((P.Preco - PrecoVenda)/Preco))/ COUNT(*)) as MediaLucroEstimadoPercentual
FROM 
	Produto P