CREATE PROCEDURE BuscaCliente 
@Nome VARCHAR (100),
@Cpf VARCHAR (100) = NULL
AS
SELECT Nome, Telefone, Email, Cpf 
FROM Clientes
WHERE UPPER(Nome) = UPPER(@Nome) or Cpf = @Cpf

EXECUTE BuscaCliente 'hugo', '[optional=cpf]'