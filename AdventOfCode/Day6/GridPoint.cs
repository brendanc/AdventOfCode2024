namespace AdventOfCode.Day6;

public class GridPoint
{
    public GridPoint(int row, int col, char value)
    {
        this.Row = row;
        this.Column = col;
        this.Value = value;
    }
    
    public int Row { get; set; }
    public int Column { get; set; }
    public char Value { get; set; }

    public GridPoint Up => new GridPoint(Row - 1, Column, Value);
    public GridPoint Down => new GridPoint(Row + 1, Column, Value);
    public GridPoint Left => new GridPoint(Row, Column - 1, Value);
    public GridPoint Right => new GridPoint(Row, Column + 1, Value);

    public void Turn()
    {
        switch (Value)
        {
            case '^':
                Value = '>';
                return;
            case '>':
                Value = 'v';
                return;
            case 'v':
                Value = '<';
                return;
            case '<':
                Value = '^';
                return;
        }

        throw new ArgumentException("Bad turn!  " + Value);
    }
    
    public GridPoint Forward
    {
        get
        {
            switch (Value)
            {
                case '^':
                    return Up;
                case '>':
                    return Right;
                case 'v':
                    return Down;
                case '<':
                    return Left;
            }

            throw new ArgumentException("Bad forward => " + Value);
        }
    }
    
    public override string ToString()
    {
        return $"{Column},{Row} => {Value}";
    }
}