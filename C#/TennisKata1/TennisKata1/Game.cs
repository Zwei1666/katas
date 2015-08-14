using System;

namespace TennisKata1
{
    public class Game
    {
        private const int MinimalNumberOfPointsToWin = 4;
        private const int MinimalDifferenceInPointsToWin = 2;

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

                if (scoreA >= MinimalNumberOfPointsToWin && scoreA - scoreB >= MinimalDifferenceInPointsToWin)
                {
                    return "Player A wins";
                }
                if ( scoreB >= MinimalNumberOfPointsToWin &&  scoreB - scoreA >= MinimalDifferenceInPointsToWin)
                {
                    return "Player B wins";
                }
                if (IsDeuceAdvantageSituation(scoreA, scoreB))
                {
                    if(scoreA > scoreB)
                    {
                        return "Player A advantage";
                    }

                    if (scoreB > scoreA)
                    {
                        return "Player B advantage";
                    }

                    return "deuce";
                }

                return GetScoreName(scoreA) + ":" + GetScoreName(scoreB);
            }
        }

        private static bool IsDeuceAdvantageSituation(int scoreA, int scoreB)
        {
            return scoreA >= 3 && scoreB >= 3;
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