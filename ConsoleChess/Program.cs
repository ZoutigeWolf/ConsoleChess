namespace ConsoleChess;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        
        Chess chess = new Chess();
        chess.DoMove();
    }
}
