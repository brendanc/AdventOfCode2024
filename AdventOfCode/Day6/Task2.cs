using System.Diagnostics;
using AdventOfCode.Common;

namespace AdventOfCode.Day6;

public class Task2 : BaseTask
{
    public override void Run()
    {
        // load up a grid
        var sampleGrid =  new RoomGrid(this.GetInputAsSingleString());
        // run the sim
        sampleGrid.Go();
        // get the inner grid
        var sample = sampleGrid.Grid;
        var total = 0;
        
        for(var row=0;row<sample.GetLength(0);row++)
        {
            for (var col = 0; col < sample.GetLength(1); col++)
            {
                // possible locations for obstruction = X's in a completed sim
                var val = sample[row, col];
                if (val == 'X')
                {
                    var testGrid = new RoomGrid(this.GetInputAsSingleString());
                    // add new blocker to the new test grid
                    var p = new GridPoint(row, col,'O');
                    testGrid.Grid[row, col] = 'O';
                    // see if the new test grid gets stuck in a loop
                    if (testGrid.StuckInLoop())
                    {
                        total++;
                    }
                }
            }
        }

        Console.WriteLine(total);
    }
}