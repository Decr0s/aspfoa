CREATE PROCEDURE Busca 
@CampoBusca VARCHAR (100) 
AS
SELECT Nome, Tipo, Valor 
FROM Produtos
WHERE UPPER(Tipo) = UPPER(@CampoBusca)

EXECUTE Busca 'Salgadinho'

