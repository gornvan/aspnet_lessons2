using lesson4_lesson3_Patterns_Creational_Abstract_Fabric.Contracts;
using lesson4_lesson3_Patterns_Creational_Abstract_Fabric.Pets;

namespace lesson4_lesson3_Patterns_Creational_Abstract_Fabric
{
    internal class HouseFabric<PetType> : IHouseFabric<PetType>
        where PetType : PetBase
    {
        private double _defaultHouseArea;


        public HouseFabric(double defaultHouseArea)
        {
            _defaultHouseArea = defaultHouseArea;
        }

        public House<PetType> CreateHouse()
        {
            return new House<PetType>
            {
                Area = _defaultHouseArea,
            };
        }
    }
}
