DELIMITER $$

CREATE TRIGGER before_insert_item_price_check
BEFORE INSERT ON tbl_items
FOR EACH ROW
BEGIN
    IF NEW.ItemPrice < 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Le prix de l’item ne peut pas être négatif.';
    END IF;
END $$

DELIMITER ;

DELIMITER $$

CREATE TRIGGER after_delete_pokemon_cleanup
AFTER DELETE ON tbl_pokemons
FOR EACH ROW
BEGIN
    DELETE FROM tbl_inventairepokemon WHERE PokemonId = OLD.PokemonId;
END $$

DELIMITER ;