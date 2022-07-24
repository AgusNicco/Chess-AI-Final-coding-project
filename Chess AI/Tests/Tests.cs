using NUnit.Framework;
using Classes;
using System.Collections.Generic;
namespace Tests;

public class Tests
{

    bool IsMoveInList(Move move, List<Move> list)
    {
        foreach (Move m in list)
            if (move.GetTo().y == m.GetTo().y && move.GetTo().x == m.GetTo().x    &&    move.GetFrom().y == m.GetFrom().y && move.GetFrom().x == m.GetFrom().x)
                return true;
        return false;
    }

    [Test]
    public void RookMoves()
    {
        Game.Board = new List<List<char>> {
        new List<char> {'R','N','B','Q','K','B','N','R'},// 0
        new List<char> {' ','P','P','P','P','P','P','P'},// 1
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},// 2
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},// 3
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},// 4
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},// 5
        new List<char> {'1','1','1','1','1','1','1','1'},// 6
        new List<char> {'5','3','4','8','9','4','3','5'} // 7
        }; //            0   1   2   3   4   5   6   7
        Game game = new Game();
        
        List<Move> moves = Game.GetLegalMoves(true, Game.Board);

        Assert.True(IsMoveInList(new Move(new Point(0, 0), new Point(1, 0)), moves));
        Assert.True(IsMoveInList(new Move(new Point(0, 0), new Point(6, 0)), moves));
        Assert.False(IsMoveInList(new Move(new Point(0, 0), new Point(7, 0)), moves));
        Assert.False(IsMoveInList(new Move(new Point(0, 0), new Point(0, 1)), moves));
    }

    [Test]
    public void BishopMoves()
    {
        Game.Board = new List<List<char>> {
        new List<char> {'R','N',' ','Q','K','B','N','R'},// 0
        new List<char> {'P','P',' ','P','P','P','P','P'},// 1
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},// 2
        new List<char> {' ',' ',' ','B',' ',' ',' ',' '},// 3
        new List<char> {' ',' ','P',' ',' ',' ',' ',' '},// 4
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},// 5
        new List<char> {'1','1','1','1','1','1','1','1'},// 6
        new List<char> {'5','3','4','8','9','4','3','5'} // 7
        }; //            0   1   2   3   4   5   6   7
        Game game = new Game();
        
        List<Move> moves = Game.GetLegalMoves(true, Game.Board);

        Point from = new Point(3, 3);
        Assert.True(IsMoveInList(new Move(from, new Point(2, 4)), moves));
        Assert.False(IsMoveInList(new Move(from, new Point(1, 5)), moves));
        Assert.True(IsMoveInList(new Move(from, new Point(2, 4)), moves));
        Assert.False(IsMoveInList(new Move(from, new Point(1, 1)), moves));
        Assert.False(IsMoveInList(new Move(from, new Point(4, 2)), moves));
        Assert.True(IsMoveInList(new Move(from, new Point(4, 4)), moves));
        Assert.True(IsMoveInList(new Move(from, new Point(6, 6)), moves));
    }

    [Test]
    public void KnightMoves()
    {
        Game.Board = new List<List<char>> {
        new List<char> {'R',' ','B','Q','K','B','N','R'},// 0
        new List<char> {'P','P','P','P','P','P','P','P'},// 1
        new List<char> {' ',' ','P',' ',' ',' ',' ',' '},// 2
        new List<char> {' ',' ',' ',' ',' ','P',' ',' '},// 3
        new List<char> {' ',' ',' ','N',' ',' ',' ',' '},// 4
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},// 5
        new List<char> {'1','1','1','1','1','1','1','1'},// 6
        new List<char> {'5','3','4','8','9','4','3','5'} // 7
        }; //            0   1   2   3   4   5   6   7
        Game game = new Game();
        
        List<Move> moves3 = Game.GetLegalMoves(true, Game.Board);

        Point from = new Point(4, 3);
        Assert.True(IsMoveInList(new Move(from, new Point(3, 1)), moves3));
        Assert.False(IsMoveInList(new Move(from, new Point(2, 2)), moves3));
        Assert.True(IsMoveInList(new Move(from, new Point(2, 4)), moves3));
        Assert.False(IsMoveInList(new Move(from, new Point(3, 5)), moves3));
        Assert.True(IsMoveInList(new Move(from, new Point(5, 1)), moves3));
        Assert.True(IsMoveInList(new Move(from, new Point(6, 2)), moves3));
        Assert.True(IsMoveInList(new Move(from, new Point(6, 4)), moves3));
        Assert.True(IsMoveInList(new Move(from, new Point(5, 5)), moves3));
    }
}

