using TennisSimulator.Domain;

namespace TennisSimulator.PointAwarders
{
    public class SimulatedPointAwarder : IPointAwarder
    {
        private readonly ISimulator _simulator;

        public SimulatedPointAwarder(ISimulator simulator)
        {
            _simulator = simulator;
        }

        public void AwardPoint(ScoreResult setScore)
        {
            if (_simulator.Simulate().Player1Win == true)
                setScore.Player1Score++;
            else
                setScore.Player2Score++;
        }
    }
}