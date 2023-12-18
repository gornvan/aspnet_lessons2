namespace SOLID.Services.BriefObjectData
{
    public class Shoes_BriefDataService : BriefObjectDataServiceBase
    {
        // pretend to be External Storage
        public string[] Data =
        {
            "Sneakers",
            "Red",  // This will become a problem
                    // when we'll want to generalize our solution
                    // which presents / verifies / converts such data for Customer

            "Shoes",
            "Black",

            "Clappers",
            "Blue",
        };

        public override string[] GetObjectsBriefData()
        {
            return Data;
        }
    }
}
