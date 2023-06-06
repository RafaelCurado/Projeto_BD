CREATE FUNCTION obter_nome_personagem(@nick_jogador VARCHAR(255)) 
RETURNS TABLE
AS
RETURN (
    SELECT p.name AS nome_personagem
    FROM Projeto_jogador j
    INNER JOIN Projeto_personagem p ON j.personagem_name = p.name
    WHERE j.nick = @nick_jogador
);