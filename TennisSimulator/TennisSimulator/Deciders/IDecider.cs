using TennisSimulator.Domain;

namespace TennisSimulator.Deciders
{
    public interface IDecider
    {
        bool IsOver(ScoreResult scoreResult);
    }
}