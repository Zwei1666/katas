using System;
using NUnit.Framework;

namespace TennisKata1
{
    public class TennisKataTests
    {
        [TestCase("",ExpectedResult = "love:love")]
        [TestCase("A", ExpectedResult = "fifteen:love")]
        [TestCase("B", ExpectedResult = "love:fifteen")]
        [TestCase("AB", ExpectedResult = "fifteen:fifteen")]
        [TestCase("AA", ExpectedResult = "thirty:love")]
        [TestCase("AAA", ExpectedResult = "forty:love")]
        [TestCase("AAABBB", ExpectedResult = "deuce")]
        [TestCase("AAABBBA", ExpectedResult = "Player A advantage")]
        [TestCase("AAABBBB", ExpectedResult = "Player B advantage")]
        [TestCase("AAAA", ExpectedResult = "Player A wins")]

        public string ScoreShouldBeDisplayedProperly(string gameProcess)
        {
            //Given
            var game = new Game();
            ProgressGame(game, gameProcess);
            const string expectedResult = "love:love";

            //When & Then
            return game.Score;
        }

        [TestCase("AAAAA")]
        public void ExceptionShouldBeThrownForInvalidScore(string gameProcess)
        {
            //Given
            var game = new Game();
            ProgressGame(game, gameProcess);

            //When & Then
            Assert.Throws<InvalidOperationException>(() => Utils.Ignore(game.Score) );
        }

        private void ProgressGame(Game game, string gameProcess)
        {
            foreach (var round in gameProcess)
            {
                switch (round)
                {
                    case 'A':
                        game.PlayerA.AddPoint();
                        break;
                    case 'B':
                        game.PlayerB.AddPoint();
                        break;
                    default:
                        throw new ArgumentException(string.Format("Invalid symbol {0}", round), "gameProcess");
                }
            }
        }
    }

    public static class Utils
    {
        public static void Ignore<T>(T ignoredValude)
        {
        }
    }
}
