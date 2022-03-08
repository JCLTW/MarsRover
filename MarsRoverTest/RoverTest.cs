
using Xunit;

namespace MarsRoverTest
{
    public class RoverTest
    {
        [Theory]
        [InlineData("N", "W")]
        [InlineData("W", "S")]
        [InlineData("S", "E")]
        [InlineData("E", "N")]
        public void should_return_expected_heading_given_spin_left_instruction(string headingInitial, string headingExpect)
        {
            Rover rover = new Rover();
            rover.heading = headingInitial;
            rover.instructions = "L";

            rover.explore();

            Assert.Equal(headingExpect, rover.heading);
        }
    }
}
