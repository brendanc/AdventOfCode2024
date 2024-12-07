using AdventOfCode.Common;

namespace AdventOfCode.Day7;

public class Task1 : BaseTask
{
    public override void Run()
    {
        var input = GetInput();
        var total = 0;
        long sum = 0;
        foreach (var line in input)
        {
            var eq = new Equation(line,new[] { "*", "+" });
            if (eq.EquationIsValid())
            {
                total++;
                sum += eq.Result;
            }
        }
        
        Console.WriteLine("Total valid equations = " + total);
        Console.WriteLine("Total sum = " + sum);
    }
}