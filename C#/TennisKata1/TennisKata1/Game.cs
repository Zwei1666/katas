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
                return PlayerA.Points + ":" + PlayerB.Points;
            }
        }

        public class Player
        {
            private int _points = 0;

            public string Points
            {
                get
                {
                    switch (_points)
                    {
                        case 0:
                            return "love";
                        case 1:
                            return "fifteen";
                        case 2:
                            return "thirty";
                        default:
                            return "";
                    }
                }
            }

            public void AddPoint()
            {
                _points++;
            }
        }
    }
}