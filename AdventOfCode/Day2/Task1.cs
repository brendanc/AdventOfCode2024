using AdventOfCode.Common;

namespace AdventOfCode.Day2;

public class Task1 : BaseTask
{
    public override void Run()
    {
        var reports = this.GetInput();
        var safeReports = new List<Report>();

        foreach (var r in reports)
        {
            var items = r.Split(' ');
            var rep = new Report()
            {
                Levels = new List<int>()
            };
            rep.Levels.AddRange( items.Select(i => Convert.ToInt32(i)));

            if (rep.ReportIsSafe())
            {
                safeReports.Add(rep);
            }
        }
        
        Console.WriteLine("There are {0} safe reports", safeReports.Count);
    }


    
}