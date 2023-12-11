using lesson2_unit_testing;

namespace lesson2_Tests
{
    public class CatTests
    {
        [Fact]
        public void Meow_must_output_At_Least_One_Line_to_console()
        {
            // arrange
            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);
            
            var cat = new Cat();

            // act
            cat.Voice();

            // assert
            var outputString = outputWriter.ToString();
            var firstNewlineCharacterIndex = outputString.IndexOf('\n');

            if(firstNewlineCharacterIndex < 0) {
                Assert.Fail("No lines found in the output of Voice() of the Cat!");
            }
        }
    }
}