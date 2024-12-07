using System.Text;
using AdventOfCode.Common;

namespace AdventOfCode.Day6;

public class RoomGrid
{
    public char[,] Grid { get; set; }
    public GridPoint StartPoint { get; set; }
    public GridPoint CurrentPoint { get; set; }
    
    public RoomGrid(string input)
    {
        // parse input into grid
        var lines = input.SplitToLines().ToArray();
        Grid = new char[lines.First().Length, lines.Count()];
        for (var y = 0; y < lines.Count(); y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                Grid[y, x] = line[x];
                if (line[x] == '^')
                {
                    // this is the start point
                    StartPoint = new GridPoint(y, x, '^');
                    CurrentPoint = StartPoint;
                }
            }
        }
    }

    public string GridToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < Grid.GetLength(0); i++)
        {
            for (int j = 0; j < Grid.GetLength(1); j++)
            {
                sb.Append(Grid[i, j]);
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }

    public char FindValueAt(GridPoint point)
    {
        try
        {
            return Grid[point.Row, point.Column];
        }
        catch (IndexOutOfRangeException)
        {
            return '$';
        }
       
    }

    public void MarkGrid(GridPoint point)
    {
        Grid[point.Row, point.Column] = 'X';
    }

    public int CountMarks()
    {
        var count = 0;

        for (var i = 0; i < Grid.GetLength(0); i++)
        {
            for (var j = 0; j < Grid.GetLength(1); j++)
            {
                if (Grid[i, j] == 'X')
                {
                    count++;
                }
            }
        }

        return count;
    }
    
    public void Go()
    {
        var next = CurrentPoint.Forward;
        var nextValue = FindValueAt(next);

        while (nextValue != '$')
        {
            if (nextValue == '#')
            {
                CurrentPoint.Turn();
            }
            else
            {
                MarkGrid(CurrentPoint);
                CurrentPoint = CurrentPoint.Forward;
            }
            
             next = CurrentPoint.Forward;
             nextValue = FindValueAt(next);
        }
        MarkGrid(CurrentPoint);
    }
    
    public bool StuckInLoop()
    {
        var next = CurrentPoint.Forward;
        var nextValue = FindValueAt(next);
        var totalPoints = Grid.GetLength(0) * Grid.GetLength(1);
        var pointsVisited = 0;

        while (nextValue != '$')
        {
            if (nextValue == '#' || nextValue == 'O')
            {
                CurrentPoint.Turn();
            }
            else
            {
                MarkGrid(CurrentPoint);
                CurrentPoint = CurrentPoint.Forward;
            }
            
            next = CurrentPoint.Forward;
            nextValue = FindValueAt(next);
            
            // if we visit more points than exist in the grid we are in a loop
            pointsVisited++;
            if (pointsVisited > totalPoints * 2)
            {
                return true;
            }
        }

        return false;
    }
}