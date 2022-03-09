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

        [Fact]
        public void should_return_initialize_rover_given_commands_with_multile_rover_instructions()
        {
            string commands = "5 5\n1 1 N\nLLM\n2 2 N\nRRM";

            string firstExpectedHeading = "N";
            Coordinate firstExpectedCoordinate = new Coordinate(1, 1);
            string firstExpectedInstructions = "LLM";
            string secondExpectedHeading = "N";
            Coordinate secondExpectedCoordinate = new Coordinate(2, 2);
            string secondExpectedInstructions = "RRM";

            Rover[] rovers = Rover.CommandParsing(commands);

            Assert.Equal(2, rovers.Length);
            Rover firstInitializedRover = rovers[0];
            Assert.Equal(firstExpectedHeading, firstInitializedRover.heading);
            Assert.Equal(firstExpectedCoordinate.X, firstInitializedRover.coordinate.X);
            Assert.Equal(firstExpectedCoordinate.Y, firstInitializedRover.coordinate.Y);
            Assert.Equal(firstExpectedInstructions, firstInitializedRover.instructions);

            Rover secondInitializedRover = rovers[1];
            Assert.Equal(secondExpectedHeading, firstInitializedRover.heading);
            Assert.Equal(secondExpectedCoordinate.X, secondInitializedRover.coordinate.X);
            Assert.Equal(secondExpectedCoordinate.Y, secondInitializedRover.coordinate.Y);
            Assert.Equal(secondExpectedInstructions, secondInitializedRover.instructions);
        }
    }
}
