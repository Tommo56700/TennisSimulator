namespace TennisSimulator
{
    public interface IGameDecider
    {
        bool IsGameOver(GameScore gameScore);
    }
}