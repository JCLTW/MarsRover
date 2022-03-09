
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

        [Theory]
        [InlineData("N", "E")]
        [InlineData("E", "S")]
        [InlineData("S", "W")]
        [InlineData("W", "N")]
        public void should_return_expected_heading_given_spin_right_instruction(string headingInitial, string headingExpect)
        {
            Rover rover = new Rover();
            rover.heading = headingInitial;
            rover.instructions = "R";

            rover.explore();

            Assert.Equal(headingExpect, rover.heading);
        }

        [Fact]
        public void should_move_forward_north_given_move_instruction() {
            int coordinateX = 1;
            int coordinateY = 1;
            string headingInitial = "N";

            Rover rover = new Rover();
            Coordinate coordinate = new Coordinate();
            rover.heading = headingInitial;
            coordinate.X = coordinateX;
            coordinate.Y = coordinateY;
            rover.coordinate = coordinate;
            rover.instructions = "M";

            rover.explore();

            Assert.Equal(headingInitial, rover.heading);
            Assert.Equal(coordinateX, rover.coordinate.X);
            Assert.Equal(coordinateY+1, rover.coordinate.Y);
        }


        [Fact]
        public void should_move_forward_west_given_move_instruction()
        {
            int coordinateX = 1;
            int coordinateY = 1;
            string headingInitial = "W";

            Rover rover = new Rover();
            Coordinate coordinate = new Coordinate();
            rover.heading = headingInitial;
            coordinate.X = coordinateX;
            coordinate.Y = coordinateY;
            rover.coordinate = coordinate;
            rover.instructions = "M";

            rover.explore();

            Assert.Equal(headingInitial, rover.heading);
            Assert.Equal(coordinateX -1, rover.coordinate.X);
            Assert.Equal(coordinateY, rover.coordinate.Y);
        }

        [Fact]
        public void should_move_forward_south_given_move_instruction()
        {
            int coordinateX = 1;
            int coordinateY = 1;
            string headingInitial = "S";

            Rover rover = new Rover();
            Coordinate coordinate = new Coordinate();
            rover.heading = headingInitial;
            coordinate.X = coordinateX;
            coordinate.Y = coordinateY;
            rover.coordinate = coordinate;
            rover.instructions = "M";

            rover.explore();

            Assert.Equal(headingInitial, rover.heading);
            Assert.Equal(coordinateX, rover.coordinate.X);
            Assert.Equal(coordinateY - 1, rover.coordinate.Y);
        }

        [Fact]
        public void should_move_forward_east_given_move_instruction()
        {
            int coordinateX = 1;
            int coordinateY = 1;
            string headingInitial = "E";

            Rover rover = new Rover();
            Coordinate coordinate = new Coordinate();
            rover.heading = headingInitial;
            coordinate.X = coordinateX;
            coordinate.Y = coordinateY;
            rover.coordinate = coordinate;
            rover.instructions = "M";

            rover.explore();

            Assert.Equal(headingInitial, rover.heading);
            Assert.Equal(coordinateX + 1 , rover.coordinate.X);
            Assert.Equal(coordinateY, rover.coordinate.Y);
        }
    }
}
