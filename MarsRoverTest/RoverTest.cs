
using Xunit;

namespace MarsRoverTest
{
    public class RoverTest
    {
        [Fact]
        public void should_heading_west_when_rover_explore_given_rover_heading_north_and_instruction_with_L()
        {
            Rover rover = new Rover();
            rover.heading = "N";
            rover.instructions = "L";

            rover.explore();

            Assert.Equal("W", rover.heading);
        }
    }
}
