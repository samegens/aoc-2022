namespace SolverTests;

public class PointTests
{
    [Test]
    public void TestConstructor1()
    {
        // Arrange

        // Act
        Point p = new(1, 2);

        // Assert
        Assert.That(p.X, Is.EqualTo(1));
        Assert.That(p.Y, Is.EqualTo(2));
    }

    [Test]
    public void TestConstructor2()
    {
        // Arrange
        Point original = new(1, 2);

        // Act
        Point p = new(original);

        // Assert
        Assert.That(p.X, Is.EqualTo(1));
        Assert.That(p.Y, Is.EqualTo(2));
    }

    [Test]
    public void TestEqualsWithSameObjects()
    {
        // Arrange
        Point p = new(1, 2);

        // Act
        bool areEqual = p.Equals(p);

        // Assert
        Assert.That(areEqual, Is.True);
    }

    [Test]
    public void TestEqualsWithDifferentEqualObjects()
    {
        // Arrange
        Point p1 = new(1, 2);
        Point p2 = new(1, 2);

        // Act
        bool areEqual = p1.Equals(p2);

        // Assert
        Assert.That(areEqual, Is.True);
    }

    [Test]
    public void TestEqualsWithDifferentObjects()
    {
        // Arrange
        Point p1 = new(1, 2);
        Point p2 = new(1, 3);

        // Act
        bool areEqual = p1.Equals(p2);

        // Assert
        Assert.That(areEqual, Is.False);
    }

    [Test]
    public void TestGetHashCodeWithEqualObjects()
    {
        // Arrange
        Point p1 = new(1, 2);
        Point p2 = new(1, 2);

        // Act
        int hash1 = p1.GetHashCode();
        int hash2 = p2.GetHashCode();

        // Assert
        Assert.That(hash1, Is.EqualTo(hash2));
    }

    [Test]
    public void TestGetHashCodeWithDifferentObjects()
    {
        // Arrange
        Point p1 = new(1, 2);
        Point p2 = new(1, 3);

        // Act
        int hash1 = p1.GetHashCode();
        int hash2 = p2.GetHashCode();

        // Assert
        Assert.That(hash1, Is.Not.EqualTo(hash2));
    }
}