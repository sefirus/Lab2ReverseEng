namespace Lab2Interpreter.Commands;

public class PushCommand : ICommand
{
    private readonly int _value;

    public PushCommand(char x)
    {
        _value = x;
    }
    
    public PushCommand(int x)
    {
        _value = x;
    }
    
    public PushCommand(string x)
    {
        if (int.TryParse(x, out var value))
        {
            _value = value;
            return;
        }
        else if (x.Length != 1)
        {
            throw new ArgumentException("INVALID ARG");
        }
        _value = x[0] - 'a';
    }

    public void Execute(ProgramState state)
    {
        state.Stack[--state.StackTop] = (byte)_value;
        
        Console.WriteLine($"STACK PUSHED: {state.StackTop} : {(byte)_value}");
    }
}