using System;
using TennisSimulator.Deciders;
using TennisSimulator.PointAwarders;

namespace TennisSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameSimulator = new Simulator(new RandomPointAwarder(), new GameDecider(), "Game");
            var setSimulator = new Simulator(new SimulatedPointAwarder(gameSimulator), new SetDecider(), "Set");
            var matchSimulator = new Simulator(new SimulatedPointAwarder(setSimulator), new MatchDecider(), "Match");

            matchSimulator.Simulate();

            Console.ReadLine();
        }
    }
}
