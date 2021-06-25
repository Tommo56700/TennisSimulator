using TennisSimulator.Deciders;
using TennisSimulator.Domain;
using TennisSimulator.PointAwarders;

namespace TennisSimulator
{
    public class GameSimulator : ISimulator
    {
        private readonly IPointAwarder _gamePointAwarder;
        private readonly IDecider _gameDecider;

        public GameSimulator(IPointAwarder gamePointAwarder, IDecider gameDecider)
        {
            _gamePointAwarder = gamePointAwarder;
            _gameDecider = gameDecider;
        }

        public ScoreResult Simulate()
        {
            var gameScore = new ScoreResult();

            while (!_gameDecider.IsOver(gameScore))
            {
                _gamePointAwarder.AwardPoint(gameScore);
            }

            gameScore.Player1Win = gameScore.Player1Score > gameScore.Player2Score;

            return gameScore;
        }
    }
}