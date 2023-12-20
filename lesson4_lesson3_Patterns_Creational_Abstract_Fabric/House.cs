using lesson4_lesson3_Patterns_Creational_Abstract_Fabric.Pets;

namespace lesson4_lesson3_Patterns_Creational_Abstract_Fabric
{
    internal class House<PetType> where PetType : PetBase
    {
        public double Area { get; set; }


        private List<PetType> _residents = new List<PetType>();

        void Contain(PetType pet)
        {
            _residents.Add(pet);
        }
    }
}
