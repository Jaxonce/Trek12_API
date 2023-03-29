using System.Numerics;
using Model;
using Stub;

namespace Test_Stub;

public class Test_Stub_Games
{
    public static IEnumerable<object[]> GetGameAndPlayerIds()
    {
        yield return new object[] { 1, 0 };
        yield return new object[] { 2, 1 };
        yield return new object[] { 3, 2 };
        yield return new object[] { 4, 3 };
    }

    public static IEnumerable<object[]> GetInvalidGameAndPlayerIds()
    {
        yield return new object[] { -1, 0 };
        yield return new object[] { 1, -1 };
        yield return new object[] { 5, 0 };
        yield return new object[] { 1, 4 };
    }

    //[Theory]
    //[MemberData(nameof(GetGameAndPlayerIds))]
    //public async Task AddScoreToPlayer_ValidIds_ReturnsTrue(int gameId, int playerId)
    //{
    //    // Arrange
    //    var stubData = new StubData();
    //    var manager = new StubData.GamesManager(stubData);

    //    // Act
    //    var result = await manager.AddScoreToPlayer(gameId, playerId, 10);

    //    // Assert
    //    Assert.True(result);
    //}

    [Theory]
    [MemberData(nameof(GetInvalidGameAndPlayerIds))]
    public async Task AddScoreToPlayer_InvalidIds_ReturnsFalse(int gameId, int playerId)
    {
        // Arrange
        var stubData = new StubData();
        var manager = new StubData.GamesManager(stubData);

        // Act
        var result = await manager.AddScoreToPlayer(gameId, playerId, 10);

        // Assert
        Assert.False(result);
    }

    //[Fact]
    //public async Task AddPlayer_ValidPlayer_ReturnsTrue()
    //{
    //    // Arrange
    //    var stubData = new StubData();
    //    var manager = new StubData.GamesManager(stubData);
    //    var player = new Player("John", 4);

    //    // Act
    //    var result = await manager.AddPlayer(player);

    //    // Assert
    //    Assert.True(result);
    //}

    //[Fact]
    //public async Task AddPlayer_InvalidGame_ReturnsFalse()
    //{
    //    // Arrange
    //    var stubData = new StubData();
    //    var manager = new StubData.GamesManager(stubData);
    //    var player = new Player("John", 4);

    //    // Act
    //    var result = await manager.AddPlayer(player);

    //    // Assert
    //    Assert.True(result);
    //}

    [Fact]
    public async Task GetItems_ReturnsCorrectCount()
    {
        // Arrange
        var stubData = new StubData();
        var manager = new StubData.GamesManager(stubData);

        // Act
        var items = await manager.GetItems(0, 3, null);

        // Assert
        Assert.Equal(3, items.Count());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public async Task GetItemsById_ReturnsCorrectItem(int id)
    {
        // Arrange
        var stubData = new StubData();
        var manager = new StubData.GamesManager(stubData);

        // Act
        var items = await manager.GetItemsById(id);

        // Assert
        Assert.Single(items);
        Assert.Equal(id, items.First()?.Id);
    }
}
