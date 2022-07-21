namespace Classes;

public class Game
{
    public static List<List<char>> Board = new List<List<char>> {
        new List<char> {'5','3','4','8','9','4','3','5'},
        new List<char> {'1','1','1','1','1','1','1','1'},
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},
        new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},
        new List<char> {'P','P','P','P','P','P','P','P'},
        new List<char> {'R','N','B','Q','K','B','N','R'}
    };



    public static Point WhiteKingCoords;
    public static Point WhiteQueenCoords;

    public static List<Point> WhiteRooksCoords = new List<Point> { };
    public static List<Point> WhiteKnightsCoords = new List<Point> { };
    public static List<Point> WhiteBishopsCoords = new List<Point> { };
    public static List<Point> WhitePawnsCoords = new List<Point> { };


    public static Point BlackKingCoords;
    public static Point BlackQueenCoords;

    public static List<Point> BlackRooksCoords = new List<Point> { };
    public static List<Point> BlackKnightsCoords = new List<Point> { };
    public static List<Point> BlackBishopsCoords = new List<Point> { };
    public static List<Point> BlackPawnsCoords = new List<Point> { };


    public static bool IsInCheck(bool white, List<char>[] Position)
    {
        if (white)
        {
            // knight check 
            try { if (Position[WhiteKingCoords.y - 1][WhiteKingCoords.x - 2] == '3') return true; } catch { };
            try { if (Position[WhiteKingCoords.y - 2][WhiteKingCoords.x - 1] == '3') return true; } catch { };
            try { if (Position[WhiteKingCoords.y - 1][WhiteKingCoords.x + 2] == '3') return true; } catch { };
            try { if (Position[WhiteKingCoords.y - 2][WhiteKingCoords.x + 1] == '3') return true; } catch { };

            try { if (Position[WhiteKingCoords.y + 1][WhiteKingCoords.x - 2] == '3') return true; } catch { };
            try { if (Position[WhiteKingCoords.y + 2][WhiteKingCoords.x - 1] == '3') return true; } catch { };
            try { if (Position[WhiteKingCoords.y + 2][WhiteKingCoords.x + 1] == '3') return true; } catch { };
            try { if (Position[WhiteKingCoords.y + 1][WhiteKingCoords.x + 2] == '3') return true; } catch { };

            // rook/queen check

            for (int i = WhiteKingCoords.y - 1; i >= 0; i--)
            {
                if (Position[i][WhiteKingCoords.x] == '8' || Position[i][WhiteKingCoords.x] == '5') return true;
                else if (Position[i][WhiteKingCoords.x] != ' ') break;
            }
            for (int i = WhiteKingCoords.y + 1; i <= 7; i++)
            {
                if (Position[i][WhiteKingCoords.x] == '8' || Position[i][WhiteKingCoords.x] == '5') return true;
                else if (Position[i][WhiteKingCoords.x] != ' ') break;
            }

            for (int i = WhiteKingCoords.x + 1; i <= 7; i++)
            {
                if (Position[WhiteKingCoords.y][i] == '8' || Position[WhiteKingCoords.y][i] == '5') return true;
                else if (Position[WhiteKingCoords.y][i] != ' ') break;
            }
            for (int i = WhiteKingCoords.x - 1; i >= 0; i--)
            {
                if (Position[WhiteKingCoords.y][i] == '8' || Position[WhiteKingCoords.y][i] == '5') return true;
                else if (Position[WhiteKingCoords.y][i] != ' ') break;
            }


            // bishop/pawn/queen check
            for (int i = 1; i <= 7; i++)
            {
                try
                {
                    if (Position[WhiteKingCoords.y + i][WhiteKingCoords.x + i] == '8' || Position[WhiteKingCoords.y + i][WhiteKingCoords.x + i] == '4') return true;
                    else if (Position[WhiteKingCoords.y + i][WhiteKingCoords.x + i] != ' ') break;
                }
                catch (IndexOutOfRangeException) { break; }
            }
            for (int i = 1; i <= 7; i++)
            {
                try
                {
                    if (i == 1 && Position[WhiteKingCoords.y - i][WhiteKingCoords.x - i] == '1') return true;
                    else if (Position[WhiteKingCoords.y - i][WhiteKingCoords.x - i] == '8' || Position[WhiteKingCoords.y - i][WhiteKingCoords.x - i] == '4') return true;
                    else if (Position[WhiteKingCoords.y - i][WhiteKingCoords.x - i] != ' ') break;
                }
                catch (IndexOutOfRangeException) { break; }
            }

            for (int i = 1; i <= 7; i++)
            {
                try
                {
                    if (i == 1 && Position[WhiteKingCoords.y - i][WhiteKingCoords.x + i] == '1') return true;
                    else if (Position[WhiteKingCoords.y - i][WhiteKingCoords.x + i] == '8' || Position[WhiteKingCoords.y - i][WhiteKingCoords.x + i] == '4') return true;
                    else if (Position[WhiteKingCoords.y - i][WhiteKingCoords.x + i] != ' ') break;
                }
                catch (IndexOutOfRangeException) { break; }
            }
            for (int i = 1; i <= 7; i++)
            {
                try
                {
                    if (Position[WhiteKingCoords.y + i][WhiteKingCoords.x - i] == '8' || Position[WhiteKingCoords.y + i][WhiteKingCoords.x - i] == '4') return true;
                    else if (Position[WhiteKingCoords.y + i][WhiteKingCoords.x - i] != ' ') break;
                }
                catch (IndexOutOfRangeException) { break; }
            }

            return false;
        }
        else
        {
            // knight check 
            try { if (Position[BlackKingCoords.y - 1][BlackKingCoords.x - 2] == 'N') return true; } catch { };
            try { if (Position[BlackKingCoords.y - 2][BlackKingCoords.x - 1] == 'N') return true; } catch { };
            try { if (Position[BlackKingCoords.y - 1][BlackKingCoords.x + 2] == 'N') return true; } catch { };
            try { if (Position[BlackKingCoords.y - 2][BlackKingCoords.x + 1] == 'N') return true; } catch { };

            try { if (Position[BlackKingCoords.y + 1][BlackKingCoords.x - 2] == 'N') return true; } catch { };
            try { if (Position[BlackKingCoords.y + 2][BlackKingCoords.x - 1] == 'N') return true; } catch { };
            try { if (Position[BlackKingCoords.y + 2][BlackKingCoords.x + 1] == 'N') return true; } catch { };
            try { if (Position[BlackKingCoords.y + 1][BlackKingCoords.x + 2] == 'N') return true; } catch { };

            // rook/queen check
            for (int i = BlackKingCoords.y - 1; i >= 0; i--)
            {
                if (Position[i][BlackKingCoords.x] == 'Q' || Position[i][BlackKingCoords.x] == 'R') return true;
                else if (Position[i][BlackKingCoords.x] != ' ') break;
            }
            for (int i = BlackKingCoords.y + 1; i <= 7; i++)
            {
                if (Position[i][BlackKingCoords.x] == 'Q' || Position[i][BlackKingCoords.x] == 'R') return true;
                else if (Position[i][BlackKingCoords.x] != ' ') break;
            }

            for (int i = BlackKingCoords.x + 1; i <= 7; i++)
            {
                if (Position[BlackKingCoords.y][i] == 'Q' || Position[BlackKingCoords.y][i] == 'R') return true;
                else if (Position[BlackKingCoords.y][i] != ' ') break;
            }
            for (int i = BlackKingCoords.x - 1; i >= 0; i--)
            {
                if (Position[BlackKingCoords.y][i] == 'Q' || Position[BlackKingCoords.y][i] == 'R') return true;
                else if (Position[BlackKingCoords.y][i] != ' ') break;
            }


            // bishop/pawn/queen check
            for (int i = 1; i <= 7; i++)
            {
                try
                {
                    if (Position[BlackKingCoords.y + i][BlackKingCoords.x + i] == 'Q' || Position[BlackKingCoords.y + i][BlackKingCoords.x + i] == 'B') return true;
                    else if (Position[BlackKingCoords.y + i][BlackKingCoords.x + i] != ' ') break;
                }
                catch (IndexOutOfRangeException) { break; }
            }
            for (int i = 1; i <= 7; i++)
            {
                try
                {
                    if (i == 1 && Position[BlackKingCoords.y - i][BlackKingCoords.x - i] == '1') return true;
                    else if (Position[BlackKingCoords.y - i][BlackKingCoords.x - i] == 'Q' || Position[BlackKingCoords.y - i][BlackKingCoords.x - i] == 'B') return true;
                    else if (Position[BlackKingCoords.y - i][BlackKingCoords.x - i] != ' ') break;
                }
                catch (IndexOutOfRangeException) { break; }
            }

            for (int i = 1; i <= 7; i++)
            {
                try
                {
                    if (i == 1 && Position[BlackKingCoords.y - i][BlackKingCoords.x + i] == '1') return true;
                    else if (Position[BlackKingCoords.y - i][BlackKingCoords.x + i] == 'Q' || Position[BlackKingCoords.y - i][BlackKingCoords.x + i] == 'B') return true;
                    else if (Position[BlackKingCoords.y - i][BlackKingCoords.x + i] != ' ') break;
                }
                catch (IndexOutOfRangeException) { break; }
            }
            for (int i = 1; i <= 7; i++)
            {
                try
                {
                    if (Position[BlackKingCoords.y + i][BlackKingCoords.x - i] == 'Q' || Position[BlackKingCoords.y + i][BlackKingCoords.x - i] == 'B') return true;
                    else if (Position[BlackKingCoords.y + i][BlackKingCoords.x - i] != ' ') break;
                }
                catch (IndexOutOfRangeException) { break; }
            }

            return false;
        }
        return false;
    }

    public static List<Move> GetLegalMoves(bool White, List<List<char>> board = null)
    {
        if (board == null) board = Game.Board;
        List<Move> output = new List<Move> { };
        if (White)
        {
            CheckHorizontalAndVertical(WhiteRooksCoords[0], 'R');
            CheckHorizontalAndVertical(WhiteRooksCoords[1], 'R');
            CheckHorizontalAndVertical(WhiteQueenCoords, 'Q');
            CheckDiagonal(WhiteQueenCoords, 'Q');
            CheckDiagonal(WhiteBishopsCoords[1], 'B');
            CheckDiagonal(WhiteBishopsCoords[0], 'B');
            CheckWhiteKnights();
            CheckWhiteKing();
            CheckWhitePawns();
        }
        return output;

        void CheckDiagonal(Point? location, char skin)
        {
            if (board[location.y][location.x] == skin)
            {
                for (int i = 1; i <= 7; i++)
                {
                    try
                    {
                        if (board[location.y + i][location.x + i] == ' ') output.Add(new Move(location, new Point(location.y + i, location.x + i)));
                        else if (board[location.y + i][location.x + i] != ' ')
                        {
                            if (board[location.y + i][location.x + i] == 'K' || board[location.y + i][location.x + i] == 'Q' || board[location.y + i][location.x + i] == 'R' || board[location.y + i][location.x + i] == 'N' || board[location.y + i][location.x + i] == 'B' || board[location.y + i][location.x + i] == 'P')
                                break;
                            else
                            {
                                output.Add(new Move(location, new Point(location.y + i, location.x + i)));
                                break;
                            }
                        }
                    }
                    catch (ArgumentOutOfRangeException) { break; }
                }
                for (int i = 1; i <= 7; i++)
                {
                    try
                    {
                        if (board[location.y - i][location.x - i] == ' ') output.Add(new Move(location, new Point(location.y - i, location.x - i)));
                        else if (board[location.y - i][location.x - i] != ' ')
                        {
                            if (board[location.y - i][location.x - i] == 'K' || board[location.y - i][location.x - i] == 'Q' || board[location.y - i][location.x - i] == 'R' || board[location.y - i][location.x - i] == 'N' || board[location.y - i][location.x - i] == 'B' || board[location.y - i][location.x - i] == 'P')
                                break;
                            else
                            {
                                output.Add(new Move(location, new Point(location.y - i, location.x - i)));
                                break;
                            }
                        }
                    }
                    catch (ArgumentOutOfRangeException) { break; }
                }
                for (int i = 1; i <= 7; i++)
                {
                    try
                    {
                        if (board[location.y - i][location.x + i] == ' ') output.Add(new Move(location, new Point(location.y - i, location.x + i)));
                        else if (board[location.y - i][location.x + i] != ' ')
                        {
                            if (board[location.y - i][location.x + i] == 'K' || board[location.y - i][location.x + i] == 'Q' || board[location.y - i][location.x + i] == 'R' || board[location.y - i][location.x + i] == 'N' || board[location.y - i][location.x + i] == 'B' || board[location.y - i][location.x + i] == 'P')
                                break;
                            else
                            {
                                output.Add(new Move(location, new Point(location.y - i, location.x + i)));
                                break;
                            }
                        }
                    }
                    catch (ArgumentOutOfRangeException) { break; }
                }
                for (int i = 1; i <= 7; i++)
                {
                    try
                    {
                        if (board[location.y + i][location.x - i] == ' ') output.Add(new Move(location, new Point(location.y + i, location.x - i)));
                        else if (board[location.y + i][location.x - i] != ' ')
                        {
                            if (board[location.y + i][location.x - i] == 'K' || board[location.y + i][location.x - i] == 'Q' || board[location.y + i][location.x - i] == 'R' || board[location.y + i][location.x - i] == 'N' || board[location.y + i][location.x - i] == 'B' || board[location.y + i][location.x - i] == 'P')
                                break;
                            else
                            {
                                output.Add(new Move(location, new Point(location.y + i, location.x - i)));
                                break;
                            }
                        }
                    }
                    catch (ArgumentOutOfRangeException) { break; }
                }
            }
        }

        void CheckHorizontalAndVertical(Point? location, char skin)
        {

            if (board[location.y][location.x] == skin)
            {
                for (int i = location.y - 1; i >= 0; i--)
                {
                    if (board[i][location.x] == ' ') output.Add(new Move(location, new Point(i, location.x)));
                    else if (board[i][location.x] != ' ')
                    {
                        if (board[i][location.x] == 'K' || board[i][location.x] == 'Q' || board[i][location.x] == 'R' || board[i][location.x] == 'N' || board[i][location.x] == 'B' || board[i][location.x] == 'P')
                            break;
                        else
                        {
                            output.Add(new Move(location, new Point(i, location.x)));
                            break;
                        }
                    }
                }
                for (int i = location.y + 1; i <= 7; i++)
                {
                    if (board[i][location.x] == ' ') output.Add(new Move(location, new Point(i, location.x)));
                    else if (board[i][location.x] != ' ')
                    {
                        if (board[i][location.x] == 'K' || board[i][location.x] == 'Q' || board[i][location.x] == 'R' || board[i][location.x] == 'N' || board[i][location.x] == 'B' || board[i][location.x] == 'P')
                            break;
                        else
                        {
                            output.Add(new Move(location, new Point(i, location.x)));
                            break;
                        }
                    }
                }
                for (int i = location.x + 1; i <= 7; i++)
                {
                    if (board[location.y][i] == ' ') output.Add(new Move(location, new Point(i, i)));
                    else if (board[location.y][i] != ' ')
                    {
                        if (board[location.y][i] == 'K' || board[location.y][i] == 'Q' || board[location.y][i] == 'R' || board[location.y][i] == 'N' || board[location.y][i] == 'B' || board[location.y][i] == 'P')
                            break;
                        else
                        {
                            output.Add(new Move(location, new Point(i, i)));
                            break;
                        }
                    }
                }
                for (int i = location.x - 1; i >= 0; i--)
                {
                    if (board[location.y][i] == ' ') output.Add(new Move(location, new Point(i, location.x)));
                    else if (board[location.y][i] != ' ')
                    {
                        if (board[location.y][i] == 'K' || board[location.y][i] == 'Q' || board[location.y][i] == 'R' || board[location.y][i] == 'N' || board[location.y][i] == 'B' || board[location.y][i] == 'P')
                            break;
                        else
                        {
                            output.Add(new Move(location, new Point(i, location.x)));
                            break;
                        }
                    }
                }

            }
        }

        void CheckWhiteKnights()
        {

            for (int i = 0; i < WhiteKnightsCoords.Count(); i++)
            {
                if (board[WhiteKnightsCoords[i].y][WhiteKnightsCoords[i].x] == 'N')
                {
                    try { if (board[WhiteKnightsCoords[i].y - 1][WhiteKnightsCoords[i].x - 2] != 'K' && board[WhiteKnightsCoords[i].y - 1][WhiteKnightsCoords[i].x - 2] != 'Q' && board[WhiteKnightsCoords[i].y - 1][WhiteKnightsCoords[i].x - 2] != 'B' && board[WhiteKnightsCoords[i].y - 1][WhiteKnightsCoords[i].x - 2] != 'R' && board[WhiteKnightsCoords[i].y - 1][WhiteKnightsCoords[i].x - 2] != 'N' && board[WhiteKnightsCoords[i].y - 1][WhiteKnightsCoords[i].x - 2] != 'P') output.Add(new Move(WhiteKnightsCoords[i], new Point(WhiteKnightsCoords[i].y - 1, WhiteKnightsCoords[i].x - 2))); } catch { };
                    try { if (board[WhiteKnightsCoords[i].y - 2][WhiteKnightsCoords[i].x - 1] != 'K' && board[WhiteKnightsCoords[i].y - 2][WhiteKnightsCoords[i].x - 1] != 'Q' && board[WhiteKnightsCoords[i].y - 2][WhiteKnightsCoords[i].x - 1] != 'B' && board[WhiteKnightsCoords[i].y - 2][WhiteKnightsCoords[i].x - 1] != 'R' && board[WhiteKnightsCoords[i].y - 2][WhiteKnightsCoords[i].x - 1] != 'N' && board[WhiteKnightsCoords[i].y - 2][WhiteKnightsCoords[i].x - 1] != 'P') output.Add(new Move(WhiteKnightsCoords[i], new Point(WhiteKnightsCoords[i].y - 2, WhiteKnightsCoords[i].x - 1))); } catch { };
                    try { if (board[WhiteKnightsCoords[i].y - 1][WhiteKnightsCoords[i].x + 2] != 'K' && board[WhiteKnightsCoords[i].y - 1][WhiteKnightsCoords[i].x + 2] != 'Q' && board[WhiteKnightsCoords[i].y - 1][WhiteKnightsCoords[i].x + 2] != 'B' && board[WhiteKnightsCoords[i].y - 1][WhiteKnightsCoords[i].x + 2] != 'R' && board[WhiteKnightsCoords[i].y - 1][WhiteKnightsCoords[i].x + 2] != 'N' && board[WhiteKnightsCoords[i].y - 1][WhiteKnightsCoords[i].x + 2] != 'P') output.Add(new Move(WhiteKnightsCoords[i], new Point(WhiteKnightsCoords[i].y - 1, WhiteKnightsCoords[i].x + 2))); } catch { };
                    try { if (board[WhiteKnightsCoords[i].y - 2][WhiteKnightsCoords[i].x + 1] != 'K' && board[WhiteKnightsCoords[i].y - 2][WhiteKnightsCoords[i].x + 1] != 'Q' && board[WhiteKnightsCoords[i].y - 2][WhiteKnightsCoords[i].x + 1] != 'B' && board[WhiteKnightsCoords[i].y - 2][WhiteKnightsCoords[i].x + 1] != 'R' && board[WhiteKnightsCoords[i].y - 2][WhiteKnightsCoords[i].x + 1] != 'N' && board[WhiteKnightsCoords[i].y - 2][WhiteKnightsCoords[i].x + 1] != 'P') output.Add(new Move(WhiteKnightsCoords[i], new Point(WhiteKnightsCoords[i].y - 2, WhiteKnightsCoords[i].x + 1))); } catch { };
                    try { if (board[WhiteKnightsCoords[i].y + 1][WhiteKnightsCoords[i].x - 2] != 'K' && board[WhiteKnightsCoords[i].y + 1][WhiteKnightsCoords[i].x - 2] != 'Q' && board[WhiteKnightsCoords[i].y + 1][WhiteKnightsCoords[i].x - 2] != 'B' && board[WhiteKnightsCoords[i].y + 1][WhiteKnightsCoords[i].x - 2] != 'R' && board[WhiteKnightsCoords[i].y + 1][WhiteKnightsCoords[i].x - 2] != 'N' && board[WhiteKnightsCoords[i].y + 1][WhiteKnightsCoords[i].x - 2] != 'P') output.Add(new Move(WhiteKnightsCoords[i], new Point(WhiteKnightsCoords[i].y + 1, WhiteKnightsCoords[i].x - 2))); } catch { };
                    try { if (board[WhiteKnightsCoords[i].y + 2][WhiteKnightsCoords[i].x - 1] != 'K' && board[WhiteKnightsCoords[i].y + 2][WhiteKnightsCoords[i].x - 1] != 'Q' && board[WhiteKnightsCoords[i].y + 2][WhiteKnightsCoords[i].x - 1] != 'B' && board[WhiteKnightsCoords[i].y + 2][WhiteKnightsCoords[i].x - 1] != 'R' && board[WhiteKnightsCoords[i].y + 2][WhiteKnightsCoords[i].x - 1] != 'N' && board[WhiteKnightsCoords[i].y + 2][WhiteKnightsCoords[i].x - 1] != 'P') output.Add(new Move(WhiteKnightsCoords[i], new Point(WhiteKnightsCoords[i].y + 2, WhiteKnightsCoords[i].x - 1))); } catch { };
                    try { if (board[WhiteKnightsCoords[i].y + 2][WhiteKnightsCoords[i].x + 1] != 'K' && board[WhiteKnightsCoords[i].y + 2][WhiteKnightsCoords[i].x + 1] != 'Q' && board[WhiteKnightsCoords[i].y + 2][WhiteKnightsCoords[i].x + 1] != 'B' && board[WhiteKnightsCoords[i].y + 2][WhiteKnightsCoords[i].x + 1] != 'R' && board[WhiteKnightsCoords[i].y + 2][WhiteKnightsCoords[i].x + 1] != 'N' && board[WhiteKnightsCoords[i].y + 2][WhiteKnightsCoords[i].x + 1] != 'P') output.Add(new Move(WhiteKnightsCoords[i], new Point(WhiteKnightsCoords[i].y + 2, WhiteKnightsCoords[i].x + 1))); } catch { };
                    try { if (board[WhiteKnightsCoords[i].y + 1][WhiteKnightsCoords[i].x + 2] != 'K' && board[WhiteKnightsCoords[i].y + 1][WhiteKnightsCoords[i].x + 2] != 'Q' && board[WhiteKnightsCoords[i].y + 1][WhiteKnightsCoords[i].x + 2] != 'B' && board[WhiteKnightsCoords[i].y + 1][WhiteKnightsCoords[i].x + 2] != 'R' && board[WhiteKnightsCoords[i].y + 1][WhiteKnightsCoords[i].x + 2] != 'N' && board[WhiteKnightsCoords[i].y + 1][WhiteKnightsCoords[i].x + 2] != 'P') output.Add(new Move(WhiteKnightsCoords[i], new Point(WhiteKnightsCoords[i].y + 1, WhiteKnightsCoords[i].x + 2))); } catch { };
                }
            }

        }

        void CheckWhiteKing()
        {
            if (board[WhiteKingCoords.y][WhiteKingCoords.x] == 'K')
            {
                try { if (board[WhiteKingCoords.y - 1][WhiteKingCoords.x - 1] != 'K' && board[WhiteKingCoords.y - 1][WhiteKingCoords.x - 1] != 'Q' && board[WhiteKingCoords.y - 1][WhiteKingCoords.x - 1] != 'B' && board[WhiteKingCoords.y - 1][WhiteKingCoords.x - 1] != 'R' && board[WhiteKingCoords.y - 1][WhiteKingCoords.x - 1] != 'N' && board[WhiteKingCoords.y - 1][WhiteKingCoords.x - 1] != 'P') output.Add(new Move(WhiteKingCoords, new Point(WhiteKingCoords.y - 1, WhiteKingCoords.x - 1))); } catch { };
                try { if (board[WhiteKingCoords.y - 1][WhiteKingCoords.x] != 'K' && board[WhiteKingCoords.y - 1][WhiteKingCoords.x] != 'Q' && board[WhiteKingCoords.y - 1][WhiteKingCoords.x] != 'B' && board[WhiteKingCoords.y - 1][WhiteKingCoords.x] != 'R' && board[WhiteKingCoords.y - 1][WhiteKingCoords.x] != 'N' && board[WhiteKingCoords.y - 1][WhiteKingCoords.x] != 'P') output.Add(new Move(WhiteKingCoords, new Point(WhiteKingCoords.y - 1, WhiteKingCoords.x))); } catch { };
                try { if (board[WhiteKingCoords.y - 1][WhiteKingCoords.x + 1] != 'K' && board[WhiteKingCoords.y - 1][WhiteKingCoords.x + 1] != 'Q' && board[WhiteKingCoords.y - 1][WhiteKingCoords.x + 1] != 'B' && board[WhiteKingCoords.y - 1][WhiteKingCoords.x + 1] != 'R' && board[WhiteKingCoords.y - 1][WhiteKingCoords.x + 1] != 'N' && board[WhiteKingCoords.y - 1][WhiteKingCoords.x + 1] != 'P') output.Add(new Move(WhiteKingCoords, new Point(WhiteKingCoords.y - 1, WhiteKingCoords.x + 1))); } catch { };
                try { if (board[WhiteKingCoords.y][WhiteKingCoords.x + 1] != 'K' && board[WhiteKingCoords.y][WhiteKingCoords.x + 1] != 'Q' && board[WhiteKingCoords.y][WhiteKingCoords.x + 1] != 'B' && board[WhiteKingCoords.y][WhiteKingCoords.x + 1] != 'R' && board[WhiteKingCoords.y][WhiteKingCoords.x + 1] != 'N' && board[WhiteKingCoords.y][WhiteKingCoords.x + 1] != 'P') output.Add(new Move(WhiteKingCoords, new Point(WhiteKingCoords.y, WhiteKingCoords.x + 1))); } catch { };
                try { if (board[WhiteKingCoords.y + 1][WhiteKingCoords.x + 1] != 'K' && board[WhiteKingCoords.y + 1][WhiteKingCoords.x + 1] != 'Q' && board[WhiteKingCoords.y + 1][WhiteKingCoords.x + 1] != 'B' && board[WhiteKingCoords.y + 1][WhiteKingCoords.x + 1] != 'R' && board[WhiteKingCoords.y + 1][WhiteKingCoords.x + 1] != 'N' && board[WhiteKingCoords.y + 1][WhiteKingCoords.x + 1] != 'P') output.Add(new Move(WhiteKingCoords, new Point(WhiteKingCoords.y + 1, WhiteKingCoords.x + 1))); } catch { };
                try { if (board[WhiteKingCoords.y + 1][WhiteKingCoords.x] != 'K' && board[WhiteKingCoords.y + 1][WhiteKingCoords.x] != 'Q' && board[WhiteKingCoords.y + 1][WhiteKingCoords.x] != 'B' && board[WhiteKingCoords.y + 1][WhiteKingCoords.x] != 'R' && board[WhiteKingCoords.y + 1][WhiteKingCoords.x] != 'N' && board[WhiteKingCoords.y + 1][WhiteKingCoords.x] != 'P') output.Add(new Move(WhiteKingCoords, new Point(WhiteKingCoords.y + 1, WhiteKingCoords.x))); } catch { };
                try { if (board[WhiteKingCoords.y + 1][WhiteKingCoords.x - 1] != 'K' && board[WhiteKingCoords.y + 1][WhiteKingCoords.x - 1] != 'Q' && board[WhiteKingCoords.y + 1][WhiteKingCoords.x - 1] != 'B' && board[WhiteKingCoords.y + 1][WhiteKingCoords.x - 1] != 'R' && board[WhiteKingCoords.y + 1][WhiteKingCoords.x - 1] != 'N' && board[WhiteKingCoords.y + 1][WhiteKingCoords.x - 1] != 'P') output.Add(new Move(WhiteKingCoords, new Point(WhiteKingCoords.y + 1, WhiteKingCoords.x - 1))); } catch { };
                try { if (board[WhiteKingCoords.y][WhiteKingCoords.x - 1] != 'K' && board[WhiteKingCoords.y][WhiteKingCoords.x - 1] != 'Q' && board[WhiteKingCoords.y][WhiteKingCoords.x - 1] != 'B' && board[WhiteKingCoords.y][WhiteKingCoords.x - 1] != 'R' && board[WhiteKingCoords.y][WhiteKingCoords.x - 1] != 'N' && board[WhiteKingCoords.y][WhiteKingCoords.x - 1] != 'P') output.Add(new Move(WhiteKingCoords, new Point(WhiteKingCoords.y, WhiteKingCoords.x - 1))); } catch { };
            }
        }

        void CheckWhitePawns()
        {
            foreach (Point p in WhitePawnsCoords)
            {
                if (board[p.y][p.x] == 'P')
                {
                    if (p.y == 6)
                    {
                        for (int i = 1; i <= 2; i++)
                            if (board[p.y - i][p.x] == ' ') output.Add(new Move(p, new Point(p.y - i, p.x)));
                            else break;
                    }
                    else if (board[p.y - 1][p.x] == ' ') output.Add(new Move(p, new Point(p.y - 1, p.x)));
                    try
                    {
                        if (board[p.y - 1][p.x - 1] != ' ')
                        {
                            if ( !(board[p.y - 1][p.x - 1] == 'K' || board[p.y - 1][p.x - 1] == 'Q' || board[p.y - 1][p.x - 1] == 'R' || board[p.y - 1][p.x - 1] == 'N' || board[p.y - 1][p.x - 1] == 'B' || board[p.y - 1][p.x - 1] == 'P'))                   
                                output.Add(new Move(p, new Point(p.y - 1, p.x - 1)));
                            
                        }
                    }
                    catch (ArgumentOutOfRangeException) {  }
                    try
                    {
                        if (board[p.y - 1][p.x + 1] != ' ')
                        {
                            if (!(board[p.y - 1][p.x + 1] == 'K' || board[p.y - 1][p.x + 1] == 'Q' || board[p.y - 1][p.x + 1] == 'R' || board[p.y - 1][p.x + 1] == 'N' || board[p.y - 1][p.x + 1] == 'B' || board[p.y - 1][p.x + 1] == 'P'))                            
                                output.Add(new Move(p, new Point(p.y - 1, p.x + 1)));
                        }
                    }
                    catch (ArgumentOutOfRangeException) {  }
                }
                if (board[p.y][p.x] == 'Q')
                {
                    CheckDiagonal(p, 'Q');
                    CheckHorizontalAndVertical(p, 'Q');
                }
                else if (board[p.y][p.x] == 'K')
                {

                }

            }
        }
    }

    public Game()
    {
        for (int y = 0; y < Board.Count(); y++)
            for (int x = 0; x < Board[y].Count(); x++)
            {
                if (Board[y][x] == 'K') WhiteKingCoords = new Point(y, x);
                else if (Board[y][x] == '9') BlackKingCoords = new Point(y, x);
                else if (Board[y][x] == 'Q') WhiteQueenCoords = new Point(y, x);
                else if (Board[y][x] == '8') BlackQueenCoords = new Point(y, x);
                else if (Board[y][x] == 'R') WhiteRooksCoords.Add(new Point(y, x));
                else if (Board[y][x] == '5') BlackRooksCoords.Add(new Point(y, x));
                else if (Board[y][x] == 'N') WhiteKnightsCoords.Add(new Point(y, x));
                else if (Board[y][x] == '3') BlackKnightsCoords.Add(new Point(y, x));
                else if (Board[y][x] == 'B') WhiteBishopsCoords.Add(new Point(y, x));
                else if (Board[y][x] == '4') BlackBishopsCoords.Add(new Point(y, x));
                else if (Board[y][x] == 'P') WhitePawnsCoords.Add(new Point(y, x));
                else if (Board[y][x] == '1') BlackPawnsCoords.Add(new Point(y, x));
            }
    }
}

public record Point(int y, int x);




public class Move
{

    Point From;
    Point To;
    char Piece;

    public Move(Point from, Point to, List<List<char>> board = null)
    {
        if (board == null) board = Game.Board;
        From = from;
        To = to;
        Piece = board[From.y][From.x];
    }
}


