namespace TennisSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameSimulator = new GameSimulator(new RandomGamePointAwarder());

            var gameScore = gameSimulator.SimulateGame();
        }
    }
}
