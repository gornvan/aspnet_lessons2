namespace lesson3_Patterns_Creational
{
    internal class CharacterFabric : ICharacterFabric
    {
        // Configurability!
        private string _race;

        // better yet - use an enum instead of the string
        public CharacterFabric(string race /* for example, address of database */) {
        // Configurability!
            _race = race;
        }

        public Character CreateCharacter(int age, string goal)
        {
            // write this to database while creating
            // or request for data somewhere else
            return new Character {
                Age = age,
                Goal = goal,
                Race = _race
            };
        }
    }
}
