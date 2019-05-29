select * from EntradaSaida;

SELECT * FROM Transacao;

ALTER TABLE EntradaSaida
DROP CONSTRAINT id_Transacao;

ALTER TABLe EntradaSaida
ADD CONSTRAINT id_Transacao
FOREIGN KEY (id_Transacao)
REFERENCES Transacao(idTransacao);