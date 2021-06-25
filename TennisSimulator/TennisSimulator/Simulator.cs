using System;
using TennisSimulator.Deciders;
using TennisSimulator.Domain;
using TennisSimulator.PointAwarders;

namespace TennisSimulator
{
    public class Simulator : ISimulator
    {
        private readonly IPointAwarder _pointAwarder;
        private readonly IDecider _decider;
        private readonly string _name;

        public Simulator(IPointAwarder pointAwarder, IDecider decider, string name)
        {
            _pointAwarder = pointAwarder;
            _decider = decider;
            _name = name;
        }

        public ScoreResult Simulate()
        {
            var score = new ScoreResult();

            do _pointAwarder.AwardPoint(score);
            while (!_decider.IsOver(score));

            score.Player1Win = score.Player1Score > score.Player2Score;

            Console.WriteLine($"{_name} Result: {score}");

            return score;
        }
    }
}