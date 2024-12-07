using AdventOfCode.Common;

namespace AdventOfCode.Day6;

public class Task1 : BaseTask
{
    public override void Run()
    {
        var input = GetInputAsSingleString();
        var grid = new RoomGrid(input);
        Console.WriteLine(grid.StartPoint);
        grid.Go();
        Console.WriteLine(grid.GridToString());
        var total = grid.CountMarks();
        Console.WriteLine("Found {0} X's", total);
    }
}