using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

public enum CellType
{
    Empty = 0,
    WallHorizontal = 1,
    WallVertical = 2,
    WallCorner = 3,
    Teleport = 4,
    Grass = 5,
    Water = 6,
    Shop = 7,
    Rod = 8,
    Start = 9
}

public class Map
{
    public Point Origin { get; set; }
    public Point Size { get; }

    private int[][] mapData;
    private Dictionary<CellType, char> cellVisuals = new Dictionary<CellType, char>
    {
        { CellType.Empty, ' '},
        { CellType.WallHorizontal, '-'},
        { CellType.WallVertical, '|'},
        { CellType.WallCorner, '+'},
        { CellType.Teleport, '♨'},
        { CellType.Grass, '.'},
        { CellType.Water, '~'},
        { CellType.Shop, '💰'},
        { CellType.Rod, '⚓'},
        { CellType.Start, 'S'},
    };

    private Dictionary<CellType, ConsoleColor> colorMap = new Dictionary<CellType, ConsoleColor>
    {
        { CellType.Empty, ConsoleColor.Black},
        { CellType.WallCorner, ConsoleColor.DarkRed},
        { CellType.WallHorizontal, ConsoleColor.DarkRed},
        { CellType.WallVertical, ConsoleColor.DarkRed},
        { CellType.Teleport, ConsoleColor.Magenta},
        { CellType.Grass, ConsoleColor.Green},
        { CellType.Water, ConsoleColor.DarkCyan},
        { CellType.Rod, ConsoleColor.DarkCyan},
        { CellType.Start, ConsoleColor.Yellow},
    };

    public CellType[] walkableCellTypes = new CellType[]
    {
        CellType.Grass,
        CellType.Teleport,
        CellType.Shop,
        CellType.Rod,
    };

private Dictionary<Point, Point> teleportPairs = new Dictionary<Point, Point>();



   public Map()
{
    mapData = new int[][]
    {
        new []{0, 3, 1, 1, 1, 1, 1, 3, 0, 0, 3, 1, 1, 1, 1, 3, 0},
        new []{0, 2, 6, 6, 6, 6, 6, 2, 0, 0, 2, 7, 5, 5, 8, 2, 0},
        new []{0, 2, 6, 6, 6, 6, 6, 2, 0, 0, 2, 5, 5, 5, 8, 2, 0},
        new []{0, 2, 6, 6, 6, 6, 6, 2, 0, 0, 2, 5, 5, 5, 8, 2, 0},
        new []{0, 2, 5, 5, 5, 5, 5, 2, 0, 0, 2, 5, 5, 3, 1, 3, 0},
        new []{0, 2, 5, 5, 5, 5, 5, 2, 0, 0, 2, 5, 3, 0, 0, 0, 0},
        new []{0, 3, 1, 1, 1, 3, 5, 2, 0, 0, 2, 5, 2, 0, 0, 0, 0},
        new []{0, 0, 0, 0, 0, 2, 5, 2, 0, 0, 2, 5, 2, 0, 0, 0, 0},
        new []{0, 0, 0, 0, 0, 2, 5, 2, 0, 0, 2, 5, 2, 0, 0, 0, 0},
        new []{0, 0, 0, 0, 0, 2, 5, 2, 0, 0, 2, 5, 2, 0, 0, 0, 0},
        new []{0, 0, 0, 0, 0, 2, 4, 2, 0, 0, 2, 4, 2, 0, 0, 0, 0},
        new []{0, 0, 0, 0, 0, 3, 1, 3, 0, 0, 3, 1, 3, 0, 0, 0, 0},
    };

    int startX = 4;
    int startY = 5;
    mapData[startY][startX] = (int)CellType.Start;

   teleportPairs.Add(new Point(7, 11), new Point(12, 11));
    teleportPairs.Add(new Point(12, 11), new Point(7, 11));

    int y = mapData.Length;
    int x = 0;

    foreach (int[] row in mapData)
    {
        if (row.Length > x)
        {
            x = row.Length;
        }
    }

    Size = new Point(x, y);
    Origin = new Point(0, 0);
}

public Point Teleport(Point currentPosition)
{
    if (GetCellAt(currentPosition) == CellType.Teleport && teleportPairs.ContainsKey(currentPosition))
    {
        return teleportPairs[currentPosition];
    }
    return currentPosition;
}
public void Display(Point origin)
{
    Origin = origin;
    Console.CursorTop = origin.Y;
    for (int y = 0; y < mapData.Length; y++)
    {
        Console.CursorLeft = origin.X;
        for (int x = 0; x < mapData[y].Length; x++)
        {
            var cellValue = GetCellAt(x, y);
            var cellVisual = cellVisuals[cellValue];
            var cellColor = GetCellColorByValue(cellValue);
            Console.ForegroundColor = cellColor;
            Console.Write(cellVisual);
            Console.ResetColor();
        }
        Console.WriteLine();
    }
}

public void MovePlayer(Point newPosition)
{
    Point newLocation = Teleport(newPosition);

}

    public CellType GetCellAt(Point point)
    {
        return GetCellAt(point.X, point.Y);
    }

    private CellType GetCellAt(int x, int y)
    {
        return (CellType)mapData[y][x];
    }

    public char GetCellVisualAt(Point point)
    {
        return cellVisuals[GetCellAt(point)];
    }

    public ConsoleColor GetCellColorByValue(CellType cellValue)
    {
        if (colorMap.ContainsKey(cellValue))
        {
            return colorMap[cellValue];
        }
        return ConsoleColor.White;
    }

    public void Display(Point origin)
    {
        Origin = origin;
        Console.CursorTop = origin.Y;
        for (int y = 0; y < mapData.Length; y++)
        {
            Console.CursorLeft = origin.X;
            for (int x = 0; x < mapData[y].Length; x++)
            {
                var cellValue = GetCellAt(x, y);
                var cellVisual = cellVisuals[cellValue];
                var cellColor = GetCellColorByValue(cellValue);
                Console.ForegroundColor = cellColor;
                Console.Write(cellVisual);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }

    internal bool IsPointCorrect(Point point)
    {
        if (point.Y >= 0 && point.Y < mapData.Length)
        {
            if (point.X >= 0 && point.X < mapData[point.Y].Length)
            {
                if (walkableCellTypes.Contains(GetCellAt(point)))
                {
                    return true;
                }
            }
        }

        return false;
    }
}
