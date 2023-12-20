namespace lesson4_Pattens_Structural_adapter
{
    internal interface IStoryWriter // an adapter for writing the text Chapters-by-Chapter
    {
        Task WriteChapterAsync(string chapterName, string text);
    }
}
