USE ECommerce;

-- TABELAS E SUAS CHAVES PRIMARIAS
SELECT T.NAME AS TABELA
FROM SYSOBJECTS T
WHERE T.xtype = 'U'

-- colunas das tabelas do banco de dados
SELECT T.NAME AS TABELA, C.NAME AS COLUNAS
FROM SYSOBJECTS T JOIN SYSCOLUMNS C ON T.id = C.id
WHERE T.xtype = 'U' AND T.NAME = 'TB_CLIENTE'

-- Metadados das views
SELECT T.*
FROM SYSOBJECTS T
WHERE T.xtype = 'V'