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