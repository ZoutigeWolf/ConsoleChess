namespace ConsoleChess;

public struct Vector2
{
    public int X;
    public int Y;

    public Vector2(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Vector2 other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return Tuple.Create(X, Y).GetHashCode();
    }

    public static Vector2 operator *(Vector2 v, int m)
    {
        return new Vector2(v.X * m, v.Y * m);
    }

    public static bool operator ==(Vector2 a, Vector2 b)
    {
        return a.X == b.X && a.Y == b.Y;
    }
    
    public static bool operator !=(Vector2 a, Vector2 b)
    {
        return a.X != b.X || a.Y != b.Y;
    }
}