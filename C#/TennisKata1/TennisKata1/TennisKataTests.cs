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
        public string StartingScoreShouldBeDisplayedProperly(string gameProcess)
        {
            //Given
            var game = new Game();
            foreach (var round in gameProcess)
            {
                if (round == 'A')
                {
                    game.PlayerA.AddPoint();
                }
                else
                {
                    game.PlayerB.AddPoint();
                }
            }
            const string expectedResult = "love:love";

            //When & Then
            return game.Score;
        }
    }
}
