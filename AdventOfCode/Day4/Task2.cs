using AdventOfCode.Common;

namespace AdventOfCode.Day4;

public class Task2 : BaseTask
{
    public override void Run()
    {
        var input = GetInputAsSingleString();
        var grid = new WordSearchGrid(input); 
        var total = grid.FindCrossWordCount();
        Console.WriteLine("Found X-MAS {0} times", total);
    }
}