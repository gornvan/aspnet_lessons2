namespace SOLID.CQS.Queries
{
    public class GetObjectsBriefData : IQuery
    {
        public string[] Data =
        {
            // This means that the objects descriptions are returned one-by-one in the Data array
            "object 1 - big",
            "object 2 - blue",
            "object 3 - red",
        };


        public string[] Execute()
        {
            return Data;
        }
    }
}
