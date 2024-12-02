namespace AdventOfCode.Common;

public class TaskResolver
{
    /// <summary>
    /// Take a task number and resolve to a task class.
    /// Examples:
    /// 1.1 => Day 1, Task 1 => AdventOfCode2022.Day1.Task1
    /// 4.2 => Day 4, Task 2 => AdventOfCode2022.Day4.Task2
    /// etc....
    /// </summary>
    /// <param name="taskNumber"></param>
    /// <returns></returns>
    public static IAdventOfCodeTask? ResolveTask(string taskNumber)
    {
        var splits = taskNumber.Split('.');
        var taskDay = splits[0];
        var task = splits[1];
        var fullClassName = $"AdventOfCode.Day{taskDay}.Task{task}";
        var objectType = Type.GetType(fullClassName);
        if(objectType == null)
            return null;
        return Activator.CreateInstance(objectType) as IAdventOfCodeTask;
    }
}