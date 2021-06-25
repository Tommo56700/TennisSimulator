using TennisSimulator.Domain;

namespace TennisSimulator.PointAwarders
{
    public class SetPointAwarder : IPointAwarder
    {
        private readonly ISimulator _gameSimulator;

        public SetPointAwarder(ISimulator gameSimulator)
        {
            _gameSimulator = gameSimulator;
        }

        public void AwardPoint(ScoreResult setScore)
        {
            if (_gameSimulator.Simulate().Player1Win == true)
                setScore.Player1Score++;
            else
                setScore.Player2Score++;
        }
    }
}