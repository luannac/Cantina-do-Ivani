CREATE TRIGGER Venda on Transacao INSTEAD OF INSERT
AS
BEGIN


























	DECLARE
	@IDESTOQUE INT,
	@QUANTIDADE INT

	SELECT @IDESTOQUE = idEstoque_EntradaSaida FROM INSERTED
	SELECT @QUANTIDADE = quantEntradaSaida FROM INSERTED

	UPDATE Estoque
	SET
		quantidade = quantidade + @QUANTIDADE
	WHERE idEstoque = @IDESTOQUE

END
GO