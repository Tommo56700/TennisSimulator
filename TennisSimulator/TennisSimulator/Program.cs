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
}
