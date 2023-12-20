using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace lesson4_singleton
{
    internal static class Program
    {
        public static async Task Main()
        {
            var watch = new Stopwatch();

            watch.Start();
            await DoSafeIncrementation();
            Console.WriteLine($@"safe elapsed: {watch.ElapsedMilliseconds}");


            watch.Reset();
            watch.Start();
            await Program_Naive.mainAsync();
            Console.WriteLine($@"naive Elapsed: {watch.ElapsedMilliseconds}");
        }


        private static async Task DoSafeIncrementation()
        {
            int numberOfIncrementers = 1500;

            ThreadSafeCounter.Initialize(0);

            // imagine these Tasks are not all started from this exact place
            var tasks = Enumerable.Range(0, numberOfIncrementers)
                .Select(num => Task.Run(() =>
                {
                    var counter = ThreadSafeCounter.GetInstance();
                    counter.Increment();
                }
            ));

            await Task.WhenAll(tasks);

            Console.WriteLine($@"safe result: {ThreadSafeCounter.GetInstance().GetCurrentValue()}");
        }
    }
}
