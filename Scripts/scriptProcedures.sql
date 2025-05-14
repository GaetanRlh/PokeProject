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