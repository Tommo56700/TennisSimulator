using System;

namespace TennisSimulator
{
    public class GameDecider : IDecider
    {
        public bool IsOver(ScoreResult scoreResult) =>
            (scoreResult.Player1Score >= 4 || scoreResult.Player2Score >= 4) &&
            Math.Abs(scoreResult.Player1Score - scoreResult.Player2Score) >= 2;
    }
}