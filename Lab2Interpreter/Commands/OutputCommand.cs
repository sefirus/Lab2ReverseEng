namespace Lab2Interpreter.Commands;

public class OutputCommand : ICommand
{
    private readonly string _value;

    public OutputCommand(string x)
    {
        _value = x;
    }

    public void Execute(ProgramState state)
    {
        new PushCommand(_value).Execute(state);
        var value = new PopCommand().PopValue(state);
        
        if (state.Goal < 0 || state.Proof[state.Goal].IsAssertion)
        {
            var outputChar = (char)(value + 'a');
            Console.WriteLine($"OUTPUT: {outputChar}");
        }
        else
        {
            Console.WriteLine("NO RESULT");
        }
    }
}