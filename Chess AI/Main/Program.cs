using Classes;
using System.Diagnostics;
public class Program
{
    static void Main()
    {   
        
        Game game = new Game();
        Stopwatch stop = new Stopwatch();
        stop.Start();
        List<Move> moves = Game.GetLegalMoves(true, Game.Board);
        stop.Stop();
        Console.WriteLine(stop.ElapsedMilliseconds);  
    }
}