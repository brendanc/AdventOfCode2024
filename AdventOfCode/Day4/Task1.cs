using AdventOfCode.Common;

namespace AdventOfCode.Day4;

public class Task1 : BaseTask
{
    public override void Run()
    {
        var input = GetInputAsSingleString();
        var grid = new WordSearchGrid(input); 
        var total = grid.FindWord("XMAS");
        Console.WriteLine("Found XMAS {0} times", total);
    }
}