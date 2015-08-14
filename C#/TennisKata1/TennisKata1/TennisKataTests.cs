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
        public void ScoreAfterFirstBallForPlayerAShouldBeDisplayedProperly()
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

        [Test]
        public void ScoreAfterFirstBallForPlayerBShouldBeDisplayedProperly()
        {
            //Given
            var game = new Game();
            const string expectedResult = "love:fifteen";

            //When
            game.PlayerB.AddPoint();
            var result = game.Score;

            //Then
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ScoreRemisAfterSecondBallShouldBeDisplayedProperly()
        {
            //Given
            var game = new Game();
            const string expectedResult = "fifteen:fifteen";

            //When
            game.PlayerA.AddPoint();
            game.PlayerB.AddPoint();
            var result = game.Score;

            //Then
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ScoreAfterFirstBallForPlayerAAndSecondBallForPlayerAShouldBeDisplayedProperly()
        {
            //Given
            var game = new Game();
            const string expectedResult = "thirty:love";

            //When
            game.PlayerA.AddPoint();
            game.PlayerA.AddPoint();
            var result = game.Score;

            //Then
            Assert.AreEqual(expectedResult, result);
        }
    }
}
