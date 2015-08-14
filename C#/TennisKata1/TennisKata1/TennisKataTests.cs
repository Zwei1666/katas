using System.Media;
using System.Security.Policy;
using NUnit.Framework;

namespace TennisKata1
{
    public class TennisKataTests
    {
        [Test]
        public void CurrentScoreShouldBeDisplayedProperly()
        {
            //Given
            var game = new Game();
            var expectedResult = "love:love";

            //When
            game.PlayerA.SetPoints(0);
            game.PlayerB.SetPoints(0);
            var result = game.Score;

            //Then
            Assert.AreEqual(expectedResult, result);
        }
    }
}
