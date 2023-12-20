namespace lesson4_singleton
{
    internal class ThreadSafeCounter
    {
        // the INSTANCE we constrol
        private static ThreadSafeCounter _instance;

        // PRIVATE / protected constructor
        private ThreadSafeCounter(int start) {
            _counter = start;
        }

        // a controlled place for getting the instance
        public static ThreadSafeCounter GetInstance()
        {
            if (_instance!= null)
            {
                return _instance;
            }

            _instance = new ThreadSafeCounter(0);
            return _instance;
        }

        //
        //
        //
        //
        // the rest is for thread-safe counting

        public static void Initialize(int start)
        {
            _instance = new ThreadSafeCounter(start);
        }

        private static object ObjectForLocking = new { data = "dummy" };

        private int _counter;

        public int GetCurrentValue() => _counter;

        public void Increment()
        {
            lock (this) // can as well use ObjectForLocking
            {
                _counter++;
            }
        }
    }
}
