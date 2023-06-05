USE p1g1
GO

DECLARE @jogadorId INT = 0; 

BEGIN TRANSACTION; 
BEGIN TRY 
    SET @jogadorId = (SELECT id FROM Projeto_jogador WHERE nick = 'introduzir_nick'); 
    DELETE FROM Projeto_settings WHERE id_jogador = @jogadorId; 
    DELETE FROM Projeto_transactions WHERE id_jogador = @jogadorId; 
    DELETE FROM Projeto_ranking WHERE id_jogador = @jogadorId; 
    DELETE FROM Projeto_jogo WHERE id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador1 = @jogadorId) 
        OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador1 = @jogadorId) 
        OR id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador2 = @jogadorId) 
        OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador2 = @jogadorId) 
        OR id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador3 = @jogadorId) 
        OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador3 = @jogadorId) 
        OR id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador4 = @jogadorId) 
        OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador4 = @jogadorId) 
        OR id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador5 = @jogadorId) 
        OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador5 = @jogadorId); 
    DELETE FROM Projeto_equipa 
    WHERE id_jogador1 = @jogadorId 
        OR id_jogador2 = @jogadorId 
        OR id_jogador3 = @jogadorId 
        OR id_jogador4 = @jogadorId 
        OR id_jogador5 = @jogadorId; 
    DELETE FROM Projeto_jogador WHERE id = @jogadorId; 
    COMMIT; 
END TRY 
BEGIN CATCH 
    ROLLBACK; 
    -- Realize qualquer tratamento de erro necessário ou lance uma exceção, se desejado 
    SELECT ERROR_MESSAGE() AS mensagem_de_erro; 
END CATCH; 