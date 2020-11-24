CREATE FUNCTION dbo.TotalPedidoPorCliente(@Cpf nvarchar(255)) 
RETURNS int  
AS  
BEGIN    
    DECLARE @retval int;   

    SELECT @retval = Count(*)
    FROM dbo.Pedidos pe INNER JOIN
    dbo.Clientes c ON pe.ClienteId = c.Id
    WHERE c.Cpf = @Cpf;

    RETURN @retval
End;
