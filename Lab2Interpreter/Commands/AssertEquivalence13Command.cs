namespace Lab2Interpreter.Commands;

public class Eq13Command : ICommand
{
    private readonly string _arg1;
    private readonly string _arg2;

    public Eq13Command(string arg1, string arg2)
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

        int[] x = new int[256];
        int[] y = new int[256];
        x[0] = A;
        y[0] = B;
        int count = 1;

        while (count > 0)
        {
            count--;
            if (state.Proof[x[count]].Operation != state.Proof[y[count]].Operation)
            {
                count = -1;
                break;
            }
            else if (state.Proof[x[count]].Operation == "NOT")
            {
                x[count] = state.Proof[x[count]].Arg1;
                y[count] = state.Proof[y[count]].Arg1;
                count++;
            }
            else if (state.Proof[x[count]].Operation == "IMPLICATION")
            {
                int xc = x[count], yc = y[count];
                x[count] = state.Proof[xc].Arg1;
                y[count] = state.Proof[yc].Arg1;
                count++;
                x[count] = state.Proof[xc].Arg2;
                y[count] = state.Proof[yc].Arg2;
                count++;
            }
        }

        if (count == 0)
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