namespace Lab2Interpreter.Commands;

public class ExitCommand : ICommand
{
    public void Execute(ProgramState state)
    {
        Console.WriteLine("EXITING");
        Environment.Exit(0);
    }
}