

using lesson4_Pattens_Structural_adapter;

IStoryWriter writer = new StoryWriter_File(new StreamWriter("story.txt"));

await writer.WriteChapterAsync("Chapter 1: Prologue", "And there were three hobbits...");
await writer.WriteChapterAsync("Chapter 2: Departure", "And there were three hobbits elsewhere...");
await writer.WriteChapterAsync("Chapter 3: Meeting", "And there were more hobbits...");
