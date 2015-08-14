namespace TennisKata1
{
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