namespace TennisSimulator
{
    public class GameDecider : IGameDecider
    {
        public bool IsGameOver(GameScore gameScore) =>
            HasPlayerWonGame(gameScore.Player1Score, gameScore.Player2Score) ||
            HasPlayerWonGame(gameScore.Player2Score, gameScore.Player1Score);

        private bool HasPlayerWonGame(int playerScore, int opponentScore) =>
            playerScore > 3 && playerScore - opponentScore > 1;
    }
}