namespace TennisSimulator
{
    public class SetPointAwarder : IPointAwarder
    {
        private readonly GameSimulator _gameSimulator;

        public SetPointAwarder(GameSimulator gameSimulator)
        {
            _gameSimulator = gameSimulator;
        }

        public void AwardPoint(ScoreResult setScore)
        {
            if (_gameSimulator.SimulateGame().Player1Win)
                setScore.Player1Score++;
            else
                setScore.Player2Score++;
        }
    }
}