using AdventOfCode.Common;


namespace AdventOfCode.Day8;

public class Task1 : BaseTask
{
    public override void Run()
    {
        var input = GetInput();
        var s = GetInputAsSingleString();
        var frequencies = s.Replace(Environment.NewLine,"").Trim().Distinct().Where(s => s != '.').ToArray();
        var grid = new AntennaGrid(s, frequencies);

        var antinodes = grid.CountAllAntinodes();
        
        // 314, 297 too high, 185 too low - 266 
        Console.WriteLine("Found {0} antinodes", antinodes);

    }
}