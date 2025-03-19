using System.Diagnostics;

namespace HSE_Bank.Patterns.Command;

public class TimedCommandDecorator : ICommand
{
    private readonly ICommand _command;

    public TimedCommandDecorator(ICommand command)
    {
        _command = command;
    }

    public void Execute()
    {
        var stopwatch = Stopwatch.StartNew();
        _command.Execute();
        stopwatch.Stop();
        Console.WriteLine($"Command executed in {stopwatch.ElapsedMilliseconds} ms");
    }
}