namespace SOLID.Services.BriefObjectData
{
    public class Car_BriefDataService : BriefObjectDataServiceBase
    {
        // pretend to be External Storage
        public string[] Data =
        {
            "Fiat",
            "Mazda",
            "Geely",
            "Ford",
        };

        public override string[] GetObjectsBriefData()
        {
            return Data;
        }
    }
}
