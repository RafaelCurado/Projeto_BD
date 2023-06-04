USE p1g1
GO

INSERT INTO [Projeto_habilidade] ([name], [descricao])
VALUES
    ('Habilidade 1', 'Descrição 1'),
    ('Habilidade 2', 'Descrição 2'),
    ('Habilidade 3', 'Descrição 3'),
    ('Habilidade 4', 'Descrição 4'),
    ('Habilidade 5', 'Descrição 5'),
    ('Habilidade 6', 'Descrição 6'),
    ('Habilidade 7', 'Descrição 7'),
    ('Habilidade 8', 'Descrição 8'),
    ('Habilidade 9', 'Descrição 9'),
    ('Habilidade 10', 'Descrição 10'),
    ('Habilidade 11', 'Descrição 11'),
    ('Habilidade 12', 'Descrição 12'),
    ('Habilidade 13', 'Descrição 13'),
    ('Habilidade 14', 'Descrição 14'),
    ('Habilidade 15', 'Descrição 15'),
    ('Habilidade 16', 'Descrição 16'),
    ('Habilidade 17', 'Descrição 17'),
    ('Habilidade 18', 'Descrição 18'),
    ('Habilidade 19', 'Descrição 19'),
    ('Habilidade 20', 'Descrição 20'),
    ('Habilidade 21', 'Descrição 21'),
    ('Habilidade 22', 'Descrição 22'),
    ('Habilidade 23', 'Descrição 23'),
    ('Habilidade 24', 'Descrição 24'),
    ('Habilidade 25', 'Descrição 25');


INSERT INTO [Projeto_personagem] (name,habilidade_1,habilidade_2,habilidade_3)
VALUES
	('Personagem 1', 'Habilidade 1', 'Habilidade 2', 'Habilidade 3'),
    ('Personagem 2', 'Habilidade 4', 'Habilidade 5', 'Habilidade 6'),
    ('Personagem 3', 'Habilidade 7', 'Habilidade 8', 'Habilidade 9'),
    ('Personagem 4', 'Habilidade 10', 'Habilidade 11', 'Habilidade 12'),
    ('Personagem 5', 'Habilidade 13', 'Habilidade 14', 'Habilidade 15');


--SET IDENTITY_INSERT Projeto_jogador ON
INSERT INTO [Projeto_jogador] (name,region,nick,personagem_name)
VALUES
	('Rafael Curado','Aveiro','rafa','Personagem 1'),
	('Elmo Powers','Tamil Nadu','consectetuer','Personagem 1'),
	('Tallulah Edwards','Salzburg','enim','Personagem 1'),
	('Matthew Norris','Special Region of Yogyakarta','Cum','Personagem 1'),
	('Jocelyn Sawyer','Santa Catarina','urna.','Personagem 1'),
	('Brandon Stanley','Newfoundland and Labrador','mi','Personagem 1'),
	('Halee Alford','Puno','penatibus','Personagem 1'),
	('Carter Diaz','FATA','Nullam','Personagem 1'),
	('Ezekiel Romero','Hải Phòng','Vivamus','Personagem 1'),
	('Ivory Francis','Oyo','lectus','Personagem 1');
--SET IDENTITY_INSERT Projeto_jogador OFF

INSERT INTO [Projeto_treinador] (name,region)
VALUES
	('John Doe', 'North America'),
	('Jane Smith', 'Europe');


INSERT INTO [Projeto_torneio] (name,date,region)
VALUES
	  ('Caleb Stuart','Sep 9, 2023','Nova Scotia'),
	  ('Nigel Williams','Mar 30, 2024','Central Region');

  -- PRA JÁ, TER SÓ 5 PERSONAGENS



INSERT INTO [Projeto_equipa] ([id_jogador1], [id_jogador2], [id_jogador3], [id_jogador4], [id_jogador5],[id_treinador], [nome], [country], [region])
VALUES
    (1, 2, 3, 4, 5, 1, 'Team 1', 'Country 1', 'Region 1'),
    (6, 7, 8, 9, 10, 2, 'Team 2', 'Country 2', 'Region 2');
    --(11, 12, 13, 14, 15, 'Team 3', 'Country 3', 'Region 3'),
    --(16, 17, 18, 19, 20, 'Team 4', 'Country 4', 'Region 4'),
	-- pra já só da para ter 2 equipas


INSERT INTO [Projeto_jogo] ([id_equipa1], [id_equipa2], [id_torneio], [date], [result], [duration])
VALUES
    (1, 2, 1, '2023-05-01', 'Team 1 wins', 30),
    (1, 2, 1, '2023-05-02', 'Team 2 wins', 45),
    (1, 2, 1, '2023-05-03', 'Draw', 60);
	-- vai ter de ter restriçao no resultado para ter de conter as equipas desse jogo



INSERT INTO [Projeto_ranking] ([position], [id_jogador], [score])
VALUES
    (1, 3, 1500),
    (2, 4, 1350),
    (3, 1, 1420),
    (4, 10, 1625),
    (5, 9, 1485),
    (6, 5, 1550),
    (7, 8, 1315),
    (8, 2, 1432),
    (9, 6, 1398),
    (10, 7, 1520);

INSERT INTO [Projeto_transactions] ([type], [date], [value], [id_jogador])
VALUES
    ('Purchase', '2023-05-01', 100, 1),
    ('Withdrawal', '2023-05-03', 50, 2),
    ('Deposit', '2023-05-05', 200, 3),
    ('Purchase', '2023-05-07', 80, 4),
    ('Withdrawal', '2023-05-09', 30, 5);


INSERT INTO [Projeto_settings] ([id_jogador], [language], [platform])
VALUES
	(1, 'English', 'PC'),
	(2, 'Spanish', 'PS4'),
	(3, 'French', 'Xbox'),
	(4, 'German', 'PC'),
	(5, 'Italian', 'PC'),
	(6, 'English', 'Xbox'),
	(7, 'Spanish', 'PC'),
	(8, 'French', 'PS4'),
	(9, 'German', 'Xbox'),
	(10, 'Italian', 'PC');

--INSERT INTO [Projeto_item] ([name], [price], [type])
--VALUES
--    ('Item 1', 10, 'damage'),
--    ('Item 2', 15, 'power'),
--    ('Item 3', 20, 'tank'),
--    ('Item 4', 12, 'support'),
--    ('Item 5', 8, 'damage'),
--    ('Item 6', 25, 'power'),
--    ('Item 7', 18, 'tank'),
--    ('Item 8', 30, 'support'),
--    ('Item 9', 14, 'damage'),
--    ('Item 10', 22, 'power');

--INSERT INTO Projeto_inventory (id_jogador, id_jogo, item1, item2, item3) 
--VALUES
--	(1, 101, 'Sword', 'Shield', 'Potion'),
--	(1, 101, 'Bow', 'Arrows', 'Health Potion'),
--	(2, 103, 'Magic Wand', 'Spellbook', 'Mana Potion'),
--	(2, 103, 'Dagger', 'Cloak', 'Antidote'),
--	(3, 102, 'Staff', 'Robe', 'Scroll of Fireball'),
--	(3, 102, 'Axe', 'Helmet', 'Elixir of Strength'),
--	(4, 101, 'Spear', 'Armor', 'Healing Potion'),
--	(4, 101, 'Crossbow', 'Bolts', 'Energy Drink'),
--	(5, 104, 'Rapier', 'Leather Armor', 'Poison Vial'),
--	(5, 104, 'Hammer', 'Chainmail', 'Scroll of Protection'),
--	(6, 103, 'Katana', 'Ninja Outfit', 'Smoke Bomb'),
--	(6, 103, 'Mace', 'Plate Armor', 'Scroll of Healing'),
--	(7, 102, 'Warhammer', 'Gauntlets', 'Elixir of Defense'),
--	(7, 102, 'Dagger', 'Cape', 'Invisibility Potion'),
--	(8, 101, 'Greatsword', 'Heavy Shield', 'Resurrection Scroll'),
--	(8, 101, 'Longbow', 'Quiver', 'Scroll of Agility'),
--	(9, 104, 'Scimitar', 'Scale Mail', 'Potion of Speed'),
--	(9, 104, 'Battle Axe', 'Helmet', 'Scroll of Knowledge'),
--	(10, 103, 'Wand of Lightning', 'Robe', 'Scroll of Teleportation'),
--	(10, 103, 'Dual Blades', 'Assassins Cloak', 'Potion of Invisibility'),
--	(11, 102, 'Halberd', 'Plate Armor', 'Elixir of Vitality'),
--	(11, 102, 'Throwing Knives', 'Hood', 'Scroll of Paralysis'),
--	(12, 101, 'Flail', 'Tower Shield', 'Potion of Strength'),
--	(12, 101, 'Shortbow', 'Poison Arrows', 'Scroll of Precision'),
--	(13, 104, 'Rapier', 'Chainmail', 'Potion of Healing'),
--	(13, 104, 'Warhammer', 'Plate Armor', 'Scroll of Protection'),
--	(14, 103, 'Staff of Frost', 'Mage Robe', 'Mana Elixir'),
--	(14, 103, 'Claws', 'Leather Armor', 'Scroll of Stealth'),
--	(15, 102, 'Sword of Justice', 'Knight Armor', 'Potion of Defense'),
--	(15, 102, 'Dagger', 'Cape of Invisibility', 'Scroll of Shadows');

