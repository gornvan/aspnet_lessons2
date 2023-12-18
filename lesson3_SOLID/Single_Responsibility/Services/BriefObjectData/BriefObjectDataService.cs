namespace SOLID.Services.BriefObjectData
{
    public abstract class BriefObjectDataServiceBase
    {
        public string[] Data =
        {
            // This means that the objects descriptions are returned one-by-one in the Data array
            "object 1 - big",
            "object 2 - blue",
            "object 3 - red",
        };

        public virtual string[] GetObjectsBriefData()
        {
            return Data;
        }
    }
}
