namespace Lab2Interpreter.Commands;

public class ModusPonensCommand : ICommand
{
    private readonly string _arg1;
    private readonly string _arg2;

    public ModusPonensCommand(string arg1, string arg2)
    {
        _arg1 = arg1;
        _arg2 = arg2;
    }

    public void Execute(ProgramState state)
    {
        new PushCommand(_arg1).Execute(state);
        new PushCommand(_arg2).Execute(state);

        byte B = new PopCommand().PopValue(state);
        byte A = new PopCommand().PopValue(state);

        if (state.Proof[B].Operation == "IMPLICATION" && state.Proof[B].Arg2 == A)
        {
            state.Proof[state.Pc].IsAssertion = true;
            state.Proof[state.Pc].Operation = "IMPLICATION";
            state.Proof[state.Pc].Arg1 = A;
            state.Proof[state.Pc].Arg2 = B;
            state.Pc++;
        }

        state.PrintProof();
    }
}

