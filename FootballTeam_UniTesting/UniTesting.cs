using System;
using System.Security.Cryptography;
using NUnit.Framework;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test_Constructor()
        {
            var team = new FootballTeam("Levski", 15);
            Assert.AreEqual(team.Name, "Levski");
            Assert.AreEqual(team.Capacity, 15);
            Assert.AreEqual(team.Players.Count, 0);
        }

        [Test]
        public void Test_Name_Throw_Exceptions()
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam(null, 15));
            Assert.Throws<ArgumentException>(() => new FootballTeam(string.Empty, 15));

        }

        [Test]
        public void Test_Capacity_Throw_Exceptions()
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam("Levski", 0));
            Assert.Throws<ArgumentException>(() => new FootballTeam("Levski", 14));

        }

        [Test]
        public void Test_AddNewPlayer_InCorrectly()
        {
            var team = new FootballTeam("Levski", 15);
            var player = new FootballPlayer("Pesho", 8, "Forward");
            for (int i = 1; i <= 15; i++)
            {
                team.AddNewPlayer(new FootballPlayer($"Pesho{i}", i, "Goalkeeper"));
            }

            var expectedResult = team.AddNewPlayer(player);

            Assert.AreEqual(expectedResult, "No more positions available!");
        }


        [Test]
        public void TestAddNewPlayer_Work_Correctly()
        {
            var team = new FootballTeam("Levski", 15);
            var player = new FootballPlayer("Pesho", 15, "Forward");

            var actualResult = team.AddNewPlayer(player);
            var expectedResult =
                $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}";
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void TestPickPLayersWorkCorrectly()
        {
            var team = new FootballTeam("Levski", 15);
            var player = new FootballPlayer("Pesho", 1, "Forward");
            var invlidPlayer = new FootballPlayer("Pesho", 13, "Forward");
            team.AddNewPlayer(player);

            Assert.AreEqual(team.PickPlayer("Pesho"), player);
            Assert.AreEqual(team.PickPlayer("Gosho"), null);
            
        }

        [Test]
        public void TestPlayerScoreGoalsWorkCorrectly()
        {
            var team = new FootballTeam("Levski", 15);
            var player = new FootballPlayer("Pesho", 1, "Forward");
            team.AddNewPlayer(player);
            team.PlayerScore(1);
            var expected = $"Pesho scored and now has {player.ScoredGoals} for this season!";

            Assert.AreEqual(player.ScoredGoals, 1);

            Assert.AreEqual(expected, $"{player.Name} scored and now has {player.ScoredGoals} for this season!");

        }
    }
}
