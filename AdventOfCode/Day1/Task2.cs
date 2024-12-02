using AdventOfCode.Common;

namespace AdventOfCode.Day1;

public class Task2 : BaseTask
{
    public override void Run()
    {
        var input = GetInput();
        
        var leftList = new List<int>();
        var rightList = new List<int>();

        // load up the lists
        foreach (var line in input)
        {
            var splits = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            leftList.Add(Convert.ToInt32(splits[0]));
            rightList.Add(Convert.ToInt32(splits[1]));
        }

        int total = 0;
        foreach (var l in leftList)
        {
            var n = rightList.Count(r => r == l);
            total += (l * n);
        }
        
        Console.WriteLine($"Total = {total}");
    }
}