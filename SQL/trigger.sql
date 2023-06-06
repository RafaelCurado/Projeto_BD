USE p1g1
GO

CREATE TRIGGER validar_novo_treinador
ON Projeto_treinador
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE name IS NULL OR region IS NULL)
    BEGIN
        RAISERROR('Os campos "name" e "region" são obrigatórios.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;

    INSERT INTO Projeto_treinador (name, region)
    SELECT name, region
    FROM inserted;
END;