namespace AdventOfCode.Day8;

public class GridPoint
{
    public int X { get; }
    public int Y { get; }
    public char Value { get; }

    public GridPoint(int x, int y, char value)
    {
        X = x;
        Y = y;
        Value = value;
    }

    public override string ToString()
    {
        return $"X: {X}, Y {Y}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is GridPoint other)
        {
            return X == other.X && Y == other.Y;
        }

        return false;
    }

    protected bool Equals(GridPoint other)
    {
        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}