using TennisSimulator.Deciders;
using TennisSimulator.Domain;
using TennisSimulator.PointAwarders;

namespace TennisSimulator
{
    public class SetSimulator : ISimulator
    {
        private readonly IPointAwarder _setPointAwarder;
        private readonly IDecider _setDecider;

        public SetSimulator(IPointAwarder setPointAwarder, IDecider setDecider)
        {
            _setPointAwarder = setPointAwarder;
            _setDecider = setDecider;
        }

        public ScoreResult Simulate()
        {
            var setScore = new ScoreResult();

            while (!_setDecider.IsOver(setScore))
            {
                _setPointAwarder.AwardPoint(setScore);
            }

            setScore.Player1Win = setScore.Player1Score > setScore.Player2Score;

            return setScore;
        }
    }
}