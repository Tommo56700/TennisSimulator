namespace TennisSimulator
{
    public class GameSimulator
    {
        private readonly IGamePointAwarder _pointAwarder;
        private readonly IGameDecider _gameDecider;

        public GameSimulator(IGamePointAwarder pointAwarder, IGameDecider gameDecider)
        {
            _pointAwarder = pointAwarder;
            _gameDecider = gameDecider;
        }

        public GameScore SimulateGame()
        {
            var gameScore = new GameScore();

            while (!_gameDecider.IsGameOver(gameScore))
            {
                _pointAwarder.AwardPoint(gameScore);
            }

            return gameScore;
        }
    }
}