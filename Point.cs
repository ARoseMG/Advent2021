using System;

class Point
{
    public int x,y;

    public Point()
    {
        x = y = 0;
    }

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Point(string raw, string delimiter = ",")
    {
        string[] s = raw.Split(delimiter);
        x = int.Parse(s[0]);
        y = int.Parse(s[1]);
    }

    public override string ToString()
    {
        return $"{x},{y}";
    }
    public override bool Equals(object obj)
    {
        return obj is Point p
            && p.x == x
            && p.y == y;
    }
    public override int GetHashCode()
    {
        return x+1000*y;
    }

    public Point Unit()
    {
        return new Point(x > 0 ? 1 : x < 0 ? -1 : 0, 
            y > 0 ? 1 : y < 0 ? -1 : 0);
    }

    public int LargerComponent() 
    {
        return Math.Max(Math.Abs(x), Math.Abs(y));
    }
    public static Point operator + (Point a, Point b)
    {
        return new Point(a.x+b.x, a.y+b.y);
    }

    public static Point operator - (Point a, Point b)
    {
        return new Point(a.x-b.x, a.y-b.y);
    }

    public static Point operator - (Point a)
    {
        return new Point(-a.x,-a.y);
    }

    public static Point operator * (Point a, int k)
    {
        return new Point(a.x * k, a.y * k);
    }

    public static Point operator * (int k, Point a)
    {
        return new Point(a.x * k, a.y * k);
    }


}
