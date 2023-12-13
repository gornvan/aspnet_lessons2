namespace lesson2_unit_testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            var speed = random.Next() * 10 + 5;

            var lovelyDistance = random.Next() * 100 + 15;

            var cat = new Cat(lovelyDistance, speed);

            Console.WriteLine("Would the cat like to run 50m: " + cat.WantToRun([50]));
        }
    }
}
