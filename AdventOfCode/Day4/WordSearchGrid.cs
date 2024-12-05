using AdventOfCode.Common;

namespace AdventOfCode.Day4;

public class WordSearchGrid
{
    private readonly string input;

    public WordSearchGrid(string input)
    {
        this.input = input;
        PopulateGrid();
    }

    public int FindCrossWordCount()
    {
        var total = 0;
       // parse input into 2D char array
       var grid = input.SplitToLines().Select(s => s.ToCharArray()).ToArray();
       for (var r = 1; r < Rows.Count - 1; r++)
       {
           var row = Rows[r];
           for (var c = 1; c < row.Length - 1; c++)
           {
               if (row[c] == 'A')
               {
                   // found the middle letter, lets see if this is a X word
                   var item1 = string.Concat(grid[r - 1][c-1],'A',grid[r + 1][c+1]);
                   var item2 = string.Concat(grid[r - 1][c+1], 'A', grid[r + 1][c-1]);
                   if (
                       (item1 == "MAS" || item1 == "SAM")
                       &&
                       (item2 == "MAS" || item2 == "SAM")
                   )
                   {
                       total++;
                   }
               }
           }
       }
       return total;
    }

    public int FindWord(string word)
    {
        var total = 0;
        
        // search rows
        foreach (var row in Rows)
        {
            total += FindWordCountInString(row, word);
            total += FindWordCountInString(row.Reverse(), word);
        }
        
        // search columns
        foreach (var column in Columns)
        {
            total += FindWordCountInString(column, word);
            total += FindWordCountInString(column.Reverse(), word);
        }
        
        // search diagonals
        foreach (var diagonal in Diagonals.Where(d => d.Length>=word.Length))
        {
            total += FindWordCountInString(diagonal, word);
            total += FindWordCountInString(diagonal.Reverse(), word);
        }

        return total;
    }
    
    private int FindWordCountInString(string text, string word)
    {
        var count = 0;
        var wordLength = word.Length;
        for (var i = 0; i < text.Length; i++)
        {
            if(i + wordLength > text.Length) break;
            var sub = text.Substring(i,wordLength);
            if (sub == word)
            {
                count++;
            }
            
        }
        return count;
    }

    private void PopulateGrid()
    {
        // parse out the rows
        Rows = new List<string>(input.SplitToLines());
        
        // parse out the columns
        Columns = new List<string>();
        var firstRow = Rows.First();
        foreach (var letter in firstRow)
        {
            Columns.Add("");
        }
        
        // for each col 0,1,2, etc, build the strings from the rows
        foreach (var row in Rows)
        {
            for (var c = 0; c < row.Length; c++)
            {
                Columns[c] += row[c];
            }
        }
        
        // and parse out the diagonals
        PopulateDiagonals();
    }

    private void PopulateDiagonals()
    {
        var diagonals = new List<string>();
        var rowCount = Rows.Count;
        var colCount = Columns.Count;

        // Top-left to bottom-right diagonals
        for (var col = 0; col < colCount; col++)
        {
            diagonals.Add(GetDiagonalFromRowAndCol(0, col, 1, 1));
        }
        for (var row = 1; row < rowCount; row++)
        {
            diagonals.Add(GetDiagonalFromRowAndCol(row, 0, 1, 1));
        }

        // Top-right to bottom-left diagonals
        for (var col = 0; col < colCount; col++)
        {
            diagonals.Add(GetDiagonalFromRowAndCol(0, col, 1, -1));
        }
        for (var row = 1; row < rowCount; row++)
        {
            diagonals.Add(GetDiagonalFromRowAndCol(row, colCount - 1, 1, -1));
        }

        this.Diagonals = diagonals;
    }

    private string GetDiagonalFromRowAndCol(int startRow, int startCol, int rowStep, int colStep)
    {
        var diagonal = "";
        var row = startRow;
        var col = startCol;
        var rowCount = Rows.Count;
        var colCount = Columns.Count;

        while (row >= 0 && row < rowCount && col >= 0 && col < colCount)
        {
            diagonal += Rows[row][col];
            row += rowStep;
            col += colStep;
        }

        return diagonal;
    }

    

    public List<string> Rows { get; set; }
    public List<string> Columns { get; set; }
    public List<string> Diagonals { get; set; }
}