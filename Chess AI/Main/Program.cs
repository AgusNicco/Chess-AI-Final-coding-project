using Classes;
using System.Diagnostics;
public class Program
{
    static void Main()
    {   
        Game.Board = new List<List<byte>> {   
        new List<byte> {55,33,44,88,99,44,33,55},// 0
        new List<byte> {11,11,11,11,11,11,11,11},// 1
        new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0},// 2 
        new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0},// 3
        new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0},// 4
        new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0},// 5
        new List<byte> { 1, 1, 1, 1, 1, 1, 1, 1},// 6
        new List<byte> { 5, 3, 4, 8, 9, 4, 3, 5} // 7
        }; //            0  1  2  3  4  5  6  7

        Game game = new Game();
        Stopwatch stop = new Stopwatch();
        stop.Start();
        List<Move> moves = Game.GetLegalMoves(true, Game.Board);
        stop.Stop();
        Console.WriteLine(stop.ElapsedTicks);
        //Debug.Assert(false);
       
  
    }
}