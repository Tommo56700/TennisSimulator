using System;

namespace TennisSimulator
{
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