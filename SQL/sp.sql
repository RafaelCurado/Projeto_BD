CREATE PROCEDURE sp_add_jogador
    @name VARCHAR(255),
    @region VARCHAR(50),
    @nick VARCHAR(MAX),
    @personagem_name VARCHAR(255),
    @score INTEGER
AS
BEGIN
    -- Lógica para adicionar um jogador
    INSERT INTO Projeto_jogador (name, region, nick, personagem_name)
    VALUES (@name, @region, @nick, @personagem_name)

    -- Obter o ID do jogador adicionado
    DECLARE @id_jogador INT
    SET @id_jogador = SCOPE_IDENTITY()

    -- Verificar se o jogador já existe na tabela Projeto_ranking
    IF NOT EXISTS (SELECT 1 FROM Projeto_ranking WHERE id_jogador = @id_jogador)
    BEGIN
        -- Adicionar o jogador à tabela Projeto_ranking com a pontuação fornecida
        INSERT INTO Projeto_ranking ([position], id_jogador, score)
        SELECT ISNULL(MAX([position]), 0) + 1, @id_jogador, @score
        FROM Projeto_ranking
    END
END