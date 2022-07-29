using NUnit.Framework;
using Classes;

namespace Test;

public class LinkedListNodeTests
{
    [Test]
    public void TestCheckMate()
    {
        Game test = new Game();

        Game.Board = new char[3][] {
        new char [] {'X','X','X'},
        new char [] {' ',' ',' '},
        new char [] {' ',' ',' '}  };
        Assert.True(Game.IsCheckMate());

        Game.Board = new char[3][] {
        new char [] {'O',' ',' '},
        new char [] {' ','O',' '},
        new char [] {' ',' ','O'}  };
        Assert.True(Game.IsCheckMate());

        Game.Board = new char[3][] {
        new char [] {' ',' ','O'},
        new char [] {' ','O',' '},
        new char [] {'O',' ',' '}  };
        Assert.True(Game.IsCheckMate());

        Game.Board = new char[3][] {
        new char [] {' ',' ','X'},
        new char [] {' ',' ','X'},
        new char [] {' ',' ','X'}  };
        Assert.True(Game.IsCheckMate());

        Game.Board = new char[3][] {
        new char [] {'O','O','X'},
        new char [] {'X','X','O'},
        new char [] {'O','O','X'}  };
        Assert.False(Game.IsCheckMate());
    }

    [Test]
    public void TestEvaluatePosition()
    {
        Game test = new Game();
        AI AI = new AI();

        Game.Board = new char[3][] {
        new char [] {' ',' ','X'},
        new char [] {' ','X',' '},
        new char [] {'X',' ',' '}  };

        Assert.AreEqual(AI.EvaluatePosition(Game.CharArrayToList(Game.Board)), 3);

        Game.Board = new char[3][] {
        new char [] {'X',' ','X'},
        new char [] {' ','O',' '},
        new char [] {'X',' ','O'}  };

        Assert.AreEqual(AI.EvaluatePosition(Game.CharArrayToList(Game.Board)), 0);

        Game.Board = new char[3][] {
        new char [] {'X',' ',' '},
        new char [] {' ','X',' '},
        new char [] {' ',' ','X'}  };

        Assert.AreEqual(AI.EvaluatePosition(Game.CharArrayToList(Game.Board)), 3);


        Game.Board = new char[3][] {
        new char [] {'X','O','X'},
        new char [] {'X','O',' '},
        new char [] {'X',' ','O'}  };


        Assert.AreEqual(AI.EvaluatePosition(Game.CharArrayToList(Game.Board)), 3);

        Game.Board = new char[3][] {
        new char [] {'X',' ','X'},
        new char [] {' ','O',' '},
        new char [] {' ',' ','X'}  };

        Assert.AreEqual(AI.EvaluatePosition(Game.CharArrayToList(Game.Board)), 0);


        Game.Board = new char[3][] {
        new char [] {'O',' ','X'},
        new char [] {'X','O','X'},
        new char [] {'X',' ','O'}  };

        Assert.AreEqual(AI.EvaluatePosition(Game.CharArrayToList(Game.Board)), -3);

        Game.Board = new char[3][] {
        new char [] {'O',' ','O'},
        new char [] {'X','X','O'},
        new char [] {'X','X','O'}  };

        Assert.AreEqual(AI.EvaluatePosition(Game.CharArrayToList(Game.Board)), -3);
    }

    [Test]
    public void TestTranslateCoord()
    {
        Game test = new Game();

        Assert.AreEqual(Game.TranslateCoord(1), new int[] { 0, 0 });
        Assert.AreEqual(Game.TranslateCoord(2), new int[] { 0, 1 });
        Assert.AreEqual(Game.TranslateCoord(3), new int[] { 0, 2 });
        Assert.AreEqual(Game.TranslateCoord(4), new int[] { 1, 0 });
        Assert.AreEqual(Game.TranslateCoord(5), new int[] { 1, 1 });
        Assert.AreEqual(Game.TranslateCoord(6), new int[] { 1, 2 });
        Assert.AreEqual(Game.TranslateCoord(8), new int[] { 2, 1 });
    }

    [Test]
    public void TestTranslateMove()
    {
        Assert.AreEqual(Game.TranslateMove("1"), new Move(false, 0, 0, "1"));
    }


    [Test]
    public void TestReference()
    {
        char[][] x = new char[3][] {
        new char [] {' ','O',' '},
        new char [] {'O','X',' '},
        new char [] {' ',' ',' '}
        };
        char[][] y = x;
        x[0][0] = 'X';
        Assert.True(y[0][0] == 'X');

        int[][] z = new int[3][] {
        new int[] {1, 1, 1},
        new int[] {1, 1, 1},
        new int[] {1, 1, 1}
        };
        int[][] w = z;
        z[0][0] = 0;
        Assert.True(w[0][0] == 0);
    }


    [Test]
    public void TestNode() 
    {
        AI ai = new AI();
        AI.SearchDepth = 9;

        AI.Node node = new AI.Node(Game.CharArrayToList(new char[3][] {
        new char [] {' ',' ',' '},
        new char [] {' ',' ',' '},
        new char [] {' ',' ',' '}
        }), true, null, 1);

        
        Assert.True(true); // the point of this test is to see if the recursion  works and doesn't get stuck in an infinte loop 
        // if it doesn't blow up it passed 
    }

}

