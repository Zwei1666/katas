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
            const string expectedResult = "love:love";

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
            const string expectedResult = "fifteen:love";

            //When
            game.PlayerA.AddPoint();
            var result = game.Score;

            //Then
            Assert.AreEqual(expectedResult, result);
        }
    }
}
