
using System.Collections;
using System.Collections.Generic;
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

        [Theory]
        [ClassData(typeof(MovingInstructionTestDataGenerator))]
        public void should_return_expected_position_given_move_forward_instruction(
            string headingInitial,
            Coordinate coordinateInitial,
            Coordinate coordinateExpect
        )
        {
            Rover rover = new Rover();
            rover.heading = headingInitial;
            rover.coordinate = coordinateInitial;
            rover.instructions = "M";

            rover.explore();

            Assert.Equal(headingInitial, rover.heading);
            Assert.Equal(coordinateExpect.X, rover.coordinate.X);
            Assert.Equal(coordinateExpect.Y, rover.coordinate.Y);
        }

        public class MovingInstructionTestDataGenerator : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {"N", new Coordinate(1, 1), new Coordinate(1, 2)},
            new object[] {"E", new Coordinate(1, 1), new Coordinate(2, 1)},
            new object[] {"W", new Coordinate(1, 1), new Coordinate(0, 1)},
            new object[] {"S", new Coordinate(1, 1), new Coordinate(1, 0)},
        };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
