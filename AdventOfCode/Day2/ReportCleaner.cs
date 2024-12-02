namespace AdventOfCode.Day2;

public class ReportCleaner
{
    private readonly Report report;

    public ReportCleaner(Report report)
    {
        this.report = report;
    }

    public bool SuccessfulClean()
    {
        if (report.ReportIsSafe())
        {
            return true;
        }

        // For every combination of removing 1 number, does any produce a safe report?
        var possibleCleanReports = new List<Report>();
        for (var i = 0; i < report.Levels.Count; i++)
        {
            var levels = new List<int>(report.Levels);
            levels.RemoveAt(i);
            possibleCleanReports.Add(new Report(){Levels = levels} );
        }

        foreach (var possibleCleanReport in possibleCleanReports)
        {
            if (possibleCleanReport.ReportIsSafe())
            {
                return true;
            }
        }
        return false;
    }
}