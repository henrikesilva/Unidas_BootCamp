USE ECommerce

SELECT 
	AVG(PrecoVenda)
FROM 
	Produto

SELECT 
	P.Id,
	P.Nome,
	P.Descricao,
	P.Preco,
	P.PrecoVenda,
	(P.PrecoVenda - P.Preco) as LucroPresumido,
	COUNT(E.Id) as TotalEstoques,
	SUM(E.Quantidade*(P.PrecoVenda - P.Preco)) as LucroPresumidoPorQuantidade
FROM 
	Produto P
LEFT JOIN Estoque E
	ON P.Id = E.IdProduto
GROUP BY P.Id, P.Nome, p.Descricao, P.Preco, P.PrecoVenda
HAVING SUM(E.Quantidade) is null OR SUM(E.Quantidade) > 0
ORDER BY P.Id


INSERT INTO Estoque
SELECT 
	0 AS Quantidade,
	GETDATE() AS DataModificacao,
	P.Id as IdProduto
FROM
	Produto P
LEFT JOIN Estoque E
	ON E.IdProduto = P.Id
WHERE
	E.Id IS NULL

DELETE E 
FROM
	Estoque E
INNER JOIN Produto P
	ON P.Id = E.IdProduto
WHERE P.Ativo = 0

UPDATE E
	SET Quantidade = 10
FROM Estoque E
INNER JOIN Produto P
	ON P.Id = E.IdProduto
WHERE P.Preco < 2000
