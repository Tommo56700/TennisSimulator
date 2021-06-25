using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using TennisSimulator;

namespace TennisSimulatorTest
{
    public class GameDeciderTest
    {
        [Test]
        [TestCaseSource("TestCaseSourceData")]
        public void ShouldCorrectlyScoreGame(ScoreResult scoreResult, bool expected)
        {
            var sut = new GameDecider();

            var result = sut.IsOver(scoreResult);

            result.ShouldBe(expected);
        }

        // TODO: Split up
        public static IEnumerable<TestCaseData> TestCaseSourceData()
        {
            // 0 - 0
            yield return new TestCaseData(new ScoreResult(), false);

            // Mid game
            yield return new TestCaseData(new ScoreResult(3, 2), false);
            yield return new TestCaseData(new ScoreResult(2, 3), false);

            // Won game
            yield return new TestCaseData(new ScoreResult(4, 2), true);
            yield return new TestCaseData(new ScoreResult(2, 4), true);
            yield return new TestCaseData(new ScoreResult(4, 0), true);
            yield return new TestCaseData(new ScoreResult(0, 4), true);

            // Deuce
            yield return new TestCaseData(new ScoreResult(4, 4), false);
            yield return new TestCaseData(new ScoreResult(7, 7), false);

            // Deuce with Adv
            yield return new TestCaseData(new ScoreResult(5, 4), false);
            yield return new TestCaseData(new ScoreResult(7, 8), false);

            // Win after deuce
            yield return new TestCaseData(new ScoreResult(6, 4), true);
            yield return new TestCaseData(new ScoreResult(7, 9), true);
        }
    }
}