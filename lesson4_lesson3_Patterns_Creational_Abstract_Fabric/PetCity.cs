using lesson4_lesson3_Patterns_Creational_Abstract_Fabric.Contracts;
using lesson4_lesson3_Patterns_Creational_Abstract_Fabric.Pets;

namespace lesson4_lesson3_Patterns_Creational_Abstract_Fabric
{
    internal class CatCity
    {
        private IHouseFabric<Cat> _houseFabric;

        public CatCity(IHouseFabric<Cat> houseFabric) {
            _houseFabric = houseFabric;
        }

        public void Populate(int numberOfCats)
        {
            var house = _houseFabric.CreateHouse();

            // create enough houses, to provide for all the cats
            Console.WriteLine($@"All {numberOfCats} cats have nice houses with area of {house.Area}!");
        }
    }
}
