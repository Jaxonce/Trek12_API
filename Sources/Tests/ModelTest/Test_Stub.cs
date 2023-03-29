using EntityFrameWorkLib;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Model;
using NUnit.Framework.Internal;
using Stub;
using System.Data;
using static Stub.StubData;

namespace ModelTest
{
    public class Test_Stub
    {
        [Fact]
        public void Test_AddNewPlayer()
        {
            Player player = new Player("Jax");
            GameMode gameMode = new GameMode();
            DateOnly dateTime = new DateOnly(2023, 01, 01);
            Game game = new Game(dateTime, player, gameMode, 1);
        }
    }
}