using Lab2Interpreter;

var state = new ProgramState();

Console.WriteLine("CLI STARTED:");

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