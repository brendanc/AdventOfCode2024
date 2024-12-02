using AdventOfCode.Common;

namespace AdventOfCode.Day1;

public class Task1 : BaseTask
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
        
        // sort them
        leftList.Sort();
        rightList.Sort();

        int total = 0;
        for (var i = 0; i < leftList.Count; i++)
        {
            var left = leftList[i];
            var right = rightList[i];

            if (right > left)
            {
                total += (right - left);
                continue;
            }

            if (left > right)
            {
                total += (left - right);
            }
        }
        
        Console.WriteLine($"Total = {total}");
    }
}