using System.Reflection;

namespace AdventOfCode.Common;

public class InputReader
{
    public static string ReadInput(string inputFileName)
    {
        var resourceStream = ReadInputAsStream(inputFileName);

        using (resourceStream)
        using (var streamReader = new StreamReader(resourceStream))
        {
            return streamReader.ReadToEnd();
        }
    }

    public static IEnumerable<string> ReadInputAsLines(string inputFileName)
    {
        return new LineReader(() => ReadInputAsStream(inputFileName));
    }

    public static Stream ReadInputAsStream(string inputFileName)
    {
        var resourceStream = Assembly.GetCallingAssembly().GetManifestResourceStream(inputFileName);

        if (resourceStream == null)
        {
            throw new ArgumentNullException(nameof(inputFileName), $"{inputFileName} file stream cannot be null");
        }
        return resourceStream;
    }
}