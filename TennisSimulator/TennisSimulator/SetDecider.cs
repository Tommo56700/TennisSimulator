using System;

namespace TennisSimulator
{
    public class SetDecider : IDecider
    {
        public bool IsOver(ScoreResult setScore) =>
            (setScore.Player1Score >= 6 || setScore.Player2Score >= 6) &&
            Math.Abs(setScore.Player1Score - setScore.Player2Score) >= 2;
    }
}