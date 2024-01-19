namespace AoC;

public class Solver
{
    public List<Sensor> Sensors { get; }

    public Solver(IEnumerable<string> lines)
    {
        Sensors = lines.Select(Sensor.Parse).ToList();
    }

    public int SolvePart1(int y)
    {
        HashSet<int> impossiblePositions = new();

        foreach (Sensor sensor in Sensors)
        {
            if (!sensor.OverlapsY(y))
            {
                continue;
            }

            // The further the sensor is from line y, the less positions overlap with line y.
            // Suppose we have a sensor at (9, 9) with ManhattanRadius 1:
            // 10              #
            //  9             ###
            //  8              #
            // Then the deltaY is 1. We have to add that to the startX (8 => 9) and subtract it from the enX (10 => 9).
            int deltaY = Math.Abs(y - sensor.Location.Y);
            int startX = sensor.Location.X - sensor.ManhattanRadius + deltaY;
            int endX = sensor.Location.X + sensor.ManhattanRadius - deltaY;
            for (int x = startX; x <= endX; x++)
            {
                impossiblePositions.Add(x);
            }
        }

        // Appearantly positions where a beacon is already located do not count as locations where a beacon can't possible be.
        IEnumerable<int> beaconXs = from sensor in Sensors
                                    let beaconLocation = sensor.NearestBeaconLocation
                                    where beaconLocation.Y == y
                                    select beaconLocation.X;
        impossiblePositions.ExceptWith(beaconXs);

        return impossiblePositions.Count;
    }

    public long SolvePart2(int range)
    {
        for (int i = 0; i < Sensors.Count; i++)
        {
            Sensor sensor = Sensors[i];
            IEnumerable<Point> eligiblePoints = sensor.EdgePoints.Where(l => l.X >= 0 && l.X <= range && l.Y >= 0 && l.Y <= range);
            foreach (Point p in eligiblePoints)
            {
                bool isPossiblePosition = true;
                for (int j = 0; j < Sensors.Count; j++)
                {
                    if (i == j) continue;
                    Sensor otherSensor = Sensors[j];
                    if (otherSensor.IsPointWithinRange(p))
                    {
                        isPossiblePosition = false;
                        break;
                    }
                }
                if (isPossiblePosition)
                {
                    return p.X * 4000000L + p.Y;
                }
            }
        }
        return 0;
    }

    public void Print(int range)
    {
        for (int y = 0; y <= range; y++)
        {
            for (int x = 0; x <= range; x++)
            {
                Point p = new(x, y);
                var sensors = Sensors.Where(s => s.IsPointWithinRange(p));
                if (sensors.Any())
                {
                    int i = Sensors.IndexOf(sensors.First());
                    if (sensors.Count() > 1)
                    {
                        Console.Write($" {i,2}*");
                    }
                    else
                    {
                        Console.Write($" {i,2} ");
                    }
                }
                else
                {
                    Console.Write("    ");
                }
            }
            Console.WriteLine();
        }
    }
}