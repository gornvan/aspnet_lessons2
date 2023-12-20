
namespace lesson4_Pattens_Structural_adapter
{
    internal class StoryWriter_File : IStoryWriter, IDisposable
    {
        private StreamWriter _writer;

        public StoryWriter_File(string fileName) {
            _writer = new StreamWriter(fileName);
        }

        public async Task WriteChapterAsync(string chapterName, string text)
        {
            _writer.WriteLine("####");
            _writer.WriteLine($@"#### {chapterName} ####");
            _writer.WriteLine("####");
            _writer.WriteLine(text);

            await _writer.FlushAsync();
        }

        public void Dispose()
        {
            _writer.Close();
        }
    }
}
