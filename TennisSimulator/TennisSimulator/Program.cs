using System;

namespace TennisSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameSimulator = new GameSimulator(new RandomGamePointAwarder(), new GameDecider());

            var gameScore = gameSimulator.SimulateGame();
        }
    }

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

    public class MatchDecider : IDecider
    {
        public bool IsOver(ScoreResult matchScore) =>
            matchScore.Player1Score == 2 || matchScore.Player2Score == 2;
    }
}
