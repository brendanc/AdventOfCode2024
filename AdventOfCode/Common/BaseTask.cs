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

    protected virtual string SampleFileName
    {
        get
        {
            var t = this.GetType().ToString();
            var last = t.LastIndexOf('.');
            return t.Substring(0, last) + ".Sample.txt";
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
    
    protected IEnumerable<string> GetSample()
    {
        return InputReader.ReadInputAsLines(SampleFileName);
    }

    protected string GetSampleAsSingleString()
    {
        return InputReader.ReadInput(SampleFileName);
    }
}
