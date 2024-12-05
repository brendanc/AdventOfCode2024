using AdventOfCode.Common;

namespace AdventOfCode.Day5;

public class InstructionValidator
{
    public InstructionValidator(IEnumerable<string> input)
    {
        RulePairs = new List<Tuple<int, int>>();
        foreach (var line in input)
        {
            if (line.Contains("|"))
            {
                var parts = line.Split('|');
                RulePairs.Add(new Tuple<int, int>(int.Parse(parts[0]),int.Parse(parts[1])));
            }
        }
    }
    
    public List<Tuple<int,int>> RulePairs { get; set; }

    public bool IsInstructionValid(string instruction)
    {
        var pages = instruction.Split(',').Select(int.Parse).ToList();
        foreach (var rule in RulePairs)
        {
            var xIndex = pages.IndexOf(rule.Item1);
            var yIndex = pages.IndexOf(rule.Item2);
            if (xIndex < 0 || yIndex < 0)
            {
                continue;
            }

            if (xIndex > yIndex)
            {
                return false;
            }
        }
        return true;
    }

    public string FixInstructions(string invalidInstruction)
    {
        if (IsInstructionValid(invalidInstruction))
        {
            return invalidInstruction;
        }

        var pages = invalidInstruction.Split(',').Select(int.Parse).ToList();
        foreach (var rule in RulePairs)
        {
            var xIndex = pages.IndexOf(rule.Item1);
            var yIndex = pages.IndexOf(rule.Item2);
            if (xIndex < 0 || yIndex < 0)
            {
                continue;
            }
            
            if (xIndex > yIndex)
            {
                // need to fix this one
                var item = pages[xIndex];
                pages.RemoveAt(xIndex);
                var newY = pages.IndexOf(rule.Item2);
                pages.Insert(Math.Max(newY-1,0),item);
            }
        }

        // we made a repair, now check to see if the instruction is valid
        // if yes return, else keep repairing
        var repaired =  string.Join(',', pages);
        if (IsInstructionValid(repaired))
        {
            return repaired;
        }
        else
        {
            return FixInstructions(repaired);
        }
    }
}