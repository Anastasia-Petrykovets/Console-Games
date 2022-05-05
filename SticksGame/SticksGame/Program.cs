using SticksGame;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        StickGame game = new StickGame();
        game.Start();
        Console.ReadLine();
    }
}