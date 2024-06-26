public class Map
{
    private int[][] mapData; // Assuming mapData is defined elsewhere and correctly initialized

    public CellType[] walkableCellTypes = new CellType[] { 
        CellType.Floor, 
        CellType.Grass,
        CellType.Teleport,
        CellType.Shop
    };

    public Map(int[][] initialMapData)
    {
        mapData = initialMapData; // Initialize mapData properly
    }

    internal bool IsPointCorrect(Point point)
    {
        if (mapData == null || point == null)
        {
            return false;
        }

        // Check if point is within valid Y bounds
        if (point.Y >= 0 && point.Y < mapData.Length)
        {
            // Check if point is within valid X bounds for the given Y
            if (point.X >= 0 && point.X < mapData[point.Y].Length)
            {
                // Check if the cell type at the point is in walkableCellTypes
                if (walkableCellTypes.Contains(GetCellAt(point)))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private CellType GetCellAt(Point point)
    {
        if (mapData == null || point == null || point.Y < 0 || point.Y >= mapData.Length || point.X < 0 || point.X >= mapData[point.Y].Length)
        {
            return CellType.Empty; // Return a default or invalid cell type if out of bounds
        }

        // Implement this method to retrieve the CellType at the specified point
        return (CellType)mapData[point.Y][point.X]; // Assuming mapData is correctly initialized
    }
}