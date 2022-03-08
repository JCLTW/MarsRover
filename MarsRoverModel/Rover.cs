using System;

public class Rover
{
    public string heading { get; set; }
    public string instructions { get; set; }

    public void explore()
    {
        if (instructions == "L") SpinLeft();
        if (instructions == "R") SpinRight();
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