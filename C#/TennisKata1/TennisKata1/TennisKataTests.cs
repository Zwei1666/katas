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

    public class Game
    {
        public Game()
        {
            PlayerA = new Player();
            PlayerB = new Player();
        }

        public Player PlayerA { get; private set; }
        public Player PlayerB { get; private set; }

        public string Score
        {
            get
            {
                return "love:love";
            }
        }

        public class Player
        {
            public void SetPoints(int points)
            {
                //throw new System.NotImplementedException();
            }
        }
    }

    
}
