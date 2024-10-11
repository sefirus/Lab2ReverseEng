using Lab2Interpreter.Commands;

namespace Lab2Interpreter;

public static class CommandFactory
{
    public static ICommand? CreateCommand(string input)
    {
        var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
            return null;

        switch (tokens[0].ToLower())
        {
            case "push":
                if (tokens.Length == 2)
                {
                    return new PushCommand(tokens[1]);
                }

                Console.WriteLine("INVALID USAGE: push X");
                return null;
            case "pop":
                return new PopCommand();
            case "output":
                if (tokens.Length == 2 && tokens[1].Length == 1)
                {
                    return new OutputCommand(tokens[1]);
                }

                Console.WriteLine("INVALID USAGE: output X");
                return null;
            case "atomic":
                if (tokens.Length == 2 && tokens[1].Length == 1)
                {
                    return new AtomicCommand(tokens[1]);
                }

                Console.WriteLine("INVALID USAGE: atomic X");
                return null;                
            case "impl":
                if (tokens.Length == 3)
                {
                    return new ImplicationCommand(tokens[1], tokens[2]);
                }
                Console.WriteLine("INVALID USAGE: impl A B");
                return null;
            case "exit":
                return new ExitCommand();
            default:
                Console.WriteLine($"UNKNOWN COMMAND: {tokens[0]}");
                return null;
        }
    }
}