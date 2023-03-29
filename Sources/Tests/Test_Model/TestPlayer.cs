using Model;

namespace Test_Model;

public class TestPlayer
{
    public static IEnumerable<object[]> PlayerData =>
        new List<object[]>
        {
        new object[] { new Player("Alice", new Stats { NbWin = 2, NbPlayed = 5, MaxChain = 3, MaxZone = 10, MaxPoints = 200 }), true },
        new object[] { new Player("Bob", new Stats { NbWin = 1, NbPlayed = 2, MaxChain = 2, MaxZone = 5, MaxPoints = 100 }), false },
        new object[] { new Player("Alice", new Stats { NbWin = 1, NbPlayed = 3, MaxChain = 4, MaxZone = 12, MaxPoints = 150 }), true },
        new object[] { new Player(null), false },
        new object[] { new Player("Charlie"), false }
        };

    [Theory]
    [MemberData(nameof(PlayerData))]
    public void TestEquals(Player p1, bool expected)
    {
        var p2 = new Player(p1.Pseudo, p1.Stats, p1.Id);

        Assert.Equal(expected, p1.Equals(p2));
    }

    [Theory]
    [InlineData("Alice", 2, 5, 3, 10, 200)]
    [InlineData("Bob", 1, 2, 2, 5, 100)]
    [InlineData("Charlie", 0, 0, 0, 0, 0)]
    public void TestConstructorWithStats(string pseudo, int nbWin, int nbPlayed, int maxChain, int maxZone, int maxPoints)
    {
        var stats = new Stats { NbWin = nbWin, NbPlayed = nbPlayed, MaxChain = maxChain, MaxZone = maxZone, MaxPoints = maxPoints };
        var player = new Player(pseudo, stats);

        Assert.Equal(pseudo, player.Pseudo);
        Assert.Equal(0, player.Id);
        Assert.Equal(nbWin, player.Stats.NbWin);
        Assert.Equal(nbPlayed, player.Stats.NbPlayed);
        Assert.Equal(maxChain, player.Stats.MaxChain);
        Assert.Equal(maxZone, player.Stats.MaxZone);
        Assert.Equal(maxPoints, player.Stats.MaxPoints);
    }

    [Fact]
    public void TestAddWin()
    {
        var player = new Player("Alice");
        player.AddWin();
        player.AddWin();
        player.AddWin();

        Assert.Equal(3, player.Stats.NbWin);
    }

    [Fact]
    public void TestAddPlayed()
    {
        var player = new Player("Alice");
        player.AddPlayed();
        player.AddPlayed();

        Assert.Equal(2, player.Stats.NbPlayed);
    }

    [Theory]
    [InlineData("John")]
    [InlineData("Jane")]
    [InlineData("Jake")]
    public void AddWin_ShouldIncrementNbWinByOne(string pseudo)
    {
        // Arrange
        var player = new Player(pseudo);
        var initialNbWin = player.Stats.NbWin;

        // Act
        player.AddWin();

        // Assert
        Assert.Equal(initialNbWin + 1, player.Stats.NbWin);
    }

    [Theory]
    [InlineData("John")]
    [InlineData("Jane")]
    [InlineData("Jake")]
    public void AddPlayed_ShouldIncrementNbPlayedByOne(string pseudo)
    {
        // Arrange
        var player = new Player(pseudo);
        var initialNbPlayed = player.Stats.NbPlayed;

        // Act
        player.AddPlayed();

        // Assert
        Assert.Equal(initialNbPlayed + 1, player.Stats.NbPlayed);
    }

    [Theory]
    [InlineData("John", 10)]
    [InlineData("Jane", 5)]
    [InlineData("Jake", 7)]
    public void AddMaxChain_ShouldSetMaxChain(string pseudo, int maxChain)
    {
        // Arrange
        var player = new Player(pseudo);
        var initialMaxChain = player.Stats.MaxChain;

        // Act
        player.AddMaxChain(maxChain);

        // Assert
        Assert.Equal(maxChain, player.Stats.MaxChain);
        Assert.NotEqual(initialMaxChain, player.Stats.MaxChain);
    }

    [Theory]
    [InlineData("John", 5)]
    [InlineData("Jane", 8)]
    [InlineData("Jake", 12)]
    public void AddMaxZone_ShouldSetMaxZone(string pseudo, int maxZone)
    {
        // Arrange
        var player = new Player(pseudo);
        var initialMaxZone = player.Stats.MaxZone;

        // Act
        player.AddMaxZone(maxZone);

        // Assert
        Assert.Equal(maxZone, player.Stats.MaxZone);
        Assert.NotEqual(initialMaxZone, player.Stats.MaxZone);
    }

    [Theory]
    [InlineData("John", 100)]
    [InlineData("Jane", 50)]
    [InlineData("Jake", 75)]
    public void AddMaxPoints_ShouldSetMaxPoints(string pseudo, int maxPoints)
    {
        // Arrange
        var player = new Player(pseudo);
        var initialMaxPoints = player.Stats.MaxPoints;

        // Act
        player.AddMaxPoints(maxPoints);

        // Assert
        Assert.Equal(maxPoints, player.Stats.MaxPoints);
        Assert.NotEqual(initialMaxPoints, player.Stats.MaxPoints);
    }
}
