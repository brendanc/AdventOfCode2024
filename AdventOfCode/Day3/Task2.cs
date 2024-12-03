using System.Text.RegularExpressions;
using AdventOfCode.Common;

namespace AdventOfCode.Day3;

public class Task2 : BaseTask
{
    public override void Run()
    { 
        var input = GetInputAsSingleString();
        //var input = @"xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
        var doBlocks = ExtractProgram(input);

        var total = 0;
        foreach (var block in doBlocks)
        {
            var muls = FindValidMuls(block);
            foreach (var m in muls)
            {
                total += Mul(m);
            }
        }

        Console.WriteLine("Mul total = " + total);
    }

    private List<string> ExtractProgram(string input)
    {
        var program = "do()" + input ;
        var blocks = DoParser.ParseDoBlocks(program);
        return blocks;
    }
    
    private int Mul(string mulExpression)
    {
        var values = mulExpression.ExtractNumbersFromText();
        return values[0] * values[1];
    }
    
    private List<string> FindValidMuls(string input)
    {
        var pattern = @"mul\(\d{1,3}\,\d{1,3}\)";
        List<string> matches = new List<string>();

        foreach (Match match in Regex.Matches(input, pattern))
        {
            matches.Add(match.Value);
        }
        return matches;
    }
}