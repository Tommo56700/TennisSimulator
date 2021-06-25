using TennisSimulator.Domain;

namespace TennisSimulator.PointAwarders
{
    public class MatchPointAwarder : IPointAwarder
    {
        private readonly SetSimulator _setSimulator;

        public MatchPointAwarder(SetSimulator setSimulator)
        {
            _setSimulator = setSimulator;
        }

        public void AwardPoint(ScoreResult setScore)
        {
            if (_setSimulator.SimulateSet().Player1Win)
                setScore.Player1Score++;
            else
                setScore.Player2Score++;
        }
    }
}