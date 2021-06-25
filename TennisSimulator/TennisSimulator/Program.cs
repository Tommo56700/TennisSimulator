using System;
using TennisSimulator.Deciders;
using TennisSimulator.PointAwarders;

namespace TennisSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameSimulator = new Simulator(new GamePointAwarder(), new GameDecider());
            var setSimulator = new Simulator(new SetPointAwarder(gameSimulator), new SetDecider());
            var matchSimulator = new Simulator(new MatchPointAwarder(setSimulator), new MatchDecider());

            var matchResult = matchSimulator.Simulate();

            Console.WriteLine(matchResult.ToString());
            Console.ReadLine();
        }
    }
}
