namespace lesson4_singleton
{
    internal static class Program_Naive
    {
        public static async Task mainAsync()
        {
            int counter = 0;
            int numberOfIncrementers = 1500;

            var tasks = Enumerable.Range(0, numberOfIncrementers)
                .Select(num => Task.Run(() =>
                {
                    counter++;
                }
            ));

            await Task.WhenAll(tasks);

            Console.WriteLine($@"naive result: {counter}");
        }
    }
}
