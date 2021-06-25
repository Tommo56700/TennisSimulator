using TennisSimulator.Domain;

namespace TennisSimulator.Deciders
{
    public class MatchDecider : IDecider
    {
        public bool IsOver(ScoreResult matchScore) =>
            matchScore.Player1Score == 2 || matchScore.Player2Score == 2;
    }
}