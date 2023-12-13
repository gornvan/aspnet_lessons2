using lesson2___unit_testing.Contracts;

namespace lesson2_unit_testing
{
    public class Cat : IHunter
    {
        private double _funRunDistance;
        private double _speed;

        public Cat( double funRunDistance, double speed ) {
            _funRunDistance = funRunDistance;
            _speed = speed;
        }

        public void Voice()
        {
            Console.WriteLine("Meow!");
        }


        public bool OfferFood(Food food)
        {
            switch (food)
            {
                case Food.Fruit:
                case Food.Chips:
                    return false;

                case Food.Meat:
                case Food.Fish:
                    return true;

                default:
                    return false;
            }
        }

        public bool WantToRun(double[] DistancesInMetersToRun)
        {
            var totalDistance = DistancesInMetersToRun.Aggregate(
                (double)0.0d, // initialization of the aggreation
                (sum/*current result*/, current/*current aggregated value*/) 
                    => sum + current // return new result
            );

            return totalDistance <= _funRunDistance;
        }

        public bool CanCatch(IPrey prey)
        {
            return prey.GetSpeed_MetersPerSecond() < _speed;
        }

        public double GetSpeed_MetersPerSecond() => _speed;

        public double Speed_MetersPerSecond => _speed;
    }
}
