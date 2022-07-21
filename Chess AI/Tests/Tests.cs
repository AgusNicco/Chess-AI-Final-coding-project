using NUnit.Framework;
using Classes;
using System.Collections.Generic;
namespace Tests;

public class Tests
{
    [Test]
    public void TestIsInCheck()
    {


        Game.Board = new List<List<char>> {
        new List<char> {'5','3','4','8','9','4','3','5'},
        new List<char> {'1','1','1','1','1','1','1','1'},
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},
        new List<char> {'P','P','P','P','P','P','P','P'},
        new List<char> {'R','N','B','Q','K','B','N','R'}
        };

        Game game = new Game();
        //Assert.AreEqual(Game.WhiteKingCoords.y, 8);
        
        Assert.False(Game.IsInCheck(false));
    }
}

