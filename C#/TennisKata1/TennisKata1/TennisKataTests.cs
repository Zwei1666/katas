using System.Media;
using System.Security.Policy;
using NUnit.Framework;

namespace TennisKata1
{
    public class TennisKataTests
    {
        [Test]
        public void StartingScoreShouldBeDisplayedProperly()
        {
            //Given
            var game = new Game();
            var expectedResult = "love:love";

            //When
            var result = game.Score;

            //Then
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ScoreAfterFirstBallShouldBeDisplayedProperly()
        {
            //Given
            var game = new Game();
            var expectedResult = "fifteen:love";

            //When
            game.PlayerA.AddPoint();
            var result = game.Score;

            //Then
            Assert.AreEqual(expectedResult, result);
        }
    }
}
