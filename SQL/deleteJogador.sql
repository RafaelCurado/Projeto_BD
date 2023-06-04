
SET @jogadorId = (SELECT id FROM Projeto_jogador WHERE nick = 'enim');
-- Delete from Projeto_settings table
DELETE FROM Projeto_settings WHERE id_jogador = @jogadorID;

-- Delete from Projeto_transactions table
DELETE FROM Projeto_transactions WHERE id_jogador = @jogadorID;

-- Delete from Projeto_ranking table
DELETE FROM Projeto_ranking WHERE id_jogador = @jogadorID;

-- Delete from Projeto_jogo table (considering both id_equipa1 and id_equipa2)
DELETE FROM Projeto_jogo WHERE id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador1 = @jogadorID)
  OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador1 = @jogadorID)
  OR id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador2 = @jogadorID)
  OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador2 = @jogadorID)
  OR id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador3 = @jogadorID)
  OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador3 = @jogadorID)
  OR id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador4 = @jogadorID)
  OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador4 = @jogadorID)
  OR id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador5 = @jogadorID)
  OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador5 = @jogadorID);

-- Delete from Projeto_equipa table
DELETE FROM Projeto_equipa
WHERE id_jogador1 = @jogadorID
   OR id_jogador2 = @jogadorID
   OR id_jogador3 = @jogadorID
   OR id_jogador4 = @jogadorID
   OR id_jogador5 = @jogadorID;

-- Delete from Projeto_jogador table
DELETE FROM Projeto_jogador WHERE id = @jogadorID;
	
