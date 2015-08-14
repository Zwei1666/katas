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
            public void AddPoint()
            {
                throw new System.NotImplementedException();
            }
        }
    }

    
}
