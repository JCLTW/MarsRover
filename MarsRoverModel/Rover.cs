using System;

public class Rover
{
    public string heading { get; set; }
    public string instructions { get; set; }

    public void explore()
    {
        if (instructions == "L") {
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
    }
}