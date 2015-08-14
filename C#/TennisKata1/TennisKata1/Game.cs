using System;

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
                var scoreA = PlayerA.Points;
                var scoreB = PlayerB.Points;
                if (scoreA >= 3 && scoreB >= 3 && scoreA == scoreB)
                {
                    return "deuce";
                }
                else if (scoreA >= 3 && scoreB >= 3)
                {
                    if (scoreA > scoreB)
                        return "Player A advantage";
                }
                return GetScoreName(scoreA) + ":" + GetScoreName(scoreB);
            }
        }

        private static string GetScoreName(int points)
        {
            switch (points)
            {
                case 0:
                    return "love";
                case 1:
                    return "fifteen";
                case 2:
                    return "thirty";
                case 3:
                    return "forty";
                default:
                    throw new InvalidOperationException();
            }
        }

        public class Player
        {
            public int Points { get; private set; }

            public void AddPoint()
            {
                Points++;
            }
        }
    }
}