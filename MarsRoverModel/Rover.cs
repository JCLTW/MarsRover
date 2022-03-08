using System;

public class Rover
{
    public string heading { get; set; }
    public string instructions { get; set; }

    public void explore()
    {
        if (instructions == "L") {
            if (heading == "N")
                heading = "W";
        }
    }
}