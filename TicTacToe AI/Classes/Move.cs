namespace  Classes;


// REQUIREMENTS 2 and 6, a second class definition that inherits properties of a another class.
// This class is used to create a move on certain coordinates and contains a boolean that determines if the which player made the Move and if the Move is the first Move
public class Move : Point
{
    public bool PlayedByAi;
    public bool FirstMove;


    // EXTRA CREDIT REQUIREMENT olverloading the operators '==' and '!=' in order to be able to compare moves
    public static bool operator == (Move x, Move y) => 
            x.coordinateX == y.coordinateX && 
            x.coordinateY == y.coordinateY &&
            x.PlayedByAi == y.PlayedByAi;

    public static bool operator != (Move x, Move y) => 
            x.coordinateX != y.coordinateX || 
            x.coordinateY != y.coordinateY ||
            x.PlayedByAi != y.PlayedByAi;

    // to compare Moves to points
    public static bool operator == (Move x, Point y) => 
            x.coordinateX == y.coordinateX && 
            x.coordinateY == y.coordinateY;

    public static bool operator != (Move x, Point y) => 
            x.coordinateX != y.coordinateX || 
            x.coordinateY != y.coordinateY;
    

    // REQUIREMENT 8 polymorphism, the Validate method that was inherited from the point clas will return true if playing this move would represent a legal move
    public override bool Validate() =>
        Game.Board[coordinateY][coordinateX] == ' ' && 
        coordinateX < 3 && coordinateX >= 0 
        && coordinateY < 3 && coordinateY >=0;

    
    public Move(bool _PlayedByAi, int _coordinateY, int _coordinateX, bool _FirstMove = false)
    {
        PlayedByAi = _PlayedByAi;
        coordinateY = _coordinateY;
        coordinateX = _coordinateX;
        FirstMove = _FirstMove;
    }
}