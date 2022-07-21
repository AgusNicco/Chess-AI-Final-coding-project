using Classes;
using System.Diagnostics;
public class Program
{
    static void Main()
    {   
        Game.Board = new List<List<char>> {
        new List<char> {'5','3','4','8','9','4','3','5'},// 0
        new List<char> {'1','1','1','1','1','1','1','1'},// 1
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},// 2
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},// 3
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},// 4
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},// 5
        new List<char> {'P','P','P','P','P','P','P','P'},// 6
        new List<char> {'R','N','B','Q','K','B','N','R'} // 7
        }; //            0   1   2   3   4   5   6   7

        Game game = new Game();
        List<Move> moves = Game.GetLegalMoves(true, Game.Board);
        Debug.Assert(false);
       
    }
}