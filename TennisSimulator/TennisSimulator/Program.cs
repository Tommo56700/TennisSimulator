using System;

namespace TennisSimulator
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class GameScore
    {
        public GameScore(int player1Score = 0, int player2Score = 0)
        {
            Player1Score = player1Score;
            Player2Score = player2Score;
        }

        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
    }

    public class GameSimulator
    {
        public GameScore SimulateGame()
        {
            var gameScore = new GameScore();

            while (!IsGameOver(gameScore))
            {
                
            }

            return gameScore;
        }

        private bool IsGameOver(GameScore gameScore) => ;

        private void RandomlyAwardPoint(GameScore gameScore)
        {
            var random = new Random();

            if (random.NextDouble() > 0.5)
                gameScore.Player1Score++;
            else
                gameScore.Player2Score++;
        }
    }
}
