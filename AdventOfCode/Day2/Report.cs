namespace AdventOfCode.Day2;

public class Report
{
    public List<int> Levels { get; set; }
    public string Details { get; set; }

    public bool ReportIsSafe()
    {
        var ordered = IsOrdered(Levels);
        if (!ordered)
        {
            Details = "not in order";
            return false;
        }

        var bad = FindFirstBadReport(Levels);
        if (bad != 0)
        {
            Details = "Bad level: " + Levels[bad];
        }

        return bad == 0;
    }


    private int FindFirstBadReport(List<int> nums)
    {
        for (int i = 1; i < nums.Count; i++)
        {
            var current = nums[i];
            var previous = nums[i - 1];

            var diff = current - previous;

            if (diff==0 || Math.Abs(diff) > 3 )
            {
                return i;
            }
        }
        return 0;
    }

    private bool IsOrdered(List<int> nums)
    {
        var asc = nums.OrderBy(i => i);
        var desc = nums.OrderByDescending(i => i);
        return nums.SequenceEqual(asc) || nums.SequenceEqual(desc);
    }
}