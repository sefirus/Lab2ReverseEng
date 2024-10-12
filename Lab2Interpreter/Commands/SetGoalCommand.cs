namespace Lab2Interpreter.Commands;

public class SetGoalCommand : ICommand
{
    private readonly string _arg;

    public SetGoalCommand(string arg)
    {
        _arg = arg;
    }

    public void Execute(ProgramState state)
    {
        new PushCommand(_arg).Execute(state);
        byte A = new PopCommand().PopValue(state);

        if (state.CheatMode)
        {
            state.Goal = A;
        }
        state.CheatMode = false;

        state.PrintProof();
    }
}
