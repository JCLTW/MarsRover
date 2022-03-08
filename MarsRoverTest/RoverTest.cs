
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

        [Fact]
        public void should_heading_south_when_rover_explore_given_rover_heading_west_and_instruction_with_L()
        {
            Rover rover = new Rover();
            rover.heading = "W";
            rover.instructions = "L";

            rover.explore();

            Assert.Equal("S", rover.heading);
        }

        [Fact]
        public void should_heading_east_when_rover_explore_given_rover_heading_south_and_instruction_with_L()
        {
            Rover rover = new Rover();
            rover.heading = "S";
            rover.instructions = "L";

            rover.explore();

            Assert.Equal("E", rover.heading);
        }

        [Fact]
        public void should_heading_north_when_rover_explore_given_rover_heading_east_and_instruction_with_L()
        {
            Rover rover = new Rover();
            rover.heading = "E";
            rover.instructions = "L";

            rover.explore();

            Assert.Equal("N", rover.heading);
        }
    }
}
