using System;

namespace TennisSimulator
{
    public class GameSimulator
    {
        private readonly IGamePointAwarder _pointAwarder;

        public GameSimulator(IGamePointAwarder pointAwarder)
        {
            _pointAwarder = pointAwarder;
        }

        public GameScore SimulateGame()
        {
            var gameScore = new GameScore();

            while (!(HasPlayerWonGame(gameScore.Player1Score, gameScore.Player2Score) || 
                     HasPlayerWonGame(gameScore.Player2Score, gameScore.Player1Score)))
            {
                _pointAwarder.AwardPoint(gameScore);
            }

            return gameScore;
        }

        private bool HasPlayerWonGame(int playerScore, int opponentScore) =>
            playerScore > 3 && playerScore - opponentScore > 1;
    }

    public interface IGamePointAwarder
    {
        public void AwardPoint(GameScore gameScore);
    }

    public class RandomGamePointAwarder : IGamePointAwarder
    {
        public void AwardPoint(GameScore gameScore)
        {
            var random = new Random();

            if (random.NextDouble() > 0.5)
                gameScore.Player1Score++;
            else
                gameScore.Player2Score++;
        }
    }
}