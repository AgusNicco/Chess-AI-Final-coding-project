using NUnit.Framework;
using Classes;
using System.Collections.Generic;

namespace Test;

public class LinkedListNodeTests
{
    [Test]
    public void TestCheckMate()
    {
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
        AI.SwitchDifficulty(AI.Difficulty.Easy);
        Game.Board = new char[3][] {
        new char [] {' ',' ','X'},
        new char [] {' ','X',' '},
        new char [] {'X',' ',' '}  };

        Assert.AreEqual(AI.EvaluatePosition(Game.CharArrayToList(Game.Board), false), 3);

        Game.Board = new char[3][] {
        new char [] {'X',' ','X'},
        new char [] {' ','O',' '},
        new char [] {'X',' ','O'}  };

        Assert.AreEqual(AI.EvaluatePosition(Game.CharArrayToList(Game.Board), false), 0);

        Game.Board = new char[3][] {
        new char [] {'X',' ',' '},
        new char [] {' ','X',' '},
        new char [] {' ',' ','X'}  };

        Assert.AreEqual(AI.EvaluatePosition(Game.CharArrayToList(Game.Board), false), 3);


        Game.Board = new char[3][] {
        new char [] {'X','O','X'},
        new char [] {'X','O',' '},
        new char [] {'X',' ','O'}  };


        Assert.AreEqual(AI.EvaluatePosition(Game.CharArrayToList(Game.Board), false), 3);

        Game.Board = new char[3][] {
        new char [] {'X',' ','X'},
        new char [] {' ','O',' '},
        new char [] {' ',' ','X'}  };

        Assert.AreEqual(AI.EvaluatePosition(Game.CharArrayToList(Game.Board), false), 0);


        Game.Board = new char[3][] {
        new char [] {'O',' ','X'},
        new char [] {'X','O','X'},
        new char [] {'X',' ','O'}  };

        Assert.AreEqual(AI.EvaluatePosition(Game.CharArrayToList(Game.Board), true), -3);

        Game.Board = new char[3][] {
        new char [] {'O',' ','O'},
        new char [] {'X','X','O'},
        new char [] {'X','X','O'}  };

        Assert.AreEqual(AI.EvaluatePosition(Game.CharArrayToList(Game.Board), true), -3);
    }

    [Test]
    public void TestTranslateCoord()
    {
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
        Move m = Game.TranslateMove("1");
        Assert.True(Game.TranslateMove("1") == new Move(false, 0, 0));
        Assert.True(Game.TranslateMove("2") == new Move(false, 0, 1));
        Assert.True(Game.TranslateMove("3") == new Move(false, 0, 2));
        Assert.True(Game.TranslateMove("5") == new Move(false, 1, 1));
        Assert.True(Game.TranslateMove("7") == new Move(false, 2, 0));
        Assert.True(Game.TranslateMove("9") == new Move(false, 2, 2));
    }


    [Test]
    public void TestReference() // this test confirms the need for passing by value in the node class with the DoMoveWithCleanCopy()
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
    public void TestNodeRecursion()
    {
        AI.Node node = new AI.Node(Game.CharArrayToList(new char[3][] {
        new char [] {' ',' ',' '},
        new char [] {' ',' ',' '},
        new char [] {' ',' ',' '}
        }), true, new Move(true, 0, 0, true), 1);


        Assert.True(true); // the point of this test is to see if the recursion  works and doesn't get stuck in an infinte loop 
        // if it doesn't blow up it passed 
    }

    [Test]
    public void TestFindBestMoveImpossibleDifficulty()
    {
        AI.SwitchDifficulty(AI.Difficulty.Impossible);

        AI.Node node1 = new AI.Node(Game.CharArrayToList(new char[3][] {
        new char [] {'X','O',' '},
        new char [] {'X','O',' '},
        new char [] {'O',' ',' '}
        }), true, new Move(true, 0, 0, true), 1);

        Assert.True(node1.BestMove == new Move(true, 2, 1));


        AI.Node node2 = new AI.Node(Game.CharArrayToList(new char[3][] {
        new char [] {'X',' ',' '},
        new char [] {'O','X',' '},
        new char [] {' ',' ','O'}
        }), true, new Move(true, 0, 0, true), 1);

        Assert.True(node2.BestMove == new Move(true, 0, 1) || node2.BestMove == new Move(true, 0, 2));


        AI.Node node3 = new AI.Node(Game.CharArrayToList(new char[3][] {
        new char [] {'X','O',' '},
        new char [] {'X',' ',' '},
        new char [] {'O',' ',' '}
        }), true, new Move(true, 0, 0, true), 1);

        Assert.True(node3.BestMove == new Move(true, 1, 1));
    }

    [Test]
    public void TestFindBestMoveEasyDifficulty()
    {
        AI.SwitchDifficulty(AI.Difficulty.Easy);

        AI.Node node1 = new AI.Node(Game.CharArrayToList(new char[3][] {
        new char [] {'X','O',' '},
        new char [] {'X','X','O'},
        new char [] {'O',' ',' '}
        }), true, new Move(true, 0, 0, true), 1);

        Assert.True(node1.BestMove == new Move(true, 2, 2));


        AI.Node node2 = new AI.Node(Game.CharArrayToList(new char[3][] {
        new char [] {'X',' ',' '},
        new char [] {'O','X',' '},
        new char [] {' ',' ','O'}
        }), true, new Move(true, 0, 0, true), 1);

        Assert.False(node2.BestMove == new Move(true, 0, 1) || node2.BestMove == new Move(true, 0, 2));
        //  this makes sure the AI is not too strong at this this difficulty


        AI.Node node3 = new AI.Node(Game.CharArrayToList(new char[3][] {
        new char [] {'X','O',' '},
        new char [] {'X',' ',' '},
        new char [] {'O',' ',' '}
        }), true, new Move(true, 0, 0, true), 1);

        Assert.False(node3.BestMove == new Move(true, 1, 1));
    }

    [Test]
    public void TestAIPlaysLegally()
    {
        Game.Board = new char[3][] {
        new char [] {'X',' ',' '},
        new char [] {' ',' ',' '},
        new char [] {' ','X','O'}  };

        List<Point> FreeCells = new List<Point> { };

        for (int y = 0; y < Game.Board.Length; y++)
        {
            for (int x = 0; x < Game.Board[y].Length; x++)
            {
                Point p = new Point();
                p.coordinateY = y;
                p.coordinateX = x;
                if (p.Validate() && Game.Board[p.coordinateY][p.coordinateX] == ' ')
                    FreeCells.Add(p);
            }
        }

        // REQUIREMENT 15, use of a generic datatype

        // Had to use IEnumetaror because Move does not have a definition for GetEnumerator and would not work with a foreach loop, uncomment the code below to see.
        List<Move> ListOfMoves = AI.GetPossibleMoves(Game.CharArrayToList(Game.Board));
        IEnumerator<Move> iterator = ListOfMoves.GetEnumerator();

        while (iterator.MoveNext())
        {
            Move m = iterator.Current;
            bool IsInList = false;
            foreach (Point p in FreeCells)
            {   
                if (m == p)
                IsInList = true;  
            }
            Assert.True(IsInList);
        }

        // This would say 'm' does not exist in the current context

        // foreach (Move m in AI.GetPossibleMoves(Game.CharArrayToList(Game.Board))) ;
        // {
        //     bool IsInList = false;
        //     foreach (Point p in FreeCells)
        //     {   
        //         if (m == p)
        //         IsInList = true;  
        //     }
        //     Assert.True(IsInList);
        // }


    }

    [Test]
    public void TestDepthOfSearch()
    {
       
        AI.NumberOfNodes = 0;
        AI.SwitchDifficulty(AI.Difficulty.Easy);

        Game.Board = new char[3][] {
        new char [] {' ',' ',' '},
        new char [] {' ',' ',' '},
        new char [] {' ',' ',' '}  };

        Move move = AI.GetBestMove(Game.CharArrayToList(Game.Board));

        Assert.True(AI.NumberOfNodes > 1 && AI.NumberOfNodes < 100);


        AI.NumberOfNodes = 0;
        AI.SwitchDifficulty(AI.Difficulty.Intermediate);

        Game.Board = new char[3][] {
        new char [] {' ',' ',' '},
        new char [] {' ',' ',' '},
        new char [] {' ',' ',' '}  };

        Move move2 = AI.GetBestMove(Game.CharArrayToList(Game.Board));

        Assert.True(AI.NumberOfNodes > 100 && AI.NumberOfNodes < 1000);


        AI.NumberOfNodes = 0;
        AI.SwitchDifficulty(AI.Difficulty.Hard);

        Game.Board = new char[3][] {
        new char [] {' ',' ',' '},
        new char [] {' ',' ',' '},
        new char [] {' ',' ',' '}  };

        Move move3 = AI.GetBestMove(Game.CharArrayToList(Game.Board));

        Assert.True(AI.NumberOfNodes > 1000 && AI.NumberOfNodes < 10000);


        AI.NumberOfNodes = 0;
        AI.SwitchDifficulty(AI.Difficulty.Impossible);

        Game.Board = new char[3][] {
        new char [] {' ',' ',' '},
        new char [] {' ',' ',' '},
        new char [] {' ',' ',' '}  };

        Move move4 = AI.GetBestMove(Game.CharArrayToList(Game.Board));

        Assert.True(AI.NumberOfNodes > 300000 && AI.NumberOfNodes < 1000000);
    }

    [Test]
    public void TestIsBoardFull()
    {
        Game.Board = new char[3][] {
        new char [] {'X','O','X'},
        new char [] {'O','X','O'},
        new char [] {'O','X','O'}  };

        Assert.True(Game.IsBoardFull());


        Game.Board = new char[3][] {
        new char [] {'X','O','X'},
        new char [] {' ','X','O'},
        new char [] {'O','X','O'}  };

        Assert.False(Game.IsBoardFull());
    }
}

