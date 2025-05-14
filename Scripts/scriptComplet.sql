DROP TABLE IF EXISTS tbl_pokemons;
CREATE TABLE IF NOT EXISTS tbl_pokemons(
	PokemonId INT PRIMARY KEY,
    PokemonSound VARCHAR(150) NOT NULL,
    PokemonSpriteFront VARCHAR(150) NOT NULL,
    PokemonName VARCHAR(25) NOT NULL
);

DROP TABLE IF EXISTS tbl_items;
CREATE TABLE IF NOT EXISTS tbl_items(
	ItemId INT PRIMARY KEY,
    ItemName VARCHAR(25) NOT NULL,
    ItemSprite VARCHAR(150) NOT NULL,
    ItemPrice DECIMAL NOT NULL DEFAULT 0
);

DROP TABLE IF EXISTS tbl_inventairepokemon;
CREATE TABLE IF NOT EXISTS tbl_inventairepokemon(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    PokemonId INT DEFAULT 0 REFERENCES tbl_pokemons(PokemonId)
);

DROP TABLE IF EXISTS tbl_inventaireitem;
CREATE TABLE IF NOT EXISTS tbl_inventaireitem(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    ItemId INT DEFAULT 0 REFERENCES tbl_items(ItemId)
);

/* Procédure Stockée pour ajouter les Pokémons */

DELIMITER $$

DROP PROCEDURE IF EXISTS ajouter_pokemon$$
CREATE PROCEDURE ajouter_pokemon(
    IN pokemon_id INT,
    IN pokemon_sound VARCHAR(150),
	IN pokemon_sprite_front VARCHAR(150),
    IN pokemon_name VARCHAR(25)
)
BEGIN
    INSERT INTO tbl_pokemons (PokemonId, PokemonSound, PokemonSpriteFront, PokemonName)
    VALUES (pokemon_id, pokemon_sound, pokemon_sprite_front, pokemon_name);
END $$

DELIMITER ;

/* Procédure Stockée pour ajouter les items */

DELIMITER $$

DROP PROCEDURE IF EXISTS ajouter_item$$
CREATE PROCEDURE ajouter_item(
	IN item_id INT,
    IN item_name VARCHAR(25),
    IN item_sprite VARCHAR(150),
    IN item_price DECIMAL
)
BEGIN
	INSERT INTO tbl_items (ItemId, ItemName, ItemSprite, ItemPrice)
    VALUES (item_id, item_name, item_sprite, item_price);
END $$

DELIMITER ;

/* Procédure Stockée pour ajouter les Pokémons à l'inventaire */

DELIMITER $$

DROP PROCEDURE IF EXISTS inventaire_pokemon$$
CREATE PROCEDURE inventaire_pokemon(
    IN pokemon_id INT
)
BEGIN
	INSERT INTO tbl_inventairepokemon (PokemonId)
    VALUES (pokemon_id);
END $$

DELIMITER ;

/* Procédure Stockée pour ajouter les items à l'inventaire */

DELIMITER $$

DROP PROCEDURE IF EXISTS inventaire_items$$
CREATE PROCEDURE inventaire_items(
	IN item_id INT
)
BEGIN
	INSERT INTO tbl_inventaireitem (ItemId)
    VALUES (item_id);
END $$

DELIMITER ;

/* Insertion */

/* Items */
CALL ajouter_item(
	1,
    "Pokéball",
    "https://grid-paint.com/images/png/2017/11/10/4909218658254848.png",
    100
);

CALL ajouter_item(
	2,
    "Greatball",
    "https://grid-paint.com/images/png/2017/11/10/5993222098649088.png",
    250
);

CALL ajouter_item(
	3,
    "Masterball",
    "http://pngkey.com/png/full/228-2289979_master-ball-pixel-art-pokemon-pokeball.png",
    500
);

/* Inventaire */

CALL inventaire_items(
	1
);

CALL inventaire_items(
	1
);

CALL inventaire_items(
	1
);

/* Pokémon */

                CALL ajouter_pokemon(
                1, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/1.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png', 
                'bulbasaur');
                


                CALL ajouter_pokemon(
                2, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/2.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/2.png', 
                'ivysaur');
                


                CALL ajouter_pokemon(
                3, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/3.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/3.png', 
                'venusaur');
                


                CALL ajouter_pokemon(
                4, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/4.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/4.png', 
                'charmander');
                


                CALL ajouter_pokemon(
                5, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/5.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/5.png', 
                'charmeleon');
                


                CALL ajouter_pokemon(
                6, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/6.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/6.png', 
                'charizard');
                


                CALL ajouter_pokemon(
                7, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/7.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/7.png', 
                'squirtle');
                


                CALL ajouter_pokemon(
                8, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/8.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/8.png', 
                'wartortle');
                


                CALL ajouter_pokemon(
                9, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/9.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/9.png', 
                'blastoise');
                


                CALL ajouter_pokemon(
                10, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/10.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/10.png', 
                'caterpie');
                


                CALL ajouter_pokemon(
                11, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/11.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/11.png', 
                'metapod');
                


                CALL ajouter_pokemon(
                12, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/12.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/12.png', 
                'butterfree');
                


                CALL ajouter_pokemon(
                13, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/13.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/13.png', 
                'weedle');
                


                CALL ajouter_pokemon(
                14, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/14.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/14.png', 
                'kakuna');
                


                CALL ajouter_pokemon(
                15, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/15.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/15.png', 
                'beedrill');
                


                CALL ajouter_pokemon(
                16, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/16.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/16.png', 
                'pidgey');
                


                CALL ajouter_pokemon(
                17, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/17.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/17.png', 
                'pidgeotto');
                


                CALL ajouter_pokemon(
                18, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/18.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/18.png', 
                'pidgeot');
                


                CALL ajouter_pokemon(
                19, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/19.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/19.png', 
                'rattata');
                


                CALL ajouter_pokemon(
                20, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/20.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/20.png', 
                'raticate');
                


                CALL ajouter_pokemon(
                21, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/21.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/21.png', 
                'spearow');
                


                CALL ajouter_pokemon(
                22, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/22.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/22.png', 
                'fearow');
                


                CALL ajouter_pokemon(
                23, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/23.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/23.png', 
                'ekans');
                


                CALL ajouter_pokemon(
                24, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/24.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/24.png', 
                'arbok');
                


                CALL ajouter_pokemon(
                25, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/25.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/25.png', 
                'pikachu');
                


                CALL ajouter_pokemon(
                26, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/26.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/26.png', 
                'raichu');
                


                CALL ajouter_pokemon(
                27, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/27.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/27.png', 
                'sandshrew');
                


                CALL ajouter_pokemon(
                28, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/28.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/28.png', 
                'sandslash');
                


                CALL ajouter_pokemon(
                29, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/29.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/29.png', 
                'nidoran-f');
                


                CALL ajouter_pokemon(
                30, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/30.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/30.png', 
                'nidorina');
                


                CALL ajouter_pokemon(
                31, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/31.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/31.png', 
                'nidoqueen');
                


                CALL ajouter_pokemon(
                32, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/32.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/32.png', 
                'nidoran-m');
                


                CALL ajouter_pokemon(
                33, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/33.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/33.png', 
                'nidorino');
                


                CALL ajouter_pokemon(
                34, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/34.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/34.png', 
                'nidoking');
                


                CALL ajouter_pokemon(
                35, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/35.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/35.png', 
                'clefairy');
                


                CALL ajouter_pokemon(
                36, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/36.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/36.png', 
                'clefable');
                


                CALL ajouter_pokemon(
                37, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/37.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/37.png', 
                'vulpix');
                


                CALL ajouter_pokemon(
                38, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/38.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/38.png', 
                'ninetales');
                


                CALL ajouter_pokemon(
                39, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/39.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/39.png', 
                'jigglypuff');
                


                CALL ajouter_pokemon(
                40, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/40.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/40.png', 
                'wigglytuff');
                


                CALL ajouter_pokemon(
                41, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/41.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/41.png', 
                'zubat');
                


                CALL ajouter_pokemon(
                42, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/42.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/42.png', 
                'golbat');
                


                CALL ajouter_pokemon(
                43, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/43.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/43.png', 
                'oddish');
                


                CALL ajouter_pokemon(
                44, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/44.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/44.png', 
                'gloom');
                


                CALL ajouter_pokemon(
                45, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/45.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/45.png', 
                'vileplume');
                


                CALL ajouter_pokemon(
                46, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/46.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/46.png', 
                'paras');
                


                CALL ajouter_pokemon(
                47, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/47.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/47.png', 
                'parasect');
                


                CALL ajouter_pokemon(
                48, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/48.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/48.png', 
                'venonat');
                


                CALL ajouter_pokemon(
                49, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/49.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/49.png', 
                'venomoth');
                


                CALL ajouter_pokemon(
                50, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/50.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/50.png', 
                'diglett');
                


                CALL ajouter_pokemon(
                51, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/51.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/51.png', 
                'dugtrio');
                


                CALL ajouter_pokemon(
                52, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/52.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/52.png', 
                'meowth');
                


                CALL ajouter_pokemon(
                53, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/53.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/53.png', 
                'persian');
                


                CALL ajouter_pokemon(
                54, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/54.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/54.png', 
                'psyduck');
                


                CALL ajouter_pokemon(
                55, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/55.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/55.png', 
                'golduck');
                


                CALL ajouter_pokemon(
                56, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/56.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/56.png', 
                'mankey');
                


                CALL ajouter_pokemon(
                57, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/57.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/57.png', 
                'primeape');
                


                CALL ajouter_pokemon(
                58, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/58.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/58.png', 
                'growlithe');
                


                CALL ajouter_pokemon(
                59, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/59.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/59.png', 
                'arcanine');
                


                CALL ajouter_pokemon(
                60, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/60.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/60.png', 
                'poliwag');
                


                CALL ajouter_pokemon(
                61, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/61.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/61.png', 
                'poliwhirl');
                


                CALL ajouter_pokemon(
                62, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/62.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/62.png', 
                'poliwrath');
                


                CALL ajouter_pokemon(
                63, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/63.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/63.png', 
                'abra');
                


                CALL ajouter_pokemon(
                64, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/64.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/64.png', 
                'kadabra');
                


                CALL ajouter_pokemon(
                65, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/65.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/65.png', 
                'alakazam');
                


                CALL ajouter_pokemon(
                66, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/66.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/66.png', 
                'machop');
                


                CALL ajouter_pokemon(
                67, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/67.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/67.png', 
                'machoke');
                


                CALL ajouter_pokemon(
                68, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/68.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/68.png', 
                'machamp');
                


                CALL ajouter_pokemon(
                69, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/69.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/69.png', 
                'bellsprout');
                


                CALL ajouter_pokemon(
                70, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/70.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/70.png', 
                'weepinbell');
                


                CALL ajouter_pokemon(
                71, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/71.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/71.png', 
                'victreebel');
                


                CALL ajouter_pokemon(
                72, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/72.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/72.png', 
                'tentacool');
                


                CALL ajouter_pokemon(
                73, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/73.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/73.png', 
                'tentacruel');
                


                CALL ajouter_pokemon(
                74, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/74.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/74.png', 
                'geodude');
                


                CALL ajouter_pokemon(
                75, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/75.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/75.png', 
                'graveler');
                


                CALL ajouter_pokemon(
                76, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/76.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/76.png', 
                'golem');
                


                CALL ajouter_pokemon(
                77, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/77.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/77.png', 
                'ponyta');
                


                CALL ajouter_pokemon(
                78, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/78.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/78.png', 
                'rapidash');
                


                CALL ajouter_pokemon(
                79, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/79.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/79.png', 
                'slowpoke');
                


                CALL ajouter_pokemon(
                80, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/80.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/80.png', 
                'slowbro');
                


                CALL ajouter_pokemon(
                81, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/81.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/81.png', 
                'magnemite');
                


                CALL ajouter_pokemon(
                82, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/82.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/82.png', 
                'magneton');
                


                CALL ajouter_pokemon(
                83, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/83.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/83.png', 
                'farfetchd');
                


                CALL ajouter_pokemon(
                84, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/84.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/84.png', 
                'doduo');
                


                CALL ajouter_pokemon(
                85, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/85.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/85.png', 
                'dodrio');
                


                CALL ajouter_pokemon(
                86, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/86.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/86.png', 
                'seel');
                


                CALL ajouter_pokemon(
                87, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/87.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/87.png', 
                'dewgong');
                


                CALL ajouter_pokemon(
                88, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/88.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/88.png', 
                'grimer');
                


                CALL ajouter_pokemon(
                89, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/89.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/89.png', 
                'muk');
                


                CALL ajouter_pokemon(
                90, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/90.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/90.png', 
                'shellder');
                


                CALL ajouter_pokemon(
                91, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/91.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/91.png', 
                'cloyster');
                


                CALL ajouter_pokemon(
                92, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/92.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/92.png', 
                'gastly');
                


                CALL ajouter_pokemon(
                93, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/93.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/93.png', 
                'haunter');
                


                CALL ajouter_pokemon(
                94, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/94.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/94.png', 
                'gengar');
                


                CALL ajouter_pokemon(
                95, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/95.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/95.png', 
                'onix');
                


                CALL ajouter_pokemon(
                96, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/96.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/96.png', 
                'drowzee');
                


                CALL ajouter_pokemon(
                97, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/97.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/97.png', 
                'hypno');
                


                CALL ajouter_pokemon(
                98, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/98.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/98.png', 
                'krabby');
                


                CALL ajouter_pokemon(
                99, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/99.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/99.png', 
                'kingler');
                


                CALL ajouter_pokemon(
                100, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/100.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/100.png', 
                'voltorb');
                


                CALL ajouter_pokemon(
                101, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/101.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/101.png', 
                'electrode');
                


                CALL ajouter_pokemon(
                102, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/102.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/102.png', 
                'exeggcute');
                


                CALL ajouter_pokemon(
                103, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/103.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/103.png', 
                'exeggutor');
                


                CALL ajouter_pokemon(
                104, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/104.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/104.png', 
                'cubone');
                


                CALL ajouter_pokemon(
                105, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/105.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/105.png', 
                'marowak');
                


                CALL ajouter_pokemon(
                106, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/106.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/106.png', 
                'hitmonlee');
                


                CALL ajouter_pokemon(
                107, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/107.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/107.png', 
                'hitmonchan');
                


                CALL ajouter_pokemon(
                108, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/108.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/108.png', 
                'lickitung');
                


                CALL ajouter_pokemon(
                109, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/109.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/109.png', 
                'koffing');
                


                CALL ajouter_pokemon(
                110, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/110.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/110.png', 
                'weezing');
                


                CALL ajouter_pokemon(
                111, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/111.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/111.png', 
                'rhyhorn');
                


                CALL ajouter_pokemon(
                112, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/112.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/112.png', 
                'rhydon');
                


                CALL ajouter_pokemon(
                113, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/113.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/113.png', 
                'chansey');
                


                CALL ajouter_pokemon(
                114, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/114.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/114.png', 
                'tangela');
                


                CALL ajouter_pokemon(
                115, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/115.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/115.png', 
                'kangaskhan');
                


                CALL ajouter_pokemon(
                116, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/116.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/116.png', 
                'horsea');
                


                CALL ajouter_pokemon(
                117, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/117.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/117.png', 
                'seadra');
                


                CALL ajouter_pokemon(
                118, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/118.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/118.png', 
                'goldeen');
                


                CALL ajouter_pokemon(
                119, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/119.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/119.png', 
                'seaking');
                


                CALL ajouter_pokemon(
                120, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/120.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/120.png', 
                'staryu');
                


                CALL ajouter_pokemon(
                121, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/121.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/121.png', 
                'starmie');
                


                CALL ajouter_pokemon(
                122, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/122.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/122.png', 
                'mr-mime');
                


                CALL ajouter_pokemon(
                123, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/123.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/123.png', 
                'scyther');
                


                CALL ajouter_pokemon(
                124, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/124.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/124.png', 
                'jynx');
                


                CALL ajouter_pokemon(
                125, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/125.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/125.png', 
                'electabuzz');
                


                CALL ajouter_pokemon(
                126, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/126.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/126.png', 
                'magmar');
                


                CALL ajouter_pokemon(
                127, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/127.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/127.png', 
                'pinsir');
                


                CALL ajouter_pokemon(
                128, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/128.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/128.png', 
                'tauros');
                


                CALL ajouter_pokemon(
                129, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/129.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/129.png', 
                'magikarp');
                


                CALL ajouter_pokemon(
                130, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/130.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/130.png', 
                'gyarados');
                


                CALL ajouter_pokemon(
                131, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/131.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/131.png', 
                'lapras');
                


                CALL ajouter_pokemon(
                132, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/132.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/132.png', 
                'ditto');
                


                CALL ajouter_pokemon(
                133, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/133.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/133.png', 
                'eevee');
                


                CALL ajouter_pokemon(
                134, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/134.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/134.png', 
                'vaporeon');
                


                CALL ajouter_pokemon(
                135, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/135.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/135.png', 
                'jolteon');
                


                CALL ajouter_pokemon(
                136, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/136.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/136.png', 
                'flareon');
                


                CALL ajouter_pokemon(
                137, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/137.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/137.png', 
                'porygon');
                


                CALL ajouter_pokemon(
                138, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/138.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/138.png', 
                'omanyte');
                


                CALL ajouter_pokemon(
                139, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/139.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/139.png', 
                'omastar');
                


                CALL ajouter_pokemon(
                140, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/140.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/140.png', 
                'kabuto');
                


                CALL ajouter_pokemon(
                141, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/141.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/141.png', 
                'kabutops');
                


                CALL ajouter_pokemon(
                142, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/142.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/142.png', 
                'aerodactyl');
                


                CALL ajouter_pokemon(
                143, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/143.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/143.png', 
                'snorlax');
                


                CALL ajouter_pokemon(
                144, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/144.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/144.png', 
                'articuno');
                


                CALL ajouter_pokemon(
                145, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/145.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/145.png', 
                'zapdos');
                


                CALL ajouter_pokemon(
                146, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/146.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/146.png', 
                'moltres');
                


                CALL ajouter_pokemon(
                147, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/147.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/147.png', 
                'dratini');
                


                CALL ajouter_pokemon(
                148, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/148.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/148.png', 
                'dragonair');
                


                CALL ajouter_pokemon(
                149, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/149.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/149.png', 
                'dragonite');
                


                CALL ajouter_pokemon(
                150, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/150.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/150.png', 
                'mewtwo');
                


                CALL ajouter_pokemon(
                151, 
                'https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/151.ogg', 
                'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/151.png', 
                'mew');