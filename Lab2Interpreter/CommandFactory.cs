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
            case "eq13":
                if (tokens.Length == 3)
                {
                    return new Eq13Command(tokens[1], tokens[2]);
                }
                Console.WriteLine("INVALID USAGE: eq13 A B");
                return null;

            case "eq14":
                if (tokens.Length == 3)
                {
                    return new Eq14Command(tokens[1], tokens[2]);
                }
                Console.WriteLine("INVALID USAGE: eq14 A B");
                return null;
            case "modus":
                if (tokens.Length == 3)
                {
                    return new ModusPonensCommand(tokens[1], tokens[2]);
                }
                Console.WriteLine("INVALID USAGE: modus A B");
                return null;
            case "trans":
                if (tokens.Length == 3)
                {
                    return new TransitivityOfImplicationsCommand(tokens[1], tokens[2]);
                }
                Console.WriteLine("INVALID USAGE: trans A B");
                return null;
            case "conseq":
                if (tokens.Length == 2)
                    return new AssertConsequentCommand(tokens[1]);
                Console.WriteLine("INVALID USAGE: conseq A");
                return null;

            case "cheat":
                if (tokens.Length == 2)
                    return new CheatAssertionCommand(tokens[1]);
                Console.WriteLine("INVALID USAGE: cheat A");
                return null;

            case "goal":
                if (tokens.Length == 2)
                    return new SetGoalCommand(tokens[1]);
                Console.WriteLine("INVALID USAGE: goal A");
                return null;
            case "exit":
                return new ExitCommand();
            default:
                Console.WriteLine($"UNKNOWN COMMAND: {tokens[0]}");
                return null;
        }
    }
}