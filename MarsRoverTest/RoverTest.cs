
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
            Coordinate coordinatePlateau = new Coordinate(5, 5);
            Rover rover = new Rover();
            rover.coordinatePlateau = coordinatePlateau;
            rover.heading = headingInitial;
            rover.coordinate = coordinateInitial;
            rover.instructions = "M";

            rover.explore();

            Assert.Equal(headingInitial, rover.heading);
            Assert.Equal(coordinateExpect.X, rover.coordinate.X);
            Assert.Equal(coordinateExpect.Y, rover.coordinate.Y);
        }


        [Theory]
        [ClassData(typeof(MovingOutOfPlateauEdgeTestDataGenerator))]
        public void should_return_out_of_edge_error_given_position_on_the_edge_of_plateau_and_move_forward(
            string headingInitial,
            Coordinate coordinatesInitial)
        {

            Coordinate coordinatePlateau = new Coordinate(5, 5);
            Rover rover = new Rover();
            rover.coordinatePlateau = coordinatePlateau;
            rover.heading = headingInitial;
            rover.coordinate = coordinatesInitial;
            rover.instructions = "M";

            Assert.Throws<OutOfPlateauEdgeException>(() => rover.explore());
        }

        [Fact]
        public void should_return_expected_position_given_multiple_instructions() {

            Rover rover = new Rover();
            Coordinate initialCordinate = new Coordinate(1, 1);
            string initalHeading = "N";
            rover.coordinate = initialCordinate;
            rover.heading = initalHeading;
            rover.instructions = "LL";

            string expectedHeading = "S";
            Coordinate expectedCoordinate = new Coordinate(1, 1);

            rover.explore();

            Assert.Equal(expectedHeading, rover.heading);
            Assert.Equal(expectedCoordinate.X, rover.coordinate.X);
            Assert.Equal(expectedCoordinate.X, rover.coordinate.Y);
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

        public class MovingOutOfPlateauEdgeTestDataGenerator : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {"N", new Coordinate(0, 5)},
            new object[] {"E", new Coordinate(5, 0)},
            new object[] {"W", new Coordinate(0, 0)},
            new object[] {"S", new Coordinate(0, 0)},
        };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
