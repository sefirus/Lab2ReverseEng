namespace Lab2Interpreter.Commands;

public class AssertConsequentCommand : ICommand
{
    private readonly string _arg;

    public AssertConsequentCommand(string arg)
    {
        _arg = arg;
    }

    public void Execute(ProgramState state)
    {
        new PushCommand(_arg).Execute(state);
        byte A = new PopCommand().PopValue(state);

        if (state.Proof[A].Operation == "IMPLICATION" &&
            state.Proof[A].IsAssertion &&
            state.Proof[state.Proof[A].Arg1].IsAssertion)
        {
            state.Proof[state.Proof[A].Arg2].IsAssertion = true;
        }

        state.PrintProof();
    }
}