using System.Text.RegularExpressions;

namespace AoC;

public class Sensor
{
    public Sensor(Point location, Point nearestBeaconLocation)
    {
        Location = location;
        NearestBeaconLocation = nearestBeaconLocation;
        ManhattanRadius = Math.Abs(Location.X - NearestBeaconLocation.X) + Math.Abs(Location.Y - NearestBeaconLocation.Y);
    }

    public Point Location { get; }

    public Point NearestBeaconLocation { get; }

    public int ManhattanRadius { get; }

    public IEnumerable<Point> EdgePoints
    {
        get
        {
            for (int x = Location.X; x <= Location.X + ManhattanRadius; x++)
            {
                int deltaX = x - Location.X;
                int y = Location.Y + ManhattanRadius - deltaX + 1;
                yield return new Point(x, y);
            }
            for (int y = Location.Y; y >= Location.Y - ManhattanRadius; y--)
            {
                int deltaY = Location.Y - y;
                int x = Location.X + ManhattanRadius - deltaY + 1;
                yield return new Point(x, y);
            }
            for (int x = Location.X; x >= Location.X - ManhattanRadius; x--)
            {
                int deltaX = Location.X - x;
                int y = Location.Y - ManhattanRadius + deltaX - 1;
                yield return new Point(x, y);
            }
            for (int y = Location.Y; y <= Location.Y + ManhattanRadius; y++)
            {
                int deltaY = y - Location.Y;
                int x = Location.X - ManhattanRadius + deltaY - 1;
                yield return new Point(x, y);
            }
        }
    }

    public static Sensor Parse(string line)
    {
        string pattern = @"x=(-?\d+), y=(-?\d+).*x=(-?\d+), y=(-?\d+)";
        Match? match = Regex.Match(line, pattern);

        int x = int.Parse(match.Groups[1].Value);
        int y = int.Parse(match.Groups[2].Value);
        Point location = new(x, y);

        x = int.Parse(match.Groups[3].Value);
        y = int.Parse(match.Groups[4].Value);
        Point nearestBeaconLocation = new(x, y);

        return new Sensor(location, nearestBeaconLocation);
    }

    public bool IsPointOnEdge(Point point)
    {
        return Location.GetManhattanDistanceTo(point) == ManhattanRadius + 1;
    }

    public bool IsPointWithinRange(Point point)
    {
        return Location.GetManhattanDistanceTo(point) <= ManhattanRadius;
    }

    public bool OverlapsY(int y)
    {
        return y <= Location.Y + ManhattanRadius && y >= Location.Y - ManhattanRadius;
    }

    public override string ToString()
    {
        return $"({Location.X}, {Location.Y}), ({NearestBeaconLocation.X}, {NearestBeaconLocation.Y}): {ManhattanRadius}";
    }
}
