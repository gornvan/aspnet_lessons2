

using lesson3_Patterns_Creational;

var elfCharacterFabric = new CharacterFabric("Elf");
var owlbearCharacterFabric = new CharacterFabric("Owlbear");
var humanCharacterFabric = new CharacterFabric("Human");

var stage = new Stage([elfCharacterFabric, owlbearCharacterFabric, humanCharacterFabric]);

var characters = stage.GenerateTroup_RedHood();

foreach (var character in characters)
{
    Console.WriteLine($@"There is a(n) {character.Race} who is {character.Age} and they want to {character.Goal}!");
}