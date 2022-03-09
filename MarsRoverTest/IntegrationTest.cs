using Xunit;
namespace MarsRoverTest
{
    public class IntegrationTest
    {
        [Fact]
        public void should_get_expected_rover_position_after_explore_given_commands() {
            Rover firstRover, secondRover;

            string commands = "5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM";
            Rover[] rovers = Rover.CommandParsing(commands);

            Assert.Equal(2, rovers.Length);
            firstRover = rovers[0];
            secondRover = rovers[1];

            firstRover.explore();
            secondRover.explore();

            string firstExpectedHeading = "N";
            Coordinate firstExpectedCoordinate = new Coordinate(1, 3);

            Assert.Equal(firstExpectedHeading, firstRover.heading);
            Assert.Equal(firstExpectedCoordinate.X, firstRover.coordinate.X);
            Assert.Equal(firstExpectedCoordinate.Y, firstRover.coordinate.Y);

            string secondExpectedHeading = "E";
            Coordinate secondExpectedCoordinate = new Coordinate(5, 1);

            Assert.Equal(secondExpectedHeading, secondRover.heading);
            Assert.Equal(secondExpectedCoordinate.X, secondRover.coordinate.X);
            Assert.Equal(secondExpectedCoordinate.Y, secondRover.coordinate.Y);
        }
    }
}
