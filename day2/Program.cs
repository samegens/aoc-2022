class RockPaperScissors
{
    public enum Rps
    {
        Rock,
        Paper,
        Scissors
    }

    public enum Result
    {
        Win,
        Loss,
        Draw
    }

    private static Dictionary<Result, int> ResultScores = new Dictionary<Result, int>
    {
        { Result.Win, 6 },
        { Result.Loss, 0 },
        { Result.Draw, 3 }
    };

    private static Dictionary<Rps, int> RockPaperScissorsScores = new Dictionary<Rps, int>
    {
        { Rps.Rock, 1 },
        { Rps.Paper, 2 },
        { Rps.Scissors, 3 }
    };

    public static int GetScoreFor(Rps other, Rps me)
    {
        Result result = Play(other, me);
        return ResultScores[result] + RockPaperScissorsScores[me];
    }

    private static Result Play(Rps other, Rps me)
    {
        if (other == me)
        {
            return Result.Draw;
        }

        if (other == Rps.Rock && me == Rps.Paper)
        {
            return Result.Win;
        }

        if (other == Rps.Paper && me == Rps.Scissors)
        {
            return Result.Win;
        }

        if (other == Rps.Scissors && me == Rps.Rock)
        {
            return Result.Win;
        }

        return Result.Loss;
    }

    public static Rps DetermineWhatToPlay(Rps other, Result requestedResult)
    {
        if (requestedResult == Result.Draw)
        {
            return other;
        }

        if (requestedResult == Result.Win)
        {
            if (other == Rps.Rock)
            {
                return Rps.Paper;
            }

            if (other == Rps.Paper)
            {
                return Rps.Scissors;
            }

            if (other == Rps.Scissors)
            {
                return Rps.Rock;
            }
        }

        if (requestedResult == Result.Loss)
        {
            if (other == Rps.Rock)
            {
                return Rps.Scissors;
            }

            if (other == Rps.Paper)
            {
                return Rps.Rock;
            }

            if (other == Rps.Scissors)
            {
                return Rps.Paper;
            }
        }

        throw new Exception("Should not happen");
    }
}

class StrategyLine
{
    public RockPaperScissors.Rps Other { get; set; }
    public RockPaperScissors.Rps Me { get; set; }
}

internal class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input.txt");
        SolvePart1(lines);
        SolvePart2(lines);
    }

    private static List<StrategyLine> ParseStrategyLinesPart1(string[] lines)
    {
        var charToRockPaperScissors = new Dictionary<char, RockPaperScissors.Rps>
        {
            { 'A', RockPaperScissors.Rps.Rock },
            { 'B', RockPaperScissors.Rps.Paper },
            { 'C', RockPaperScissors.Rps.Scissors },
            { 'X', RockPaperScissors.Rps.Rock },
            { 'Y', RockPaperScissors.Rps.Paper },
            { 'Z', RockPaperScissors.Rps.Scissors },
        };
        List<StrategyLine> strategyLines = new List<StrategyLine>();
        foreach (string line in lines)
        {
            string[] split = line.Split(' ');
            RockPaperScissors.Rps other = charToRockPaperScissors[split[0][0]];
            RockPaperScissors.Rps me = charToRockPaperScissors[split[1][0]];
            strategyLines.Add(new StrategyLine { Other = other, Me = me });
        }

        return strategyLines;
    }

    private static void SolvePart1(string[] lines)
    {
        List<StrategyLine> strategyLines = ParseStrategyLinesPart1(lines);

        int score = 0;
        foreach (StrategyLine strategyLine in strategyLines)
        {
            score += RockPaperScissors.GetScoreFor(strategyLine.Other, strategyLine.Me);
        }

        Console.WriteLine($"Part 1: {score}");
    }

    private static List<StrategyLine> ParseStrategyLinesPart2(string[] lines)
    {
        var charToRockPaperScissors = new Dictionary<char, RockPaperScissors.Rps>
        {
            { 'A', RockPaperScissors.Rps.Rock },
            { 'B', RockPaperScissors.Rps.Paper },
            { 'C', RockPaperScissors.Rps.Scissors },
        };
        var charToResult = new Dictionary<char, RockPaperScissors.Result>
        {
            { 'X', RockPaperScissors.Result.Loss },
            { 'Y', RockPaperScissors.Result.Draw },
            { 'Z', RockPaperScissors.Result.Win },
        };
        List<StrategyLine> strategyLines = new List<StrategyLine>();
        foreach (string line in lines)
        {
            string[] split = line.Split(' ');
            RockPaperScissors.Rps other = charToRockPaperScissors[split[0][0]];
            RockPaperScissors.Result requestedResult = charToResult[split[1][0]];
            RockPaperScissors.Rps me = RockPaperScissors.DetermineWhatToPlay(other, requestedResult);
            strategyLines.Add(new StrategyLine { Other = other, Me = me });
        }

        return strategyLines;
    }

    private static void SolvePart2(string[] lines)
    {
        List<StrategyLine> strategyLines = ParseStrategyLinesPart2(lines);

        int score = 0;
        foreach (StrategyLine strategyLine in strategyLines)
        {
            score += RockPaperScissors.GetScoreFor(strategyLine.Other, strategyLine.Me);
        }

        Console.WriteLine($"Part 2: {score}");
    }
}
