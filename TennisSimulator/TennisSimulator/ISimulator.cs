using TennisSimulator.Domain;

namespace TennisSimulator
{
    public interface ISimulator
    {
        ScoreResult Simulate();
    }
}