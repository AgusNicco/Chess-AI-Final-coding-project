namespace Classes;

public class Point
{
    public int coordinateY;
    public int coordinateX;

    public virtual bool Validate()
    {
        if (coordinateX < 3 && coordinateX >= 0 && coordinateY < 3 && coordinateY >=0)
            return true;
        else return false;
    }
}