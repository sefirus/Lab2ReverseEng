namespace Lab2Interpreter.Commands;

public class AtomicCommand : ICommand
{
    private readonly string _value;

    public AtomicCommand(string x)
    {
        _value = x;
    }

    public void Execute(ProgramState state)
    {
        new PushCommand(_value).Execute(state);
        var value = new PopCommand().PopValue(state);
        state.Proof[state.Pc].IsAssertion = false;
        state.Proof[state.Pc].Operation = value.ToString();
        state.Pc++; 
        state.PrintProof();
    }
}