using AdventOfCode.Common;

namespace AdventOfCode.Day2;

public class Task2 : BaseTask
{
    public override void Run()
    {
        var reports = this.GetInput();
//      var i = @"7 6 4 2 1
// 1 2 7 8 9
// 9 7 6 2 1
// 1 3 2 4 5
// 8 6 4 4 1
// 1 3 6 7 9
// 20 18 17 15 12 8 6";
//       var reports = i.SplitToLines();
      //  var reports = new List<string>() { "31 1 2 3 4 5"};
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
                Console.WriteLine("SAFE: " + string.Join<int>(",",rep.Levels));
                safeReports.Add(rep);
            }
            else
            {
                var cleaner = new ReportCleaner(rep);
                if (cleaner.SuccessfulClean())
                {
                    safeReports.Add(rep);
                }
                Console.WriteLine("UNSAFE: " + string.Join<int>(",",rep.Levels) + " " + rep.Details);
            }
        }
        
        Console.WriteLine("There are {0} safe reports", safeReports.Count);
    }
}