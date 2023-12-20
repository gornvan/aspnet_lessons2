namespace lesson3_Patterns_Creational
{
    internal interface ICharacterFabric
    {
        Character CreateCharacter(int age, string goal);
    }
}