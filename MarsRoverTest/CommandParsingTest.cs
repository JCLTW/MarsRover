using Xunit;
namespace MarsRoverTest
{
    public class CommandParsingTest
    {
        [Fact]
        public void should_return_initialize_rover_given_commands_with_signle_rover_instructions()
        {
            string commands = "5 5\n1 1 N\nLLM";

            string expectedHeading = "N";
            Coordinate expectedCoordinate = new Coordinate(1, 1);
            string expectedInstructions = "LLM";

            Rover[] rovers = Rover.CommandParsing(commands);

            Assert.Single(rovers);
            Rover initializedRover = rovers[0];
            Assert.Equal(expectedHeading, initializedRover.heading);
            Assert.Equal(expectedCoordinate.X, initializedRover.coordinate.X);
            Assert.Equal(expectedCoordinate.Y, initializedRover.coordinate.Y);
            Assert.Equal(expectedInstructions, initializedRover.instructions);
        }  
    }
}
