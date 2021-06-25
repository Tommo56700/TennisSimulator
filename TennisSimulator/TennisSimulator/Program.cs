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

    public class SetSimulator
    {
        private readonly GameSimulator _gameSimulator;

        public SetScore SimulateSet()
        {
            var setScore = new SetScore();

            while (!IsSetOver(setScore))
            {
                var gameResult = _gameSimulator.SimulateGame();
                AwardPoint(setScore, gameResult);
            }

            return setScore;
        }

        private void AwardPoint(SetScore setScore, GameScore gameResult)
        {
            if (gameResult.Player1Score - gameResult.Player2Score > 1)
                setScore.Player1Score++;
            else if (gameResult.Player2Score - gameResult.Player1Score > 1)
                setScore.Player2Score++;
        }

        private bool IsSetOver(SetScore setScore) => setScore.Player1Score >= 6 || setScore.Player2Score >= 6;
    }

    public class SetScore
    {
        public SetScore(int player1Score = 0, int player2Score = 0)
        {
            Player1Score = player1Score;
            Player2Score = player2Score;
        }

        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
    }
}
