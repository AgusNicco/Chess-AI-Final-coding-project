namespace Classes;

public class Game
{
    // public static List<List<char>> Board = new List<List<char>> {
    //     new List<char> {'R','N','B','Q','K','B','N','R'},
    //     new List<char> {'P','P','P','P','P','P','P','P'},
    //     new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},
    //     new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},   // holds the current position in the game
    //     new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},
    //     new List<char> {' ',' ',' ',' ',' ',' ',' ',' '},
    //     new List<char> {'1','1','1','1','1','1','1','1'},
    //     new List<char> {'5','3','4','8','9','4','3','5'}
    // };

public static List<List<byte>> Board = new List<List<byte>> {
        new List<byte> {55,33,44,88,99,44,33,55},
        new List<byte> {11,11,11,11,11,11,11,11},
        new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0},   // holds the current position in the game
        new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0},
        new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0},
        new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0},
        new List<byte> { 1, 1, 1, 1, 1, 1, 1, 1},
        new List<byte> { 5, 3, 4, 8, 9, 4, 3, 5}
    };


    // Coordinates of each player's pieces
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

    // checks if a given player is in check
    public static bool IsInCheck(bool white, List<List<char>> Position)
    {
        if (white)
        {
            // knight check 
            if (Position[WhiteKingCoords.y - 1][WhiteKingCoords.x - 2] == '3') return true;
            if (Position[WhiteKingCoords.y - 2][WhiteKingCoords.x - 1] == '3') return true;
            if (Position[WhiteKingCoords.y - 1][WhiteKingCoords.x + 2] == '3') return true;
            if (Position[WhiteKingCoords.y - 2][WhiteKingCoords.x + 1] == '3') return true;

            if (Position[WhiteKingCoords.y + 1][WhiteKingCoords.x - 2] == '3') return true;
            if (Position[WhiteKingCoords.y + 2][WhiteKingCoords.x - 1] == '3') return true;
            if (Position[WhiteKingCoords.y + 2][WhiteKingCoords.x + 1] == '3') return true;
            if (Position[WhiteKingCoords.y + 1][WhiteKingCoords.x + 2] == '3') return true;

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
                catch (ArgumentOutOfRangeException) { break; }
            }
            for (int i = 1; i <= 7; i++)
            {
                try
                {
                    if (i == 1 && Position[WhiteKingCoords.y - i][WhiteKingCoords.x - i] == '1') return true;
                    else if (Position[WhiteKingCoords.y - i][WhiteKingCoords.x - i] == '8' || Position[WhiteKingCoords.y - i][WhiteKingCoords.x - i] == '4') return true;
                    else if (Position[WhiteKingCoords.y - i][WhiteKingCoords.x - i] != ' ') break;
                }
                catch (ArgumentOutOfRangeException) { break; }
            }

            for (int i = 1; i <= 7; i++)
            {
                try
                {
                    if (i == 1 && Position[WhiteKingCoords.y - i][WhiteKingCoords.x + i] == '1') return true;
                    else if (Position[WhiteKingCoords.y - i][WhiteKingCoords.x + i] == '8' || Position[WhiteKingCoords.y - i][WhiteKingCoords.x + i] == '4') return true;
                    else if (Position[WhiteKingCoords.y - i][WhiteKingCoords.x + i] != ' ') break;
                }
                catch (ArgumentOutOfRangeException) { break; }
            }
            for (int i = 1; i <= 7; i++)
            {
                try
                {
                    if (Position[WhiteKingCoords.y + i][WhiteKingCoords.x - i] == '8' || Position[WhiteKingCoords.y + i][WhiteKingCoords.x - i] == '4') return true;
                    else if (Position[WhiteKingCoords.y + i][WhiteKingCoords.x - i] != ' ') break;
                }
                catch (ArgumentOutOfRangeException) { break; }
            }

            return false;
        }
        else
        {
            // knight check 
            try { if (Position[BlackKingCoords.y - 1][BlackKingCoords.x - 2] == 'N') return true; } catch(ArgumentOutOfRangeException) {}
            try { if (Position[BlackKingCoords.y - 2][BlackKingCoords.x - 1] == 'N') return true; } catch(ArgumentOutOfRangeException) {}
            try { if (Position[BlackKingCoords.y - 1][BlackKingCoords.x + 2] == 'N') return true; } catch(ArgumentOutOfRangeException) {}
            try { if (Position[BlackKingCoords.y - 2][BlackKingCoords.x + 1] == 'N') return true; } catch(ArgumentOutOfRangeException) {}

            try { if (Position[BlackKingCoords.y + 1][BlackKingCoords.x - 2] == 'N') return true; } catch(ArgumentOutOfRangeException) {}
            try { if (Position[BlackKingCoords.y + 2][BlackKingCoords.x - 1] == 'N') return true; } catch(ArgumentOutOfRangeException) {}
            try { if (Position[BlackKingCoords.y + 2][BlackKingCoords.x + 1] == 'N') return true; } catch(ArgumentOutOfRangeException) {}
            try { if (Position[BlackKingCoords.y + 1][BlackKingCoords.x + 2] == 'N') return true; } catch(ArgumentOutOfRangeException) {}

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
                catch (ArgumentOutOfRangeException) { break; }
            }
            for (int i = 1; i <= 7; i++)
            {
                try
                {
                    if (i == 1 && Position[BlackKingCoords.y - i][BlackKingCoords.x - i] == '1') return true;
                    else if (Position[BlackKingCoords.y - i][BlackKingCoords.x - i] == 'Q' || Position[BlackKingCoords.y - i][BlackKingCoords.x - i] == 'B') return true;
                    else if (Position[BlackKingCoords.y - i][BlackKingCoords.x - i] != ' ') break;
                }
                catch (ArgumentOutOfRangeException) { break; }
            }

            for (int i = 1; i <= 7; i++)
            {
                try
                {
                    if (i == 1 && Position[BlackKingCoords.y - i][BlackKingCoords.x + i] == '1') return true;
                    else if (Position[BlackKingCoords.y - i][BlackKingCoords.x + i] == 'Q' || Position[BlackKingCoords.y - i][BlackKingCoords.x + i] == 'B') return true;
                    else if (Position[BlackKingCoords.y - i][BlackKingCoords.x + i] != ' ') break;
                }
                catch (ArgumentOutOfRangeException) { break; }
            }
            for (int i = 1; i <= 7; i++)
            {
                try
                {
                    if (Position[BlackKingCoords.y + i][BlackKingCoords.x - i] == 'Q' || Position[BlackKingCoords.y + i][BlackKingCoords.x - i] == 'B') return true;
                    else if (Position[BlackKingCoords.y + i][BlackKingCoords.x - i] != ' ') break;
                }
                catch (ArgumentOutOfRangeException) { break; }
            }

            return false;
        }
        return false;
    }
    // provides a list with all the legal moves a player can make
    public static List<Move> GetLegalMoves(bool White, List<List<byte>> board = null)
    {
        if (board == null) board = Game.Board;
        List<Move> output = new List<Move> { };
        if (White)
        {
            CheckHorizontalAndVertical(WhiteRooksCoords[0], 55);
            CheckHorizontalAndVertical(WhiteRooksCoords[1], 55);
            CheckHorizontalAndVertical(WhiteQueenCoords, 88);
            CheckDiagonal(WhiteQueenCoords, 88);
            CheckDiagonal(WhiteBishopsCoords[1], 44);
            CheckDiagonal(WhiteBishopsCoords[0], 44);
            CheckWhiteKnights();
            CheckWhiteKing();
            CheckWhitePawns();
        }
        return output;
        // slow
        void CheckDiagonal(Point? location, byte skin)
        {
            if (board[location.y][location.x] == skin)
            {
                // 502.000 ticks
                for (int i = 1; i <= 7; i++)
                {
                    if (location.y + i > 7 || location.y + i < 0 || location.x + i > 7 || location.x + i < 0) break;
                    if (board[location.y + i][location.x + i] == 0) output.Add(new Move(location, new Point(location.y + i, location.x + i)));
                    else if (board[location.y + i][location.x + i] != 0)
                    {
                        if (IsNotAWhitePiece(board[location.y + i][location.x + i]))
                            output.Add(new Move(location, new Point(location.y + i, location.x + i)));
                        break;  
                    }
                }
                for (int i = 1; i <= 7; i++)
                {
                    if (location.y - i > 7 || location.y - i < 0 || location.x - i > 7 || location.x - i < 0) break;
                    if (board[location.y - i][location.x - i] == 0) output.Add(new Move(location, new Point(location.y - i, location.x - i)));
                    else if (board[location.y - i][location.x - i] != 0)
                    {
                        if (IsNotAWhitePiece(board[location.y - i][location.x - i]))
                            output.Add(new Move(location, new Point(location.y - i, location.x - i)));
                        break;
                    }
                }
                for (int i = 1; i <= 7; i++)
                {
                    if (location.y - i > 7 || location.y - i < 0 || location.x + i > 7 || location.x + i < 0) break;
                    if (board[location.y - i][location.x + i] == 0) output.Add(new Move(location, new Point(location.y - i, location.x + i)));
                    else if (board[location.y - i][location.x + i] != 0)
                    {
                        if (IsNotAWhitePiece(board[location.y - i][location.x + i]))
                            output.Add(new Move(location, new Point(location.y - i, location.x + i)));
                        break;     
                    }
                }
                for (int i = 1; i <= 7; i++)
                {
                    if (location.y + i > 7 || location.y + i < 0 || location.x - i > 7 || location.x - i < 0) break;
                    if (board[location.y + i][location.x - i] == 0) output.Add(new Move(location, new Point(location.y + i, location.x - i)));
                    else if (board[location.y + i][location.x - i] != 0)
                    {
                        if (IsNotAWhitePiece(board[location.y + i][location.x - i]))
                            output.Add(new Move(location, new Point(location.y + i, location.x - i)));
                        break;
                    }
                }
            }
        }
        // fast
        void CheckHorizontalAndVertical(Point? location, byte skin)
        {

            if (board[location.y][location.x] == skin)
            {
                for (int i = location.y - 1; i >= 0; i--)
                {
                    if (board[i][location.x] == 0) output.Add(new Move(location, new Point(i, location.x)));
                    else 
                    {
                        if (IsNotAWhitePiece(board[i][location.x]))
                            output.Add(new Move(location, new Point(i, location.x)));
                        break;
                    }
                }
                for (int i = location.y + 1; i <= 7; i++) 
                {
                    if (board[i][location.x] == 0) output.Add(new Move(location, new Point(i, location.x)));
                    else 
                    {
                        if (IsNotAWhitePiece(board[i][location.x]))
                            output.Add(new Move(location, new Point(i, location.x)));
                        break;
                    }
                }
                for (int i = location.x + 1; i <= 7; i++)
                {
                    if (board[location.y][i] == 0) output.Add(new Move(location, new Point(i, i)));
                    else 
                    {
                        if (IsNotAWhitePiece(board[location.y][i]))
                            output.Add(new Move(location, new Point(location.y, i)));
                        break;
                    }
                }
                for (int i = location.x - 1; i >= 0; i--)
                {
                    if (board[location.y][i] == 0) output.Add(new Move(location, new Point(i, location.x)));
                    else 
                    {
                        if (IsNotAWhitePiece(board[location.y][i]))
                            output.Add(new Move(location, new Point(location.y, i)));
                        break;
                    }
                }
            }
        }
        
        // 951,875 ticks
        void CheckWhiteKnights() // works fine
        {
            for (int i = 0; i < WhiteKnightsCoords.Count(); i++)
            {
                if (board[WhiteKnightsCoords[i].y][WhiteKnightsCoords[i].x] == 33)
                {
                    bool Ym1 = WhiteKnightsCoords[i].y - 1 >= 0;
                    bool Ym2 = WhiteKnightsCoords[i].y - 2 >= 0;
                    bool Xm1 = WhiteKnightsCoords[i].x - 1 >= 0;
                    bool Xm2 = WhiteKnightsCoords[i].x - 2 >= 0;
                    bool Yp1 = WhiteKnightsCoords[i].y + 1 < 8;
                    bool Yp2 = WhiteKnightsCoords[i].y + 2 < 8;
                    bool Xp1 = WhiteKnightsCoords[i].x + 1 < 8;
                    bool Xp2 = WhiteKnightsCoords[i].x + 2 < 8;

                    if (Ym1 && Xm2)
                        if (IsNotAWhitePiece(board[WhiteKnightsCoords[i].y - 1][WhiteKnightsCoords[i].x - 2]))
                            output.Add(new Move(WhiteKnightsCoords[i], new Point(WhiteKnightsCoords[i].y - 1, WhiteKnightsCoords[i].x - 2)));
                    if (Ym2 && Xm1)
                        if (IsNotAWhitePiece(board[WhiteKnightsCoords[i].y - 2][WhiteKnightsCoords[i].x - 1]))
                            output.Add(new Move(WhiteKnightsCoords[i], new Point(WhiteKnightsCoords[i].y - 2, WhiteKnightsCoords[i].x - 1)));
                    if (Ym1 && Xp2)
                        if (IsNotAWhitePiece(board[WhiteKnightsCoords[i].y - 1][WhiteKnightsCoords[i].x + 2]))
                            output.Add(new Move(WhiteKnightsCoords[i], new Point(WhiteKnightsCoords[i].y - 1, WhiteKnightsCoords[i].x + 2)));
                    if (Ym2 && Xp1)
                        if (IsNotAWhitePiece(board[WhiteKnightsCoords[i].y - 2][WhiteKnightsCoords[i].x + 1]))  
                            output.Add(new Move(WhiteKnightsCoords[i], new Point(WhiteKnightsCoords[i].y - 2, WhiteKnightsCoords[i].x + 1)));
                    if (Yp1 && Xm2)
                        if (IsNotAWhitePiece(board[WhiteKnightsCoords[i].y + 1][WhiteKnightsCoords[i].x - 2]))
                            output.Add(new Move(WhiteKnightsCoords[i], new Point(WhiteKnightsCoords[i].y + 1, WhiteKnightsCoords[i].x - 2)));
                    if (Yp2 && Xm1)
                        if (IsNotAWhitePiece(board[WhiteKnightsCoords[i].y + 2][WhiteKnightsCoords[i].x - 1]))
                            output.Add(new Move(WhiteKnightsCoords[i], new Point(WhiteKnightsCoords[i].y + 2, WhiteKnightsCoords[i].x - 1)));
                    if (Yp2 && Xm1)
                        if (IsNotAWhitePiece(board[WhiteKnightsCoords[i].y + 2][WhiteKnightsCoords[i].x + 1]))
                            output.Add(new Move(WhiteKnightsCoords[i], new Point(WhiteKnightsCoords[i].y + 2, WhiteKnightsCoords[i].x + 1)));
                    if (Yp1 && Xp2)
                        if (IsNotAWhitePiece(board[WhiteKnightsCoords[i].y + 1][WhiteKnightsCoords[i].x + 2]))
                            output.Add(new Move(WhiteKnightsCoords[i], new Point(WhiteKnightsCoords[i].y + 1, WhiteKnightsCoords[i].x + 2)));
                }
            }
        }

        void CheckWhiteKing()
        {
            if (board[WhiteKingCoords.y][WhiteKingCoords.x] == 99)
            {
                // 274.041 ticks
                bool Ym1 = WhiteKingCoords.y - 1 >= 0;
                bool Yp1 = WhiteKingCoords.y + 1 < 8;
                bool Xm1 = WhiteKingCoords.x - 1 >= 0;
                bool Xp1 = WhiteKingCoords.x + 1 < 8;

                // 507.541
                if(Ym1 && Xm1)
                    if (IsNotAWhitePiece(board[WhiteKingCoords.y - 1][WhiteKingCoords.x - 1])) 
                        output.Add(new Move(WhiteKingCoords, new Point(WhiteKingCoords.y - 1, WhiteKingCoords.x - 1)));
                
                if(Ym1)
                    if (IsNotAWhitePiece(board[WhiteKingCoords.y - 1][WhiteKingCoords.x])) 
                        output.Add(new Move(WhiteKingCoords, new Point(WhiteKingCoords.y - 1, WhiteKingCoords.x)));
                
                if(Ym1 && Xp1)
                    if (IsNotAWhitePiece(board[WhiteKingCoords.y - 1][WhiteKingCoords.x + 1]))
                        output.Add(new Move(WhiteKingCoords, new Point(WhiteKingCoords.y - 1, WhiteKingCoords.x + 1)));
                
                if (Xp1)
                    if (IsNotAWhitePiece(board[WhiteKingCoords.y][WhiteKingCoords.x + 1]))
                        output.Add(new Move(WhiteKingCoords, new Point(WhiteKingCoords.y, WhiteKingCoords.x + 1)));
                
                if(Yp1 && Xp1)
                    if (IsNotAWhitePiece(board[WhiteKingCoords.y + 1][WhiteKingCoords.x + 1]))
                        output.Add(new Move(WhiteKingCoords, new Point(WhiteKingCoords.y + 1, WhiteKingCoords.x + 1)));
                
                if(Yp1)
                    if (IsNotAWhitePiece(board[WhiteKingCoords.y + 1][WhiteKingCoords.x]))
                        output.Add(new Move(WhiteKingCoords, new Point(WhiteKingCoords.y + 1, WhiteKingCoords.x)));
                
                if(Yp1 && Xm1)
                    if (IsNotAWhitePiece(board[WhiteKingCoords.y + 1][WhiteKingCoords.x - 1]))
                        output.Add(new Move(WhiteKingCoords, new Point(WhiteKingCoords.y + 1, WhiteKingCoords.x - 1)));
                if(Xm1)
                    if (IsNotAWhitePiece(board[WhiteKingCoords.y][WhiteKingCoords.x - 1]))
                        output.Add(new Move(WhiteKingCoords, new Point(WhiteKingCoords.y, WhiteKingCoords.x - 1)));
            }
        }

        void CheckWhitePawns()
        {
            foreach (Point p in WhitePawnsCoords)
            {
                if (board[p.y][p.x] == 11)
                {
                    if (p.y == 1)
                    {
                        for (int i = 1; i <= 2; i++)
                            if (board[p.y + i][p.x] == 0) output.Add(new Move(p, new Point(p.y + i, p.x)));
                            else break;
                    }
                    else if (board[p.y + 1][p.x] == 0) output.Add(new Move(p, new Point(p.y + 1, p.x)));
                    if (p.y + 1 < 8 && p.x + 1 < 8)
                        if (board[p.y + 1][p.x + 1] != 0)
                        {
                            if (IsNotAWhitePiece(board[p.y + 1][p.x + 1]))
                                output.Add(new Move(p, new Point(p.y + 1, p.x + 1)));
                        }
                    if (p.y + 1 < 8 && p.x - 1 >= 0)
                        if (board[p.y + 1][p.x - 1] != 0)
                        {
                            if (IsNotAWhitePiece(board[p.y + 1][p.x - 1]))    
                                output.Add(new Move(p, new Point(p.y + 1, p.x - 1)));
                        }
                }
                if (board[p.y][p.x] == 88)
                {
                    CheckDiagonal(p, 88);
                    CheckHorizontalAndVertical(p, 88);
                }
                else if (board[p.y][p.x] == 33)
                {

                }

            }
        }

        bool IsInRange(int x)
        {
            return (x >= 0 && x <= 7);
        }

        bool IsNotAWhitePiece (byte b)
        {
            return b < 11;
        }
    }

    public Game()
    {
        for (int y = 0; y < Board.Count(); y++)
            for (int x = 0; x < Board[y].Count(); x++)
            {
                if (Board[y][x] == 99) WhiteKingCoords = new Point(y, x);
                else if (Board[y][x] == 9) BlackKingCoords = new Point(y, x);
                else if (Board[y][x] == 88) WhiteQueenCoords = new Point(y, x);
                else if (Board[y][x] == 8) BlackQueenCoords = new Point(y, x);
                else if (Board[y][x] == 55) WhiteRooksCoords.Add(new Point(y, x));
                else if (Board[y][x] == 5) BlackRooksCoords.Add(new Point(y, x));
                else if (Board[y][x] == 33) WhiteKnightsCoords.Add(new Point(y, x));
                else if (Board[y][x] == 3) BlackKnightsCoords.Add(new Point(y, x));
                else if (Board[y][x] == 44) WhiteBishopsCoords.Add(new Point(y, x));
                else if (Board[y][x] == 4) BlackBishopsCoords.Add(new Point(y, x));
                else if (Board[y][x] == 11) WhitePawnsCoords.Add(new Point(y, x));
                else if (Board[y][x] == 1) BlackPawnsCoords.Add(new Point(y, x));
            }
    }
}

public record Point
{
    public int y;
    public int x;

    public Point(int Y, int X)
    {
        y = Y;
        x = X;
    }
}

public class Move  // used to store and execute a move
{

    Point From {get; }
    Point To  {get; }
    byte Piece;

    public Move(Point from, Point to, List<List<byte>> board = null)
    {
        if (board == null) board = Game.Board;
        From = from;
        To = to;
        Piece = board[From.y][From.x];
    }

    // for testing
    public Point GetTo()
    {
        return To;
    }

    public Point GetFrom()
    {
        return From;
    }

}


