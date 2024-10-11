namespace Lab2Interpreter.Commands;

public class PopCommand : ICommand
{
    public void Execute(ProgramState state)
    {
        var value = state.Stack[state.StackTop];
        Console.WriteLine($"STACK POPPED: {state.StackTop} : {value} | {(char)(value + 'a')}");
        state.StackTop++;
    }

    public byte PopValue(ProgramState state)
    {
        var value = state.Stack[state.StackTop];
        Console.WriteLine($"STACK POPPED: {state.StackTop} : {value} | {(char)(value + 'a')}");
        state.StackTop++;
        return value;
    }
}