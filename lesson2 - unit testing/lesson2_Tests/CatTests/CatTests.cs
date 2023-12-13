using lesson2___unit_testing.Contracts;
using lesson2_unit_testing;
using Moq;

namespace lesson2_Tests.CatTests
{
    public class CatTests : IDisposable
    {
        const double CatSpeed = 7;

        private Cat _cat;
        private double _catsFunRunDistance;
        private double _catsSpeed;

        // runs before every test case (Fact/InlineData)
        // https://xunit.net/docs/shared-context
        public CatTests()
        {
            _catsFunRunDistance = 150;
            _catsSpeed = CatSpeed;
            _cat = new Cat(_catsFunRunDistance, _catsSpeed);
        }

        // runs after every test case (Fact)
        public void Dispose()
        {
        }

        [Fact]
        public void Meow_must_output_At_Least_One_Line_to_console()
        {
            // arrange
            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);


            // act
            _cat.Voice();

            // assert
            var outputString = outputWriter.ToString();
            var firstNewlineCharacterIndex = outputString.IndexOf('\n');

            if (firstNewlineCharacterIndex < 0)
            {
                Assert.Fail("No lines found in the output of Voice() of the Cat!");
            }
        }

        [Theory]
        [InlineData(new object[] { Food.Meat, true })]
        [InlineData(new object[] { Food.Fish, true })]
        [InlineData(new object[] { Food.Fruit, false })]
        [InlineData(new object[] { Food.Chips, false })]
        public void Cat_Reacts_On_Food_Offering_With_True_Or_False(Food foodToOffer, bool expectedResult)
        {
            // act
            var result = _cat.OfferFood(foodToOffer);

            // assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new object[] { new double[] { 100d, 50d }, true })]
        [InlineData(new object[] { new double[] { 200d, 50d }, false })]
        public void Cat_Decides_To_Run_Based_On_Its_FunRunDistance(double[] distances, bool expectedResult)
        {
            // act
            var result = _cat.WantToRun(distances);

            // assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new object[] { CatSpeed+1, false } )]
        [InlineData(new object[] { CatSpeed, false })]
        [InlineData(new object[] { CatSpeed-1, true } )]
        public void Cat_Decides_If_It_Can_Catch_Prey_Based_OnSpeed(double preySpeed, bool expectedCatCatch)
        {
            // arrange
            var fasterPrey = new Mock<IPrey>();
            // mock a getter
            fasterPrey.SetupGet(prey => prey.Speed_MetersPerSecond).Returns(preySpeed);
            // mock a method
            fasterPrey.Setup(prey => prey.GetSpeed_MetersPerSecond()).Returns(preySpeed);

            // act
            var catCatch = _cat.CanCatch(fasterPrey.Object);

            // assert
            Assert.Equal(expectedCatCatch, catCatch);
        }
    }
}