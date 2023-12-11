namespace SolverTests;

public class DatastreamBufferTests
{
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 0, "mjqj")]
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 1, "jqjp")]
    public void TestGet4Chars(string stream, int index, string expectedResult)
    {
        // Arrange
        DatastreamBuffer datastreamBuffer = new(stream, 4);

        // Act
        string result = datastreamBuffer.GetWindowAt(index);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    public void TestGetNrCharsForMarker(string stream, int expectedResult)
    {
        // Arrange
        DatastreamBuffer datastreamBuffer = new(stream, 4);

        // Act
        int result = datastreamBuffer.GetNrCharsForMarker();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}