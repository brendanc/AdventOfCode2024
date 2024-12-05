using AdventOfCode.Common;

namespace AdventOfCode.Day5;

public class Task1 : BaseTask
{
    public override void Run()
    {
        var input = GetInput().ToArray();
        var validator = new InstructionValidator(input);
        var instructions = input.Where(s => s.Contains(","));
        var validInstructions = instructions.Where(i => validator.IsInstructionValid(i));
        
        // now add up the middle of the valids
        var total = 0;
        foreach (var validInstruction in validInstructions)
        {
            var values = validInstruction.Split(',').Select(i => int.Parse(i)).ToArray();
            var mid = values[values.Count() / 2];
            total += mid;
        }
        
        Console.WriteLine("The total of the mid values = {0}", total);
    }
}