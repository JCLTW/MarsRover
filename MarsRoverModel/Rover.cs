using System;

public class Rover
{
    public string heading { get; set; }
    public string instructions { get; set; }
    public Coordinate coordinate { get; set; }

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
                coordinate.Y += 1;
                break;
            case "W":
                coordinate.X -= 1;
                break;
            case "S":
                coordinate.Y -= 1;
                break;
            case "E":
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