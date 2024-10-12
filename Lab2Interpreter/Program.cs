using Lab2Interpreter;

var state = new ProgramState();

var initialProgram = "ba k bb k bc k bb ba m bc bb m bc ba m bd t be t bb j bf u" + "bh bg n bg bh m bh bg p bi s";
List<string> commands = new List<string>();
for (int i = 0; i < initialProgram.Length; i++)
{
    string A, B, previousPush;
    switch (initialProgram[i])
    {
        case 'b':
            commands.Add($"push {initialProgram[++i]}");
            break;
        case 'k':
            previousPush = commands.Last();
            commands.RemoveAt(commands.Count - 1);
            commands.Add($"atomic { previousPush.Last() }");
            break;
        case 'm':
            A = commands.Last();
            commands.RemoveAt(commands.Count - 1);
            B = commands.Last();
            commands.RemoveAt(commands.Count - 1);
            commands.Add($"impl { A.Last() } { B.Last() }");
            break;
        case 't':
            previousPush = commands.Last();
            commands.RemoveAt(commands.Count - 1);
            commands.Add($"cheat { previousPush.Last() }");
            break;
        case 'j':
            
            break;
        case 'u':
            previousPush = commands.Last();
            commands.RemoveAt(commands.Count - 1);
            commands.Add($"goal { previousPush.Last() }");
            break;
        case 'n':
            A = commands.Last();
            commands.RemoveAt(commands.Count - 1);
            B = commands.Last();
            commands.RemoveAt(commands.Count - 1);
            commands.Add($"eq13 { A.Last() } { B.Last() }");
            break;
        case 'p':
            A = commands.Last();
            commands.RemoveAt(commands.Count - 1);
            B = commands.Last();
            commands.RemoveAt(commands.Count - 1);
            commands.Add($"modus { A.Last() } { B.Last() }");
            break;
        case 's':
            previousPush = commands.Last();
            commands.RemoveAt(commands.Count - 1);
            commands.Add($"conseq { previousPush.Last() }");
            break;
    }
}

Console.WriteLine("CLI STARTED:");

foreach (var commandText in commands)
{
    Console.WriteLine($">>> EXECUTING: {commandText}");
    var command = CommandFactory.CreateCommand(commandText);
    if (command != null)
    {
        command.Execute(state);
    }
}

Console.WriteLine("INITIAL STATE:");
state.PrintProof();

while (true)
{
    Console.Write("> ");
    var input = Console.ReadLine();
    try
    {
        var command = CommandFactory.CreateCommand(input);
        if (command != null)
        {
            command.Execute(state);
        }
    }
    catch (ArgumentException arg)
    {
        Console.WriteLine(arg.Message);
    }
    catch (Exception e)
    {
        Console.WriteLine("UNEXPECTED EXCEPTION:");
        Console.WriteLine(e);
    }
}