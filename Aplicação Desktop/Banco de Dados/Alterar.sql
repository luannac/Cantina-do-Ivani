select * from EntradaSaida;

select * from Estoque;

SELECT * FROM Transacao;

ALTER TABLE EntradaSaida
DROP CONSTRAINT idEstoque_EntradaSaida;

ALTER TABLE EntradaSaida
DROP COLUMN idEstoque_EntradaSaida;

DROP TABLE Estoque;

ALTER TABLe EntradaSaida
ADD CONSTRAINT id_Produto
FOREIGN KEY (id_Produto)
REFERENCES Produto(idProduto);

ALTER TABLE Produto
  ADD quantidade Int;

  DELETE FROM Produto WHERE idProduto>= 43;