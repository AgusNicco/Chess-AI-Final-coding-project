namespace Classes;


public class AI
{
    private static char[][] Board = Game.Board;
    private static char[][] TheoricalBoard = Board;
    public static int SearchDepth = 9;
    private static char Skin = 'X';
    private static char EnemySkin = 'O';
    public string[] PossibleMoves = new string[9] { $"1{Skin}", $"2{Skin}", $"3{Skin}", $"4{Skin}", $"5{Skin}", $"6{Skin}", $"7{Skin}", $"8{Skin}", $"9{Skin}", };
    private record PossibleMove(int coordinateY, int coordinateX, int evaluation = 0);


    // works fine
    public static double EvaluatePosition(List<char[]> Board = null, bool AiMove = true)
    {
        if (Board == null)
        {
            foreach (char[] ca in Game.Board)
                Board.Add(ca);
        }

        if (Board[0][0] == Skin && Board[0][1] == Skin && Board[0][2] == Skin) return 3; // horizontal check
        if (Board[1][0] == Skin && Board[1][1] == Skin && Board[1][2] == Skin) return 3;
        if (Board[2][0] == Skin && Board[2][1] == Skin && Board[2][2] == Skin) return 3;

        if (Board[0][0] == Skin && Board[1][0] == Skin && Board[2][0] == Skin) return 3; // vertical check
        if (Board[0][1] == Skin && Board[1][1] == Skin && Board[2][1] == Skin) return 3;
        if (Board[0][2] == Skin && Board[1][2] == Skin && Board[2][2] == Skin) return 3;

        if (Board[0][0] == Skin && Board[1][1] == Skin && Board[2][2] == Skin) return 3; // diagonal check
        if (Board[2][0] == Skin && Board[1][1] == Skin && Board[0][2] == Skin) return 3;


        if (Board[0][0] == EnemySkin && Board[0][1] == EnemySkin && Board[0][2] == EnemySkin) return -3; // horizontal check
        if (Board[1][0] == EnemySkin && Board[1][1] == EnemySkin && Board[1][2] == EnemySkin) return -3;
        if (Board[2][0] == EnemySkin && Board[2][1] == EnemySkin && Board[2][2] == EnemySkin) return -3;

        if (Board[0][0] == EnemySkin && Board[1][0] == EnemySkin && Board[2][0] == EnemySkin) return -3; // vertical check
        if (Board[0][1] == EnemySkin && Board[1][1] == EnemySkin && Board[2][1] == EnemySkin) return -3;
        if (Board[0][2] == EnemySkin && Board[1][2] == EnemySkin && Board[2][2] == EnemySkin) return -3;

        if (Board[0][0] == EnemySkin && Board[1][1] == EnemySkin && Board[2][2] == EnemySkin) return -3; // diagonal check
        if (Board[2][0] == EnemySkin && Board[1][1] == EnemySkin && Board[0][2] == EnemySkin) return -3;

        return 0;
    }

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
            }
        }
        return output;

    }

    public static List<Node> TreeOfMoves = new List<Node> { };
    public static int NumberOfNodes = 0;

    public class Node
    {
        public bool MyMove;
        public int Layer;
        public double Score;
        public readonly List<char[]> Position;
        public Move? PlayedMove;
        public Move BestMove;
        public List<Move>? MovesToReachPosition;
        public bool ShouldBranch;
        public List<Node>? BranchOfNodes;
        public bool Propagated = false;

        public Node(List<char[]> position, List<Move> movesToReachPosition = null, bool mymove = true, Move move = null, int layer = 0)
        {
            MyMove = mymove;
            PlayedMove = move;
            Layer = layer;
            NumberOfNodes++;
            if (movesToReachPosition == null) movesToReachPosition = new List<Move> { };

            MovesToReachPosition = new List<Move> { };
            foreach (Move m in movesToReachPosition)
            {
                MovesToReachPosition.Add(m);
            }
            MovesToReachPosition.Add(move);

            Position = DoMove(position, move);
         
            ShouldBranch = Layer <= AI.SearchDepth;

            // if (Layer == SearchDepth - 1)
                
            Score = AI.EvaluatePosition(Position, MyMove);
            // else Score = 0;
            

            List<Move> ListOfMoves = AI.GetPossibleMoves(Position, MyMove);

            if (ListOfMoves.Count() == 0 || Math.Abs(Score) == 3) ShouldBranch = false;

            if (ShouldBranch)
            {
                BranchOfNodes = new List<Node> { };

                foreach (Move m in ListOfMoves)
                {
                    // var NewPosition = Position.Select(ca=>ca.Select(c=>c).ToArray()).ToList();
                    BranchOfNodes.Add(new Node(Position, MovesToReachPosition, !MyMove, m, Layer + 1));
                }
            }
            else BranchOfNodes = null;

            // Backpropagation
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

        public List<char[]> DoMove(List<char[]> pos, Move m)
        {
            if (m != null)
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
                            // IsAiTurn = 2;
                            break;
                        }
                    case false:
                        {
                            output[m.coordinateY][m.coordinateX] = 'O';
                            // IsAiTurn = 1;
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

    public static Move GetBestMove(List<char[]> position)
    {
        Node node = new Node(position, null, true, null, 0);
        return node.BestMove;
    }
}


public record Move(bool PlayedByAi, int coordinateY, int coordinateX, string code = " ");


