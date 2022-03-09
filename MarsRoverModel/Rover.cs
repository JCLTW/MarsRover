using System;

public class Rover
{
    public string heading { get; set; }
    public string instructions { get; set; }
    public Coordinate coordinate { get; set; }
    public Coordinate coordinatePlateau { get; set; }

    public void explore()
    {
        if (instructions == "L") SpinLeft();
        if (instructions == "R") SpinRight();
        if (instructions == "M") MoveForward();
   
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