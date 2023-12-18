namespace SOLID.Services.BriefObjectData
{
    public class Person_BriefDataService : BriefObjectDataServiceBase
    {
        // pretend to be External Storage
        public string[] Data =
        {
            "Ivan",
            "Gena",
            "Helena",
            "Olya",
        };

        public override string[] GetObjectsBriefData()
        {
            return Data;
        }
    }
}
