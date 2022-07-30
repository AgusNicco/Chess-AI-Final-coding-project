namespace Classes;


public interface AI
{
    // REQUIREMENT 11, this is one of many examples in which properties are used
    private static int SearchDepth { get; set; }
    private static char Skin = 'X';
    private static char EnemySkin = 'O';


    public enum Difficulty { Easy, Intermediate, Hard, Impossible }

    public static void SwitchDifficulty(Difficulty d)
    {
        switch (d)
        {
            case Difficulty.Easy:
                {
                    SearchDepth = 1;
                    break;
                }
            case Difficulty.Intermediate:
                {
                    SearchDepth = 2;
                    break;
                }
            case Difficulty.Hard:
                {
                    SearchDepth = 3;
                    break;
                }
            case Difficulty.Impossible:
                {
                    SearchDepth = 9;
                    break;
                }
        }
    }

    // REQUIREMENT 12, one of many examples of a static member function
    
    // Receives a given position and returns an integer score according to how convenient it is for the AI, if the position is lost it's a -3, if it is Won a 3 and if it is a draw a 0.
    // It has additional checks for the Impossible level of difficulty 

    // set to public for testing purposes
    public static double EvaluatePosition(List<char[]> Board = null, bool AiMove = true)
    {
        if (Board == null)
        {
            foreach (char[] ca in Game.Board)
                Board.Add(ca);
        }

        if (!AiMove)
        {
            if (Board[0][0] == Skin && Board[0][1] == Skin && Board[0][2] == Skin) return 3; // horizontal check
            if (Board[1][0] == Skin && Board[1][1] == Skin && Board[1][2] == Skin) return 3;
            if (Board[2][0] == Skin && Board[2][1] == Skin && Board[2][2] == Skin) return 3;

            if (Board[0][0] == Skin && Board[1][0] == Skin && Board[2][0] == Skin) return 3; // vertical check
            if (Board[0][1] == Skin && Board[1][1] == Skin && Board[2][1] == Skin) return 3;
            if (Board[0][2] == Skin && Board[1][2] == Skin && Board[2][2] == Skin) return 3;

            if (Board[0][0] == Skin && Board[1][1] == Skin && Board[2][2] == Skin) return 3; // diagonal check
            if (Board[2][0] == Skin && Board[1][1] == Skin && Board[0][2] == Skin) return 3;
        }
        else
        {
            if (Board[0][0] == EnemySkin && Board[0][1] == EnemySkin && Board[0][2] == EnemySkin) return -3; // horizontal check
            if (Board[1][0] == EnemySkin && Board[1][1] == EnemySkin && Board[1][2] == EnemySkin) return -3;
            if (Board[2][0] == EnemySkin && Board[2][1] == EnemySkin && Board[2][2] == EnemySkin) return -3;

            if (Board[0][0] == EnemySkin && Board[1][0] == EnemySkin && Board[2][0] == EnemySkin) return -3; // vertical check
            if (Board[0][1] == EnemySkin && Board[1][1] == EnemySkin && Board[2][1] == EnemySkin) return -3;
            if (Board[0][2] == EnemySkin && Board[1][2] == EnemySkin && Board[2][2] == EnemySkin) return -3;

            if (Board[0][0] == EnemySkin && Board[1][1] == EnemySkin && Board[2][2] == EnemySkin) return -3; // diagonal check
            if (Board[2][0] == EnemySkin && Board[1][1] == EnemySkin && Board[0][2] == EnemySkin) return -3;
        }

        // Additional check only for the impossible level of difficulty. It will analyse checkmate threats.
        if (SearchDepth > 4)
        {
            for (int y = 0; y < Board.Count(); y++) // horizontal
            {
                int x = 0;
                if (Board[y][x] == ' ' && Board[y][x + 1] == EnemySkin && Board[y][x + 2] == EnemySkin)
                    return -2;
                if (Board[y][x] == EnemySkin && Board[y][x + 1] == ' ' && Board[y][x + 2] == EnemySkin)
                    return -2;
                if (Board[y][x] == EnemySkin && Board[y][x + 1] == EnemySkin && Board[y][x + 2] == ' ')
                    return -2;
            }
            for (int x = 0; x < Board.Count(); x++) // vertical
            {
                int y = 0;
                if (Board[y][x] == ' ' && Board[y + 1][x] == EnemySkin && Board[y + 2][x] == EnemySkin)
                    return -2;
                if (Board[y][x] == EnemySkin && Board[y + 1][x] == ' ' && Board[y + 2][x] == EnemySkin)
                    return -2;
                if (Board[y][x] == EnemySkin && Board[y + 1][x] == EnemySkin && Board[y + 2][x] == ' ')
                    return -2;
            }
            
            // Diagonal 
            if (Board[0][0] == ' ' && Board[1][1] == EnemySkin && Board[2][2] == EnemySkin) 
                return -2; 
            if (Board[0][0] == EnemySkin && Board[1][1] == ' ' && Board[2][2] == EnemySkin) 
                return -2;
            if (Board[0][0] == EnemySkin && Board[1][1] ==  EnemySkin && Board[2][2] == ' ') 
                return -2;

            if (Board[2][0] == ' ' && Board[1][1] == EnemySkin && Board[0][2] == EnemySkin) 
                return -2;
            if (Board[2][0] == EnemySkin && Board[1][1] == ' ' && Board[0][2] == EnemySkin) 
                return -2;
            if (Board[2][0] == EnemySkin && Board[1][1] == EnemySkin && Board[0][2] == ' ') 
                return -2;
        }

        return 0;
    }


    // Receives a given position and returns a List with all the Legal moves that are possible in the position

    // set to public for testing purposes
    public static List<Move> GetPossibleMoves(List<char[]> Board = null, bool playedByAi = true)
    {
        if (Board == null)
        {
            foreach (char[] ca in Game.Board)
                Board.Add(ca);
        }

        List<Move> output = new List<Move> { };
        for (int y = 0; y < Board.Count(); y++)
        {
            for (int x = 0; x < Board[y].Count(); x++)
            { 
                if (Board[y][x] == ' ') output.Add(new Move(playedByAi, y, x));
                // Move m = new Move(playedByAi, y, x);
                // if (m.Validate()) 
                //     output.Add(m);
            }
        }
        return output;
    }


    public static int NumberOfNodes = 0; // public for testing 
    
    // Class used to store a hypothetical move, score it and create a the decision-making tree
    public class Node
    {
        private readonly bool MyMove;
        private readonly int Layer;
        private double Score; 
        private readonly Move? PlayedMove;
        public Move BestMove; // public for testing and for the GetBestMove() function
        private List<Move>? MovesToReachPosition; 
        private bool ShouldBranch;
        private List<Node>? BranchOfNodes;
        private bool Propagated = false;


        public Node(List<char[]> position, bool mymove = true, Move move = null, int layer = 0, List<Move>? movesToReachPosition = null)
        {
            MyMove = mymove;
            PlayedMove = move;
            Layer = layer;
            NumberOfNodes++;


            if (movesToReachPosition == null)
                movesToReachPosition = new List<Move> { };

            MovesToReachPosition = new List<Move> { };
            foreach (Move m in movesToReachPosition) // Assures the new list has a clean copy
            {
                MovesToReachPosition.Add(m);
            }
            MovesToReachPosition.Add(move);

            
            List<char[]> Position = DoMoveWithCleanCopy(position, PlayedMove);

            ShouldBranch = Layer <= AI.SearchDepth;


            Score = AI.EvaluatePosition(Position, MyMove);


            List<Move> ListOfMoves = AI.GetPossibleMoves(Position, MyMove);

            if (ListOfMoves.Count() == 0 || Math.Abs(Score) == 3) 
                ShouldBranch = false;

            // branching process
            if (ShouldBranch)
            {
                BranchOfNodes = new List<Node> { };

                foreach (Move m in ListOfMoves)
                {
                    // EXTRA CREDIT recursion
                    BranchOfNodes.Add(new Node(Position, !MyMove, m, Layer + 1));
                }
            }
            else BranchOfNodes = null;


            // Backpropagation of score 
            if (ShouldBranch)
            {
                double num = BranchOfNodes[0].Score;
                foreach (Node n in BranchOfNodes)
                {
                    if (MyMove)
                    {
                        if (n.Score >= num)
                        {
                            Propagated = true;
                            num = n.Score;
                            BestMove = n.PlayedMove;
                        }
                    }
                    else if (n.Score <= num)
                    {
                        Propagated = true;
                        num = n.Score;
                        BestMove = n.PlayedMove;
                    }
                }
                if (Propagated) Score = num - 0.01;
            }
        }

        // This function executes a move on a position but does not return a clean copy.
        public List<char[]> BruteDoMove(List<char[]> pos, Move m)
        {
            if (m != null)
            {
                switch (m.PlayedByAi)
                {
                    case true:
                        {
                            pos[m.coordinateY][m.coordinateX] = 'X';
                            break;
                        }
                    case false:
                        {
                            pos[m.coordinateY][m.coordinateX] = 'O';
                            break;
                        }
                }
            }
            return pos;
        }

        // Executes a move on a position and returns a clean copy
        public List<char[]> DoMoveWithCleanCopy(List<char[]> pos, Move? m)
        {

            if (m != DefaultMove)
            {
                List<List<char>> output = new List<List<char>> { };
                foreach (char[] ca in pos)
                {
                    List<char> lc = new List<char> { };
                    foreach (char c in ca)
                    {
                        lc.Add(c);
                    }
                    output.Add(lc);
                }


                switch (m.PlayedByAi)
                {
                    case true:
                        {
                            output[m.coordinateY][m.coordinateX] = 'X';
                            break;
                        }
                    case false:
                        {
                            output[m.coordinateY][m.coordinateX] = 'O';
                            break;
                        }
                }

                List<char[]> save = new List<char[]> { };
                foreach (List<char> lc in output)
                {
                    char[] ca = new char[lc.Count()];
                    for (int i = 0; i < lc.Count(); i++)
                    {
                        ca[i] = lc[i];
                    }

                    save.Add(ca);
                }

                return save;
            }
            return pos;
        }

    }

    private static Move DefaultMove = new Move(false, 0, 99);

    public static Move GetBestMove(List<char[]> position)
    {
        Node TreeOfMoves = new Node(position, true, DefaultMove, 0);
        return TreeOfMoves.BestMove;
    }
}



