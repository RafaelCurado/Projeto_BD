CREATE FUNCTION obter_habilidades_personagem(@nome_personagem VARCHAR(255)) 
RETURNS TABLE
AS
RETURN (
    SELECT p.habilidade_1 AS habilidade_nome, h1.descricao AS habilidade_descricao
    FROM Projeto_personagem p
    INNER JOIN Projeto_habilidade h1 ON p.habilidade_1 = h1.name
    WHERE p.name = @nome_personagem
    
    UNION ALL
    
    SELECT p.habilidade_2 AS habilidade_nome, h2.descricao AS habilidade_descricao
    FROM Projeto_personagem p
    INNER JOIN Projeto_habilidade h2 ON p.habilidade_2 = h2.name
    WHERE p.name = @nome_personagem
    
    UNION ALL
    
    SELECT p.habilidade_3 AS habilidade_nome, h3.descricao AS habilidade_descricao
    FROM Projeto_personagem p
    INNER JOIN Projeto_habilidade h3 ON p.habilidade_3 = h3.name
    WHERE p.name = @nome_personagem
);