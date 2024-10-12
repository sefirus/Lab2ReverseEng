namespace Lab2Interpreter.Commands;

public class PushCommand : ICommand
{
    private readonly byte _value;
    public PushCommand(string x)
    {
        if (byte.TryParse(x, out var value))
        {
            _value = value;
            return;
        }
        else if (x.Length != 1)
        {
            throw new ArgumentException("INVALID ARG");
        }
        _value = (byte)(x[0] - 'a');
    }

    public void Execute(ProgramState state)
    {
        state.Stack[--state.StackTop] = (byte)_value;
        
        Console.WriteLine($"STACK PUSHED: {state.StackTop} : {(byte)_value}");
    }
}