using AdventOfCode.Common;

namespace AdventOfCode.Day5;

public class Task2 : BaseTask
{
    public override void Run()
    {
        var input = GetInput().ToArray();
        var validator = new InstructionValidator(input);
        var instructions = input.Where(s => s.Contains(","));
        var invalidInstructions = instructions.Where(i => validator.IsInstructionValid(i) == false);
        var fixedInstructions = invalidInstructions.Select(i => validator.FixInstructions(i)).ToArray();

        
        // now add up the middle of the fixed instructions
        var total = 0;
        foreach (var validInstruction in fixedInstructions)
        {
            var values = validInstruction.Split(',').Select(i => int.Parse(i)).ToArray();
            var mid = values[values.Count() / 2];
            total += mid;
        }
        
        // 6207 => too low
        Console.WriteLine("The total of the mid values = {0}", total);
    }
}