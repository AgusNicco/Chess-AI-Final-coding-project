namespace Classes;

// REQUIREMENT 3, a third class definition

// Class used to store the coordinates of a point in a two dimensional array
public class Point
{
    public int coordinateY;
    public int coordinateX;

    // Returns true if the coordinates of the point respect the dimensions of a Board of TicTacToe
    public virtual bool Validate()
    {
        if (coordinateX < 3 && coordinateX >= 0 && coordinateY < 3 && coordinateY >=0)
            return true;
        else return false;
    }
}