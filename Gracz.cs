public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point(Point p)
    {
        X = p.X;
        Y = p.Y;
    }
}
public abstract class Character
{
    public string Visual { get; set; }
    public Point Position { get; set; }

    protected Character(string visual, Point startingPosition)
    {
        Visual = visual;
        Position = startingPosition;
    }

    public abstract Point GetNextPosition();
}

// Define the Player class
public class Player : Character
{
    private Dictionary<ConsoleKey, Point> directions = new()
    {
        { ConsoleKey.A, new Point(-1, 0) }
    };

    public Player(string visual, Point startingPosition) : base(visual, startingPosition)
    {
        directions[ConsoleKey.D] = new Point(1, 0);
        directions[ConsoleKey.W] = new Point(0, -1);
        directions[ConsoleKey.S] = new Point(0, 1);
        directions[ConsoleKey.E] = new Point(1, -1);
    }

    public override Point GetNextPosition()
    {
        Point nextPosition = new Point(Position);
        
        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
        if (directions.ContainsKey(pressedKey.Key))
        {
            nextPosition.X += directions[pressedKey.Key].X;
            nextPosition.Y += directions[pressedKey.Key].Y;
        }

        return nextPosition;
    }
}
