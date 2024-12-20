namespace AdventOfCode.Day8;

public class AntennaGrid
{
    private const int GridSize = 50;
    private readonly string[] input;
    private readonly char[] frequencies; 
    public char[,] Grid { get; set; }
    
    public List<GridPoint> AllGridPoints { get; set; }
    public List<GridPoint> AntennaPoints { get; set; }
    
    public AntennaGrid(string input, char[] frequencies)
    {
        this.frequencies = frequencies;
        AllGridPoints = new List<GridPoint>();
        AntennaPoints = new List<GridPoint>();

        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var rows = lines.Length;
        var cols = lines[0].Length;

        Grid = new char[rows, cols];

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                var val = lines[y][x];
                Grid[y, x] = lines[y][x];
                AllGridPoints.Add(new GridPoint(x,y,val));
                if (val != '.')
                {
                    AntennaPoints.Add(new GridPoint(x,y,val));
                }
            }
        }
    }

    public List<GridPoint> FindAntinodes(char frequency)
    {
        var antinodes = new List<GridPoint>();
        var points = FindAllPointsWithFrequency(frequency);
        foreach (var pt in points)
        {
            var otherPoints = points.Where(p => !p.Equals(pt));

            foreach (var otherPoint in otherPoints)
            {
                // calc diff between pt & other pt
                var yDiff = pt.Y - otherPoint.Y;
                var xDiff = pt.X - otherPoint.X;

                var minX = Math.Min(pt.X, otherPoint.X);
                var maxX = Math.Max(pt.X, pt.Y);
                var minY = Math.Min(pt.Y, otherPoint.Y);
                var maxY = Math.Max(pt.Y, otherPoint.Y);
                
               // antinodes.Add(new GridPoint(minX - xDiff, maxY + yDiff,'#'));
               // antinodes.Add(new GridPoint(maxX + xDiff,minY - yDiff,'#'));
               antinodes.Add(new GridPoint(pt.X + xDiff,pt.Y + yDiff,'#'));
               antinodes.Add(new GridPoint(otherPoint.X - xDiff,otherPoint.Y - yDiff,'#'));
            }
            
        }

        return antinodes;
    }

    public List<GridPoint> FindAllPointsWithFrequency(char frequency)
    {
        return AllGridPoints.Where(p => p.Value == frequency).Distinct().ToList();
    }

    public int CountAllAntinodes()
    {
        var all = new List<GridPoint>();
        foreach (var f in frequencies)
        {
          //  var grid = GetGridForFrequency(f);
            var allNodes = FindAntinodes(f);
            all.AddRange(allNodes);
        }

        var inBounds = all.Where(x => x is { X: >= 0 and < GridSize, Y: >= 0 and < GridSize });
        var answer = inBounds.Where(gp => !AntennaPoints.Contains(gp));
        
        var distinct = answer.Select(a => new { a.Y, a.X }).Distinct();
        
        
        
        foreach (var d in distinct.OrderBy(b=>b.X).ThenBy(c=>c.Y))
        {
            Console.WriteLine(d);
        }
        return distinct.Count();
    }

    // public char[,] GetGridForFrequency(char frequency)
    // {
    //     var grid = new char[input.First().Length, input.Count()];
    //     for (var y = 0; y < input.Count(); y++)
    //     {
    //         var line = input.ToArray()[y];
    //         for (var x = 0; x < line.Length; x++)
    //         {
    //             if (line[x] != '.' && line[x] != frequency)
    //             {
    //                 grid[y, x] = '.';
    //             }
    //             else
    //             {
    //                 grid[y, x] = line[x];
    //             }
    //         }
    //     }
    //
    //     return grid;
    // }
}
