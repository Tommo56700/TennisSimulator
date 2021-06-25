using System;
using TennisSimulator.Domain;

namespace TennisSimulator.Deciders
{
    public class GameDecider : IDecider
    {
        public bool IsOver(ScoreResult gameScore) =>
            (gameScore.Player1Score >= 4 || gameScore.Player2Score >= 4) &&
            Math.Abs(gameScore.Player1Score - gameScore.Player2Score) >= 2;
    }
}