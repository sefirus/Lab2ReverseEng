namespace Lab2Interpreter;

public class ProgramState
{
    public byte[] Stack { get; } = new byte[256];
    public byte StackTop { get; set; } = 255;
    
    public Proposition[] Proof { get; } = new Proposition[256];
    public int Pc { get; set; } = 0;

    public bool CheatMode { get; set; } = true;
    public int Goal { get; set; } = -1;
    
    public void PrintProof()
    {
        Console.WriteLine("\nCurrent Proof Array:");
        Console.WriteLine("Index | IsAssertion |   Operation   | Arg1 | Arg2");
        Console.WriteLine("------+-------------+---------------+------+------");
        for (int i = 0; i < 256; i++)
        {
            if (string.IsNullOrEmpty(Proof[i].Operation))
            {
                break;
            }
            var p = Proof[i];
            string operationDisplay = p.Operation;

            Console.WriteLine($"{i,5} | {p.IsAssertion,-11} | {operationDisplay,-13} | {p.Arg1,4} | {p.Arg2,4}");
        }
        Console.WriteLine();
    }
}