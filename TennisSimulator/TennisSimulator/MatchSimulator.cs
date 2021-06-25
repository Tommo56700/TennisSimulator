using TennisSimulator.Deciders;
using TennisSimulator.Domain;
using TennisSimulator.PointAwarders;

namespace TennisSimulator
{
    public class MatchSimulator
    {
        private readonly IPointAwarder _matchPointAwarder;
        private readonly IDecider _matchDecider;

        public MatchSimulator(IPointAwarder matchPointAwarder, IDecider matchDecider)
        {
            _matchPointAwarder = matchPointAwarder;
            _matchDecider = matchDecider;
        }

        public ScoreResult SimulateMatch()
        {
            var gameScore = new ScoreResult();

            while (!_matchDecider.IsOver(gameScore))
            {
                _matchPointAwarder.AwardPoint(gameScore);
            }

            gameScore.Player1Win = gameScore.Player1Score > gameScore.Player2Score;

            return gameScore;
        }
    }
}