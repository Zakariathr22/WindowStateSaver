namespace WindowStateSaver.Models;

public class WindowState
{
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public double Scale { get; set; }
    public bool IsMaximized { get; set; }
}
