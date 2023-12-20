using lesson4_lesson3_Patterns_Creational_Abstract_Fabric.Pets;

namespace lesson4_lesson3_Patterns_Creational_Abstract_Fabric.Contracts
{
    internal interface IHouseFabric<PetType> where PetType : PetBase
    {
        House<PetType> CreateHouse();
    }
}
