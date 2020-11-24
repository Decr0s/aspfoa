CREATE FUNCTION dbo.TotalLucro() 
RETURNS int  
AS  
BEGIN    
    DECLARE @retval int ;   

    SELECT @retval = Sum(Valor)
    FROM dbo.Pedidos pe INNER JOIN
         dbo.Produtos pr
         ON pe.ProdutoId = pr.Id;
    RETURN @retval
End;
