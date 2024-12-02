namespace AdventOfCode.Common;

public abstract class BaseTask : IAdventOfCodeTask
{
    public BaseTask()
    {
    }

    public abstract void Run();


    protected virtual string InputFileName
    {
        get
        {
            var t = this.GetType().ToString();
            var last = t.LastIndexOf('.');
            return t.Substring(0, last) + ".Input1.txt";
        }
    }

    protected IEnumerable<string> GetInput()
    {
        return InputReader.ReadInputAsLines(InputFileName);
    }

    protected string GetInputAsSingleString()
    {
        return InputReader.ReadInput(InputFileName);
    }
}
