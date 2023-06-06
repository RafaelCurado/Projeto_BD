USE p1g1
GO

INSERT INTO [Projeto_habilidade] ([name], [descricao])
VALUES
    ('Fireball', 'Launch a blazing projectile that engulfs enemies in flames, dealing area-of-effect damage'),
    ('Stealth Strike', 'Temporarily cloak yourself and perform a devastating surprise attack on an unsuspecting enemy'),
    ('Healing Aura', 'Emit a soothing aura that gradually restores health to nearby allies over time'),
    ('Thunderbolt', 'Call down a powerful bolt of lightning from the sky, striking enemies with electrifying force.'),
    ('Time Warp', 'Manipulate time, slowing down enemies movement and granting you increased speed and reaction time.'),
    ('Shadowstep', 'Instantly teleport behind an enemy, catching them off guard and gaining a positional advantage.'),
    ('Frost Nova', 'Unleash a freezing shockwave that immobilizes nearby enemies, leaving them vulnerable to attacks.'),
    ('Precision Shot', 'Focus your aim and release a highly accurate shot, dealing critical damage to a single target.'),
    ('Energy Shield', 'Create a protective barrier that absorbs incoming damage, granting temporary invulnerability.'),
    ('Toxic Cloud', 'Release a toxic cloud that poisons enemies within its area, gradually draining their health.'),
    ('Berserker Rage', 'Enter a state of frenzied strength, enhancing your attack power and speed for a limited time.'),
    ('Telekinesis', 'Harness the power of the mind to manipulate objects or enemies from a distance.'),
    ('Sonic Blast', 'Emit a powerful sonic wave that disorients and stuns enemies in its path.'),
    ('Gravity Well', 'Generate a localized gravitational field that pulls enemies towards a central point, immobilizing them.'),
    ('Divine Shield', 'Invoke a divine shield that renders you immune to all incoming damage for a short duration.');
   


INSERT INTO [Projeto_personagem] (name,habilidade_1,habilidade_2,habilidade_3)
VALUES
	('Sylvan', 'Fireball', 'Stealth Strike', 'Healing Aura'),
	('Aurora', 'Time Warp', 'Shadowstep', 'Precision Shot'),
	('Glacier', 'Frost Nova', 'Energy Shield', 'Toxic Cloud'),
	('Ragnar', 'Berserker Rage', 'Telekinesis', 'Sonic Blast'),
	('Valeria', 'Thunderbolt', 'Gravity Well', 'Divine Shield');


INSERT INTO [Projeto_jogador] (name, region, nick, personagem_name, balance)
VALUES
    ('John Smith', 'North America', 'shadowBlade', 'Sylvan', FLOOR(RAND()*(451-50)+50)),
    ('Emma Johnson', 'Europe', 'SilentWraith', 'Aurora', FLOOR(RAND()*(451-50)+50)),
    ('Daniel Lee', 'Asia', 'frostShade', 'Glacier', FLOOR(RAND()*(451-50)+50)),
    ('Sophia Brown', 'South America', 'Ragnarock', 'Ragnar', FLOOR(RAND()*(451-50)+50)),
    ('Oliver Davis', 'Australia', 'voltstrike', 'Valeria', FLOOR(RAND()*(451-50)+50)),
    ('Emily Wilson', 'North America', 'blazeFury', 'Sylvan', FLOOR(RAND()*(451-50)+50)),
    ('William Anderson', 'Europe', 'phantomStalker', 'Aurora', FLOOR(RAND()*(451-50)+50)),
    ('Isabella Martinez', 'Asia', 'chillBane', 'Glacier', FLOOR(RAND()*(451-50)+50)),
    ('James Thompson', 'South America', 'doomSlinger', 'Ragnar', FLOOR(RAND()*(451-50)+50)),
    ('Sophia Clark', 'Australia', 'sparkNova', 'Valeria', FLOOR(RAND()*(451-50)+50)),
    ('Liam Garcia', 'North America', 'venomStrike', 'Sylvan', FLOOR(RAND()*(451-50)+50)),
    ('Olivia Rodriguez', 'Europe', 'serenityWhisper', 'Aurora', FLOOR(RAND()*(451-50)+50)),
    ('Noah Hernandez', 'Asia', 'frostbiteMaster', 'Glacier', FLOOR(RAND()*(451-50)+50)),
    ('Emma Flores', 'South America', 'savageShadow', 'Ragnar', FLOOR(RAND()*(451-50)+50)),
    ('Ava Green', 'Australia', 'novaStorm', 'Valeria', FLOOR(RAND()*(451-50)+50)),
    ('Mason Perez', 'North America', 'blitzBolt', 'Sylvan', FLOOR(RAND()*(451-50)+50)),
    ('Sophia Carter', 'Europe', 'whisperStrike', 'Aurora', FLOOR(RAND()*(451-50)+50)),
    ('Ethan Hill', 'Asia', 'blizzardMage', 'Glacier', FLOOR(RAND()*(451-50)+50)),
    ('Olivia Mitchell', 'South America', 'warriorFury', 'Ragnar', FLOOR(RAND()*(451-50)+50)),
    ('Aiden Hall', 'Australia', 'phoenixWing', 'Valeria', FLOOR(RAND()*(451-50)+50)),
	('Lucas Turner', 'North America', 'stormStrider', 'Sylvan', FLOOR(RAND()*(451-50)+50)),
    ('Charlotte Baker', 'Europe', 'moonDancer', 'Aurora', FLOOR(RAND()*(451-50)+50)),
    ('Logan Harris', 'Asia', 'frozenSoul', 'Glacier', FLOOR(RAND()*(451-50)+50)),
    ('Grace Young', 'South America', 'shadowFury', 'Ragnar', FLOOR(RAND()*(451-50)+50)),
    ('Benjamin Smith', 'Australia', 'thunderStrike', 'Valeria', FLOOR(RAND()*(451-50)+50));


INSERT INTO [Projeto_treinador] (name,region)
VALUES
	('John Doe', 'North America'),
	('Jane Smith', 'Europe'),
	('Michael Johnson', 'Asia'),
    ('Maria Lopez', 'South America'),
    ('David Lee', 'Australia');


INSERT INTO [Projeto_torneio] (name, date, region)
VALUES
    ('Caleb Stuart', 'Sep 9, 2023', 'Nova Scotia'),
    ('Nigel Williams', 'Mar 30, 2024', 'Central Region'),
    ('Sophie Turner', 'Jul 15, 2023', 'West Coast'),
    ('Lucas Silva', 'Nov 5, 2023', 'South Region'),
    ('Emily Chen', 'Apr 20, 2024', 'East Coast');


INSERT INTO [Projeto_equipa] ([id_jogador1], [id_jogador2], [id_jogador3], [id_jogador4], [id_jogador5], [id_treinador], [nome], [country], [region])
VALUES
    (1, 2, 3, 4, 5, 1, 'Golden Lions', 'United States', 'North America'),
    (6, 7, 8, 9, 10, 2, 'Royal Ravens', 'United Kingdom', 'Europe'),
	(11, 12, 13, 14, 15, 3, 'Shadow Reapers', 'Canada', 'North America'),
    (16, 17, 18, 19, 20, 4, 'Azure Dragons', 'China', 'Asia'),
    (21, 22, 23, 24, 25, 5, 'Savage Wolves', 'Brazil', 'South America');
 


INSERT INTO [Projeto_jogo] ([id_equipa1], [id_equipa2], [id_torneio], [date], [result], [duration])
VALUES
    (1, 2, 1, '2023-05-01', 'Golden Lions wins', 30),
    (1, 2, 1, '2023-05-02', 'Royal Ravens wins', 45),
    (1, 2, 1, '2023-05-03', 'Draw', 60),
    (3, 4, 2, '2023-05-04', 'Shadow Reapers wins', 35),
    (5, 3, 2, '2023-05-05', 'Azure Dragons wins', 50),
    (4, 5, 2, '2023-05-06', 'Draw', 55),
    (1, 3, 1, '2023-05-07', 'Golden Lions wins', 40),
    (2, 5, 1, '2023-05-08', 'Royal Ravens wins', 55),
    (4, 2, 1, '2023-05-09', 'Draw', 50),
    (3, 1, 2, '2023-05-10', 'Shadow Reapers wins', 60),
    (5, 4, 2, '2023-05-11', 'Azure Dragons wins', 45),
    (2, 3, 2, '2023-05-12', 'Draw', 55),
    (3, 1, 3, '2023-05-13', 'Golden Lions wins', 35),
    (4, 2, 3, '2023-05-14', 'Royal Ravens wins', 50),
    (5, 3, 3, '2023-05-15', 'Draw', 60),
    (1, 5, 4, '2023-05-16', 'Shadow Reapers wins', 40),
    (2, 4, 4, '2023-05-17', 'Azure Dragons wins', 45),
    (3, 5, 4, '2023-05-18', 'Draw', 55),
    (4, 1, 5, '2023-05-19', 'Golden Lions wins', 50),
    (5, 2, 5, '2023-05-20', 'Royal Ravens wins', 60),
    (2, 3, 3, '2023-05-21', 'Draw', 35),
    (1, 4, 2, '2023-05-22', 'Shadow Reapers wins', 40),
    (5, 1, 1, '2023-05-23', 'Azure Dragons wins', 55),
    (3, 2, 4, '2023-05-24', 'Draw', 50),
    (1, 5, 5, '2023-05-25', 'Golden Lions wins', 60),
    (4, 3, 3, '2023-05-26', 'Royal Ravens wins', 35),
    (2, 4, 2, '2023-05-27', 'Draw', 45),
    (3, 1, 1, '2023-05-28', 'Shadow Reapers wins', 50),
    (5, 2, 1, '2023-05-29', 'Azure Dragons wins', 60),
    (4, 5, 4, '2023-05-30', 'Draw', 35),
    (1, 3, 2, '2023-05-31', 'Golden Lions wins', 45),
    (3, 5, 3, '2023-06-01', 'Savage Wolves wins', 50),
    (4, 2, 2, '2023-06-02', 'Draw', 55),
    (2, 1, 3, '2023-06-03', 'Royal Ravens wins', 40);


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
    (10, 7, 1520),
    (11, 13, 1455),
    (12, 11, 1512),
    (13, 20, 1368),
    (14, 18, 1427),
    (15, 19, 1583),
    (16, 16, 1476),
    (17, 14, 1335),
    (18, 15, 1542),
    (19, 17, 1410),
    (20, 12, 1376),
    (21, 8, 1445),
    (22, 19, 1387),
    (23, 16, 1502),
    (24, 12, 1438),
    (25, 17, 1369);

INSERT INTO [Projeto_transactions] ([type], [date], [value], [id_jogador])
VALUES
    ('Purchase', '2023-05-01', 100, 1),
    ('Withdrawal', '2023-05-03', 50, 2),
    ('Deposit', '2023-05-05', 200, 3),
    ('Purchase', '2023-05-07', 80, 4),
    ('Withdrawal', '2023-05-09', 30, 5),
    ('Deposit', '2023-05-10', 150, 20),
    ('Purchase', '2023-05-12', 70, 6),
    ('Withdrawal', '2023-05-14', 20, 19),
    ('Deposit', '2023-05-16', 180, 18),
    ('Purchase', '2023-05-18', 90, 7),
    ('Withdrawal', '2023-05-20', 40, 8),
    ('Deposit', '2023-05-22', 220, 17),
    ('Purchase', '2023-05-24', 60, 16),
    ('Withdrawal', '2023-05-26', 10, 15),
    ('Deposit', '2023-05-28', 240, 9),
    ('Purchase', '2023-05-30', 50, 10),
    ('Withdrawal', '2023-06-01', 30, 11),
    ('Deposit', '2023-06-03', 260, 14),
    ('Purchase', '2023-06-05', 120, 13),
    ('Withdrawal', '2023-06-07', 70, 12),
    ('Deposit', '2023-06-09', 180, 25),
    ('Purchase', '2023-06-11', 90, 23),
    ('Withdrawal', '2023-06-13', 40, 21),
    ('Deposit', '2023-06-15', 220, 22),
    ('Purchase', '2023-06-17', 60, 24);


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
	(10, 'Italian', 'PC'),
	(11, 'English', 'PS4'),
    (12, 'Spanish', 'PC'),
    (13, 'French', 'Xbox'),
    (14, 'German', 'PC'),
    (15, 'Italian', 'PS4'),
    (16, 'English', 'Xbox'),
    (17, 'Spanish', 'PC'),
    (18, 'French', 'PS4'),
    (19, 'German', 'Xbox'),
    (20, 'Italian', 'PC'),
	(21, 'English', 'PS4'),
    (22, 'Spanish', 'PC'),
    (23, 'French', 'Xbox'),
    (24, 'German', 'PC'),
    (25, 'Italian', 'PS4');

