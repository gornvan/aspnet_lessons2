
using lesson4_lesson3_Patterns_Creational_Abstract_Fabric;
using lesson4_lesson3_Patterns_Creational_Abstract_Fabric.Pets;

var catsHouseFabric = new HouseFabric<Cat>(20);

var catsCity = new CatCity(catsHouseFabric);

catsCity.Populate(100);