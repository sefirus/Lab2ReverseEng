namespace Lab2Interpreter.Commands;

public class CheatAssertionCommand : ICommand
{
    private readonly string _arg;

    public CheatAssertionCommand(string arg)
    {
        _arg = arg;
    }

    public void Execute(ProgramState state)
    {
        new PushCommand(_arg).Execute(state);
        byte A = new PopCommand().PopValue(state);

        if (state.CheatMode)
        {
            state.Proof[A].IsAssertion = true;
        }

        state.PrintProof();
    }
    
}