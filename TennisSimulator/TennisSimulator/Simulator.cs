using TennisSimulator.Deciders;
using TennisSimulator.Domain;
using TennisSimulator.PointAwarders;

namespace TennisSimulator
{
    public class Simulator : ISimulator
    {
        private readonly IPointAwarder _PointAwarder;
        private readonly IDecider _decider;

        public Simulator(IPointAwarder pointAwarder, IDecider decider)
        {
            _PointAwarder = pointAwarder;
            _decider = decider;
        }

        public ScoreResult Simulate()
        {
            var score = new ScoreResult();

            while (!_decider.IsOver(score))
            {
                _PointAwarder.AwardPoint(score);
            }

            score.Player1Win = score.Player1Score > score.Player2Score;

            return score;
        }
    }
}