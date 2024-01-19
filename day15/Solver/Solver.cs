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
            // Then the deltaY is 1. We have to add that to the startX (8 => 9) and subtract it from the endX (10 => 9).
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
        // What we're doing here is scanning the edges of all sensor areas and checking if:
        // - the point is within the specified square area,
        // - the point is not within range of any sensor.
        // To optimize this we remember the last sensor that had the point in range, since
        // there's a large chance that the current point is also in range of the same sensor.
        for (int i = 0; i < Sensors.Count; i++)
        {
            Sensor sensor = Sensors[i];
            IEnumerable<Point> eligiblePoints = from p in sensor.EdgePoints
                                                where p.X >= 0 && p.X <= range && p.Y >= 0 && p.Y <= range
                                                select p;

            int lastSensorInRange = -1;
            foreach (Point p in eligiblePoints)
            {
                if (lastSensorInRange >= 0)
                {
                    // First check if the point is covered by the last sensor.
                    if (Sensors[lastSensorInRange].IsCovering(p))
                    {
                        continue;
                    }
                }

                // Find the sensor that is covering the point, if any.
                lastSensorInRange = FindSensorThatCovers(p);
                if (lastSensorInRange < 0)
                {
                    // No sensor is covering the point, we found our beacon!
                    return GetTuningFrequencyForPoint(p);
                }
            }
        }

        return 0;
    }

    private int FindSensorThatCovers(Point p)
    {
        for (int i = 0; i < Sensors.Count; i++)
        {
            if (Sensors[i].IsCovering(p))
            {
                return i;
            }
        }

        return -1;
    }

    private static long GetTuningFrequencyForPoint(Point p)
    {
        return p.X * 4000000L + p.Y;
    }

    public void Print(int range)
    {
        for (int y = 0; y <= range; y++)
        {
            for (int x = 0; x <= range; x++)
            {
                Point p = new(x, y);
                var sensors = Sensors.Where(s => s.IsCovering(p));
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