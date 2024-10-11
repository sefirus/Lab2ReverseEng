namespace Lab2Interpreter.Commands;

public class ImplicationCommand : ICommand
{
    private readonly string _arg1;
    private readonly string _arg2;

    public ImplicationCommand(string arg1, string arg2)
    {
        _arg1 = arg1;
        _arg2 = arg2;
    }

    public void Execute(ProgramState state)
    {
        var pushCommand1 = new PushCommand(_arg1);
        pushCommand1.Execute(state);

        var pushCommand2 = new PushCommand(_arg2);
        pushCommand2.Execute(state);

        var popCommand = new PopCommand();
        byte arg2Value = popCommand.PopValue(state);
        byte arg1Value = popCommand.PopValue(state);

        state.Proof[state.Pc].IsAssertion = false;
        state.Proof[state.Pc].Operation = "IMPLICATION";
        state.Proof[state.Pc].Arg1 = arg1Value;
        state.Proof[state.Pc].Arg2 = arg2Value;
        state.Pc++;
        state.PrintProof();
    }
}