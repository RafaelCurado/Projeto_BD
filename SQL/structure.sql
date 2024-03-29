USE p1g1
GO


CREATE TABLE [Projeto_habilidade] (
	[name] VARCHAR(255) NOT NULL,
	[descricao] VARCHAR(MAX) NULL,
	PRIMARY KEY ([name]),
);
GO


CREATE TABLE [Projeto_personagem] (
    [name] VARCHAR(255) NOT NULL,
    [habilidade_1] VARCHAR(255) NULL,
    [habilidade_2] VARCHAR(255) NULL,
    [habilidade_3] VARCHAR(255) NULL,
	PRIMARY KEY ([name]),
	FOREIGN KEY ([habilidade_1]) REFERENCES Projeto_habilidade(name),
	FOREIGN KEY ([habilidade_2]) REFERENCES Projeto_habilidade(name),
	FOREIGN KEY ([habilidade_3]) REFERENCES Projeto_habilidade(name),
);
GO

-- pra já cada jogador tem só uma personagem já definida
CREATE TABLE [Projeto_jogador] (
    [id] INTEGER NOT NULL IDENTITY(1, 1) UNIQUE,
    [name] VARCHAR(255) NULL,
    [region] VARCHAR(50) NULL,
    [nick] VARCHAR(255) NULL UNIQUE CHECK (nick NOT LIKE '% %'),
	[personagem_name] VARCHAR(255) NULL,
	[balance] INTEGER DEFAULT 0,
    PRIMARY KEY ([id]),
	FOREIGN KEY ([personagem_name]) REFERENCES Projeto_personagem(name),
);
GO

-- pra já cada jogador tem só uma personagem já definida
CREATE TABLE [Projeto_treinador] (
    [id] INTEGER NOT NULL IDENTITY(1, 1) UNIQUE,
    [name] VARCHAR(255) NULL,
    [region] VARCHAR(50) NULL
    PRIMARY KEY ([id]),
);
GO


CREATE TABLE [Projeto_torneio] (
    [id_torneio] INTEGER NOT NULL IDENTITY(1, 1) UNIQUE,
    [name] VARCHAR(255) NULL,
    [date] VARCHAR(255) NULL,
    [region] VARCHAR(50) NULL,
    PRIMARY KEY ([id_torneio])
);
GO


CREATE TABLE [Projeto_equipa] (
    [id_equipa] INTEGER NOT NULL IDENTITY(1, 1) UNIQUE,
    [id_jogador1] INTEGER NULL,		 
    [id_jogador2] INTEGER NULL,
    [id_jogador3] INTEGER NULL,
    [id_jogador4] INTEGER NULL,
    [id_jogador5] INTEGER NULL,
	[id_treinador] INTEGER NULL,
    [nome] VARCHAR(MAX) NULL,
    [country] VARCHAR(100) NULL,
    [region] VARCHAR(50) NULL,
    PRIMARY KEY ([id_equipa]),
	FOREIGN KEY ([id_jogador1]) REFERENCES Projeto_jogador(id),
	FOREIGN KEY ([id_jogador2]) REFERENCES Projeto_jogador(id),
	FOREIGN KEY ([id_jogador3]) REFERENCES Projeto_jogador(id),
	FOREIGN KEY ([id_jogador4]) REFERENCES Projeto_jogador(id),
	FOREIGN KEY ([id_jogador5]) REFERENCES Projeto_jogador(id),
	FOREIGN KEY ([id_treinador]) REFERENCES Projeto_treinador(id),
);
GO

CREATE TABLE [Projeto_jogo] (
	[id_jogo] INTEGER NOT NULL IDENTITY(1, 1) UNIQUE,
	[id_equipa1] INTEGER NOT NULL,
	[id_equipa2] INTEGER NOT NULL,
	[id_torneio] INTEGER NOT NULL,
	[date] VARCHAR(255) NULL,
	[result] VARCHAR(255) NOT NULL,
	[duration] INTEGER NULL,
	PRIMARY KEY ([id_jogo]),
	FOREIGN KEY ([id_equipa1]) REFERENCES Projeto_equipa(id_equipa),
	FOREIGN KEY ([id_equipa2]) REFERENCES Projeto_equipa(id_equipa),
	FOREIGN KEY ([id_torneio]) REFERENCES Projeto_torneio(id_torneio),
);
GO


CREATE TABLE [Projeto_ranking] (
	[position] INTEGER NOT NULL ,
	[id_jogador] INTEGER NOT NULL,
	[score] INTEGER NULL,
	PRIMARY KEY ([position]),
	FOREIGN KEY ([id_jogador]) REFERENCES Projeto_jogador(id),
);
GO


CREATE TABLE [Projeto_transactions] (
	[id_transaction] INTEGER NOT NULL IDENTITY(1,1) UNIQUE,
	[type] VARCHAR(MAX) NULL,
	[date] VARCHAR(255) NULL,
	[value] INTEGER NULL,
	[id_jogador] INTEGER NOT NULL,
	PRIMARY KEY ([id_transaction]),
	FOREIGN KEY ([id_jogador]) REFERENCES Projeto_jogador(id),
);
GO


CREATE TABLE [Projeto_settings] (
	[id_jogador] INTEGER NOT NULL UNIQUE,
	[language] VARCHAR(255) NULL,
	[platform] VARCHAR(255) NULL, --pc, consola(ps4, xbox)
	FOREIGN KEY ([id_jogador]) REFERENCES Projeto_jogador(id),
);
GO
