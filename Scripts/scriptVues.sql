CREATE OR REPLACE VIEW vue_inventaire_complet AS
SELECT ip.Id AS InventairePokemonId, p.PokemonName AS Nom, 'Pokemon' AS Type
FROM tbl_inventairepokemon ip
JOIN tbl_pokemons p ON ip.PokemonId = p.PokemonId
UNION ALL
SELECT ii.Id AS InventaireItemId, i.ItemName AS Nom, 'Item' AS Type
FROM tbl_inventaireitem ii
JOIN tbl_items i ON ii.ItemId = i.ItemId;


CREATE OR REPLACE VIEW vue_pokemons_items AS
SELECT tp.Id AS pokemonId, tp.PokemonName AS Nom, 'Pokemon' AS Type
FROM tbl_pokemons tp
UNION ALL
SELECT ti.Id AS TableItemId, ti.ItemName AS Nom, 'Item' AS Type
FROM tbl_items ti