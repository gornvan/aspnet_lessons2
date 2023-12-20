namespace lesson3_Patterns_Creational
{
    internal class Stage
    {
        private ICharacterFabric[] _randomizingCharFabrics;

        public Stage(ICharacterFabric[] characterBaseSettingsRandomizingSources)
        {
            _randomizingCharFabrics = characterBaseSettingsRandomizingSources;
        }

        private Character GenerateCharacter(int age, string goal)
        {
            return Random.Shared
                .GetItems(_randomizingCharFabrics, 1)[0]
                .CreateCharacter(age, goal);
        }

        public Character[] GenerateTroup_RedHood()
        {
            var characterEater = GenerateCharacter(3, "Eat people");

            var mainCharacter = GenerateCharacter(13, "Bring food to Granny");

            var granny = GenerateCharacter(80, "Await main character");

            var hunter1 = GenerateCharacter(30, "Neutralize character eater");

            var hunger2 = GenerateCharacter(30, "Neutralize character eater");

            return [
                characterEater,
                mainCharacter,
                granny,
                hunter1,
                hunger2
            ];
        }
    }
}
