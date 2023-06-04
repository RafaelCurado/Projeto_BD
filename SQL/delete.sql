USE p1g1
GO

IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Projeto_transactions'))
BEGIN;
    DROP TABLE [Projeto_transactions];
END;
GO


IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Projeto_settings'))
BEGIN;
    DROP TABLE [Projeto_settings];
END;
GO

IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Projeto_ranking'))
BEGIN;
    DROP TABLE [Projeto_ranking];
END;
GO


IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Projeto_jogo'))
BEGIN;
    DROP TABLE [Projeto_jogo];
END;
GO

IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Projeto_torneio'))
BEGIN;
    DROP TABLE [Projeto_torneio];
END;
GO



IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Projeto_equipa'))
BEGIN;
    DROP TABLE [Projeto_equipa];
END;
GO

IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Projeto_treinador'))
BEGIN;
    DROP TABLE [Projeto_treinador];
END;
GO


IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Projeto_jogador'))
BEGIN;
    DROP TABLE [Projeto_jogador];
END;
GO


IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Projeto_personagem'))
BEGIN;
    DROP TABLE [Projeto_personagem];
END;
GO


IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Projeto_habilidade'))
BEGIN;
    DROP TABLE [Projeto_habilidade];
END;
GO






--IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Projeto_item'))
--BEGIN;
--    DROP TABLE [Projeto_item];
--END;
--GO

--IF EXISTS(SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID('Projeto_inventory'))
--BEGIN;
--    DROP TABLE [Projeto_inventory];
--END;
--GO