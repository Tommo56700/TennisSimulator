using TennisSimulator.Domain;

namespace TennisSimulator.PointAwarders
{
    public interface IPointAwarder
    {
        public void AwardPoint(ScoreResult scoreResult);
    }
}