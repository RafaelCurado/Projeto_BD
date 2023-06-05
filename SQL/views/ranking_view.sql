USE p1g1
GO

CREATE VIEW ranking_view AS 
SELECT id_jogador, score 
FROM Projeto_ranking;

-- when quering this view:
-- SELECT jogador_id, pontuacao 
-- FROM ranking_view 
-- ORDER BY pontuacao DESC;

 