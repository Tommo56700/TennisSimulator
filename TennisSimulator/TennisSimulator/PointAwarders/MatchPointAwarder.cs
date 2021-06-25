using TennisSimulator.Domain;

namespace TennisSimulator.PointAwarders
{
    public class MatchPointAwarder : IPointAwarder
    {
        private readonly ISimulator _setSimulator;

        public MatchPointAwarder(ISimulator setSimulator)
        {
            _setSimulator = setSimulator;
        }

        public void AwardPoint(ScoreResult setScore)
        {
            if (_setSimulator.Simulate().Player1Win == true)
                setScore.Player1Score++;
            else
                setScore.Player2Score++;
        }
    }
}