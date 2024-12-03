using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day3;

public class DoParser
{
    public static List<string> ParseDoBlocks(string input)
    {
        var doPattern = @"do\(\)";
        var doMatches = Regex.Matches(input, doPattern);
        var doIndices = doMatches.Select(m => m.Index);

        var dontPattern = @"don\'t\(\)";
        var dontMatches = Regex.Matches(input, dontPattern);
        var dontIndices = dontMatches.Select(m => m.Index);

        var allIndices = new List<int>(doIndices);
        allIndices.AddRange(dontIndices);
        allIndices.Sort();


        var pairs = new List<Tuple<int,int>>();

        for (var i = 0; i < allIndices.Count; i++)
        {
            if (i + 1 != allIndices.Count)
            {
                pairs.Add(new Tuple<int, int>(allIndices[i],allIndices[i+1]));
            }
            else
            {
                pairs.Add(new Tuple<int, int>(allIndices[i],input.Length));
            }
        }

        var blocks = new List<string>();
        foreach (var pair in pairs)
        {
            blocks.Add(input.Substring(pair.Item1,pair.Item2 - pair.Item1));
        }
        
        return blocks.Where(b => b.Trim().StartsWith("do()")).ToList();
    }
}
