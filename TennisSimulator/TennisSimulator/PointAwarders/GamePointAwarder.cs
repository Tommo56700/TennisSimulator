using System;
using TennisSimulator.Domain;

namespace TennisSimulator.PointAwarders
{
    public class GamePointAwarder : IPointAwarder
    {
        public void AwardPoint(ScoreResult scoreResult)
        {
            var random = new Random();

            if (random.Next(0, 2) > 0)
                scoreResult.Player1Score++;
            else
                scoreResult.Player2Score++;
        }
    }
}