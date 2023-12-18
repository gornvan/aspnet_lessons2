namespace SOLID.Services.BriefObjectData
{
    public interface IBriefObjectDataService
    {
        void WriteObjectsBriefData(string[] objectsBriefData);

        string[] GetObjectsBriefData();
    }
}
