namespace Classes;


public interface Game
{
    public static char[][] Board = new char[][] {
        new char [] {' ',' ',' '},
        new char [] {' ',' ',' '},
        new char [] {' ',' ',' '}
    };

    public enum GameResult { Draw, AiWon, PlayerWon};

    public static bool IsAiTurn = true;

    public static bool ContinueGame = true;

    public static bool IsMoveLegal(Move m)
    {
        if (m.PlayedByAi == IsAiTurn && Board[m.coordinateY][m.coordinateX] == ' ')
            return true;
        else
            return false;
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
        return new Move(false, position[0], position[1]);
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
                    try { if (Board[y][x - 1] == c && Board[y][x + 1] == c) return true; } catch (IndexOutOfRangeException) { }; // horizontal check
                    try { if (Board[y - 1][x] == c && Board[y + 1][x] == c) return true; } catch (IndexOutOfRangeException) { };// vertical check
                    try { if (Board[y - 1][x - 1] == c && Board[y + 1][x + 1] == c || Board[y + 1][x - 1] == c && Board[y - 1][x + 1] == c) return true; } catch (IndexOutOfRangeException) { }; // diagonal check
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

    // function that runs the Game
    public static void StartGame()
    {
        // Chooses at random who will play the first move
        Random rnd = new Random();
        if (rnd.Next(1, 3) == 2) 
            IsAiTurn = true;
        else 
            IsAiTurn = false;

        Console.Clear();

        Console.WriteLine("Use the keyboard to select the level of difficulty.\n");
        Console.WriteLine("A: Easy");
        Console.WriteLine("B: Intermediate");
        Console.WriteLine("C: Hard");
        Console.WriteLine("D: Impossible");

        bool ProperInput = false;
        while (!ProperInput)
        {
            switch(Console.ReadKey(true).Key)
            {
                case ConsoleKey.A:
                {
                    AI.SwitchDifficulty(AI.Difficulty.Easy);
                    ProperInput = true;
                    break;
                }
                case ConsoleKey.B:
                {
                    AI.SwitchDifficulty(AI.Difficulty.Intermediate);
                    ProperInput = true;
                    break;
                }
                case ConsoleKey.C:
                {
                    AI.SwitchDifficulty(AI.Difficulty.Hard);
                    ProperInput = true;
                    break;
                }
                case ConsoleKey.D:
                {
                    AI.SwitchDifficulty(AI.Difficulty.Impossible);
                    ProperInput = true;
                    break;
                }
            }
        }

        
        while (ContinueGame)
        {
            if (IsAiTurn)
            {
                Console.Clear();
                Console.WriteLine("The computer will play. \n");

                PrintMap();
                Thread.Sleep(0);
                ExecuteMove(AI.GetBestMove(CharArrayToList(Board)));

                if (IsCheckMate()) EndGame(GameResult.AiWon);
                else if (IsBoardFull()) EndGame(GameResult.Draw);

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

                if (IsCheckMate()) EndGame(GameResult.PlayerWon);
                else if (IsBoardFull()) EndGame(GameResult.Draw);

                IsAiTurn = true;
            }
        }

    }

    public static void EndGame(GameResult result)
    {

        if (result == GameResult.AiWon)
        {
            Console.Clear();
            ContinueGame = false;
            Console.WriteLine("\n The computer won.\n");
            PrintMap();
        }
        else if (result == GameResult.PlayerWon)
        {
            ContinueGame = false;
            Console.Clear();
            Console.WriteLine("\n You won.\n");
            PrintMap();
        }
        else if (result == GameResult.Draw)
        {
            ContinueGame = false;
            Console.Clear();
            Console.WriteLine("\n It is a draw\n");
            PrintMap();
        }
    }
}