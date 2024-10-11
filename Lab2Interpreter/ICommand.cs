using Lab2Interpreter;

public interface ICommand
{
    void Execute(ProgramState state);
}