namespace Lab2Interpreter.Commands;
public class TransitivityOfImplicationsCommand : ICommand
{
    private readonly string _arg1;
    private readonly string _arg2;

    public TransitivityOfImplicationsCommand(string arg1, string arg2)
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

        if (state.Proof[A].Operation == "IMPLICATION" &&
            state.Proof[B].Operation == "IMPLICATION" &&
            state.Proof[state.Proof[A].Arg2].Operation == "IMPLICATION" &&
            state.Proof[state.Proof[B].Arg1].Operation == "IMPLICATION" &&
            state.Proof[state.Proof[B].Arg1].Arg1 == state.Proof[A].Arg1 &&
            state.Proof[state.Proof[B].Arg1].Arg2 == state.Proof[state.Proof[A].Arg2].Arg1 &&
            state.Proof[state.Proof[B].Arg2].Operation == "IMPLICATION" &&
            state.Proof[state.Proof[B].Arg2].Arg1 == state.Proof[A].Arg1 &&
            state.Proof[state.Proof[B].Arg2].Arg2 == state.Proof[state.Proof[A].Arg2].Arg2)
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