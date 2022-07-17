namespace Classes;

public class Game
{
    public static char[][] Board = new char[3][] {
        new char [] {' ',' ',' '},
        new char [] {' ',' ',' '},
        new char [] {' ',' ',' '}
    };

    public static bool IsAiTurn = true;

    public static bool ContinueGame = true;

    public static bool IsMoveLegal(Move m)
    {
        if (m.PlayedByAi == IsAiTurn && Board[m.coordinateY][m.coordinateX] == ' ')
            return true;
        else return false;
    }

    public static bool IsBoardFull()
    {
        for (int y = 0; y < Board.Length; y++)
        {
            for (int x = 0; x < Board[y].Length; x++)
                if (Board[y][x] == ' ') return false;
        }
        return true;
    }

    public static Move TranslateMove(string s)
    {
        int[] position = TranslateCoord(int.Parse(s));
        // switch (s[1])
        // {
        //     case 'X':
        //         return new Move(true, position[0], position[1], s);
        //     case 'O':
        //         return new Move(false, position[0], position[1], s);
        // }
        // return new Move(false, 0, 0);

        return new Move(false, position[0], position[1], s);
    }

    public static int[] TranslateCoord(int i)
    {
        int adjustment = 0;
        int a2 = 1;
        if (i == 6) return new int[] { 1, 2 };
        if (i == 9) return new int[] { 2, 2 };
        if (i % 3 == 0)
        {
            adjustment = i / 3;
            return new int[] { i / 3 - adjustment, 2 };
        }
        else return new int[] { i / 3 - adjustment, i % 3 - a2 };
    }

    public static void ExecuteMove(Move m)
    {
        if (IsMoveLegal(m))
        {
            switch (m.PlayedByAi)
            {
                case true:
                    {
                        Board[m.coordinateY][m.coordinateX] = 'X';
                        IsAiTurn = false;
                        break;
                    }
                case false:
                    {
                        Board[m.coordinateY][m.coordinateX] = 'O';
                        IsAiTurn = true;
                        break;
                    }
            }
        }
    }

    // works fine
    public static bool IsCheckMate()
    {
        for (int y = 0; y < Board.Count(); y++)
        {
            for (int x = 0; x < Board[y].Count(); x++)
            {
                char c = Board[y][x];
                
                
                    if (c != ' ')
                    {
                        try{ if (Board[y][x - 1] == c && Board[y][x + 1] == c) return true; } catch (IndexOutOfRangeException) { }; // horizontal check
                        try{ if (Board[y - 1][x] == c && Board[y + 1][x] == c) return true; } catch (IndexOutOfRangeException) { };// vertical check
                        try{ if (Board[y - 1][x - 1] == c && Board[y + 1][x + 1] == c || Board[y + 1][x - 1] == c && Board[y - 1][x + 1] == c) return true; } catch (IndexOutOfRangeException) { }; // diagonal check
                    }
                
            }
        }
        return false;
    }

    public static void PrintMap()
    {
        // Console.Clear();
        Console.WriteLine($"+-+-+-+");
        Console.WriteLine($"|{Board[0][0]}|{Board[0][1]}|{Board[0][2]}|");
        Console.WriteLine($"+-+-+-+");
        Console.WriteLine($"|{Board[1][0]}|{Board[1][1]}|{Board[1][2]}|");
        Console.WriteLine($"+-+-+-+");
        Console.WriteLine($"|{Board[2][0]}|{Board[2][1]}|{Board[2][2]}|");
        Console.WriteLine($"+-+-+-+");
    }

    public static List<char[]> CharArrayToList(char[][] ca)
    {
        List<char[]> output = new List<char[]> { };
        foreach (char[] x in ca)
            output.Add(x);
        return output;
    }

    public static void StartGame()
    {

        Random rnd = new Random();
        if (rnd.Next(1, 3) == 2) IsAiTurn = true;
        else IsAiTurn = false;
        
        while (ContinueGame)
        {
            if (IsAiTurn)
            {
                Console.Clear();
                Console.WriteLine("The computer will play. \n");

                PrintMap();
                Thread.Sleep(0);
                ExecuteMove(AI.GetBestMove(CharArrayToList(Board)));

                if (IsCheckMate()) EndGame(true);
                else if (IsBoardFull()) EndGame();

                IsAiTurn = false;
            }
            else if (!IsAiTurn)
            {
                Console.Clear();
                Console.WriteLine("You will play.\n");
                PrintMap();

                Console.Write("\nInput your move: ");
                string move = Console.ReadLine();
                ExecuteMove(TranslateMove(move));

                if (IsCheckMate()) EndGame(false);
                else if (IsBoardFull()) EndGame();

                IsAiTurn = true;
            }
        }

    }

    public static void EndGame(bool? AiWon = null)
    {
        if (AiWon == true)
        {
            Console.Clear();
            ContinueGame = false;
            Console.WriteLine("\n The computer won.\n");
            PrintMap();
        }
        else if (AiWon == false)
        {
            ContinueGame = false;
            Console.Clear();
            Console.WriteLine("\n You won.\n");
            PrintMap();
        }
        else
        {
            ContinueGame = false;
            Console.Clear();
            Console.WriteLine("\n It is a draw\n");
            PrintMap();
        }
    }

    public Game()
    {

    }
}


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
                if (Propagated) Score = num - 0.1;
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


