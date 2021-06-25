namespace TennisSimulator
{
    public interface IDecider
    {
        bool IsOver(ScoreResult matchScore);
    }
}