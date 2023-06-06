 USE p1g1
 GO
 
 DECLARE @treinadorId INT = 0; 

    BEGIN TRANSACTION; 
    BEGIN TRY 
        SET @treinadorId = (SELECT id FROM Projeto_treinador WHERE name = 'David Lee'); 
        DELETE FROM Projeto_jogo 
		WHERE  id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_treinador = @treinadorId) 
            OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_treinador = @treinadorId) 
        DELETE FROM Projeto_equipa WHERE id_treinador = @treinadorId; 
        DELETE FROM Projeto_treinador WHERE id = @treinadorId; 
        COMMIT; 
    END TRY 
    BEGIN CATCH 
        ROLLBACK; 
        -- Realize qualquer tratamento de erro necessário ou lance uma exceção, se desejado 
        SELECT ERROR_MESSAGE() AS mensagem_de_erro; 
    END CATCH; 