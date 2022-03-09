using System;
using System.Collections.Generic;

public class Rover
{
    public string heading { get; set; }
    public string instructions { get; set; }
    public Coordinate coordinate { get; set; }
    public Coordinate coordinatePlateau { get; set; }

    public void explore()
    {
        foreach (char instruction in instructions)
        {
            if (instruction == 'L') SpinLeft();
            if (instruction == 'R') SpinRight();
            if (instruction == 'M') MoveForward();
        }
    }

    public static Rover[] CommandParsing(string commands)
    {
        string[] commandLines = commands.Split('\n');
        string[] plateauTopRightInfo = commandLines[0].Split(' ');
        int plateauCoordinateX = Int32.Parse(plateauTopRightInfo[0]);
        int plateauCoordinateY = Int32.Parse(plateauTopRightInfo[1]);
        Coordinate coordinatePlateau = new Coordinate(plateauCoordinateX, plateauCoordinateY);

        List<Rover> rovers = new List<Rover>();
        for (int i = 1; i < commandLines.Length; i += 2)
        {
            string position = commandLines[i];
            string instructions = commandLines[i + 1];
            string[] roverPositionInfo = position.Split(' ');
            int coordinateX = Int32.Parse(roverPositionInfo[0]);
            int coordinateY = Int32.Parse(roverPositionInfo[1]);
            Coordinate coordinates = new Coordinate(coordinateX, coordinateY);
            string heading = roverPositionInfo[2];

            Rover rover = new Rover();
            rover.heading = heading;
            rover.coordinate = coordinates;
            rover.coordinatePlateau = coordinatePlateau;
            rover.instructions = instructions;
            rovers.Add(rover);
        }
        return rovers.ToArray();
    }

    private void MoveForward()
    {
        switch (heading)
        {
            case "N":
                if (coordinate.Y == coordinatePlateau.Y) throw new OutOfPlateauEdgeException();
                coordinate.Y += 1;
                break;
            case "W":
                if (coordinate.X == 0) throw new OutOfPlateauEdgeException();
                coordinate.X -= 1;
                break;
            case "S":
                if (coordinate.Y == 0) throw new OutOfPlateauEdgeException();
                coordinate.Y -= 1;
                break;
            case "E":
                if (coordinate.X == coordinatePlateau.X) throw new OutOfPlateauEdgeException();
                coordinate.X += 1;
                break;
            default:
                break;
        }
    }

    private void SpinLeft()
    {
        switch (heading)
        {
            case "N":
                heading = "W";
                break;
            case "W":
                heading = "S";
                break;
            case "S":
                heading = "E";
                break;
            case "E":
                heading = "N";
                break;
            default:
                break;
        }
    }

    private void SpinRight()
    {
        switch (heading)
        {
            case "N":
                heading = "E";
                break;
            case "E":
                heading = "S";
                break;
            case "S":
                heading = "W";
                break;
            case "W":
                heading = "N";
                break;
            default:
                break;
        }
    }
}