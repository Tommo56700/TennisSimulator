namespace TennisSimulator.Domain
{
    public class ScoreResult
    {
        public ScoreResult(int player1Score = 0, int player2Score = 0)
        {
            Player1Score = player1Score;
            Player2Score = player2Score;
        }

        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public bool Player1Win { get; set; }

        public override string ToString()
        {
            return Player1Win
                ? $"Player 1 wins: {Player1Score} - {Player2Score}"
                : $"Player 2 wins: {Player2Score} - {Player1Score}";
        }
    }
}