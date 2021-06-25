using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using TennisSimulator.Deciders;
using TennisSimulator.Domain;

namespace TennisSimulatorTest
{
    public class GameDeciderTest
    {
        [Test]
        [TestCaseSource(nameof(MidGame))]
        [TestCaseSource(nameof(WonGame))]
        [TestCaseSource(nameof(DeuceGame))]
        [TestCaseSource(nameof(DeuceWithAdvGame))]
        [TestCaseSource(nameof(WinAfterDeuceGame))]
        public void ShouldCorrectlyScoreGame(ScoreResult scoreResult, bool expected)
        {
            var sut = new GameDecider();

            var result = sut.IsOver(scoreResult);

            result.ShouldBe(expected);
        }

        public static IEnumerable<TestCaseData> MidGame()
        {
            yield return new TestCaseData(new ScoreResult(), false);
            yield return new TestCaseData(new ScoreResult(3, 2), false);
            yield return new TestCaseData(new ScoreResult(2, 3), false);
        }

        public static IEnumerable<TestCaseData> WonGame()
        {
            yield return new TestCaseData(new ScoreResult(4, 2), true);
            yield return new TestCaseData(new ScoreResult(2, 4), true);
            yield return new TestCaseData(new ScoreResult(4, 0), true);
            yield return new TestCaseData(new ScoreResult(0, 4), true);
        }

        public static IEnumerable<TestCaseData> DeuceGame()
        {
            yield return new TestCaseData(new ScoreResult(4, 4), false);
            yield return new TestCaseData(new ScoreResult(7, 7), false);
        }

        public static IEnumerable<TestCaseData> DeuceWithAdvGame()
        {
            yield return new TestCaseData(new ScoreResult(5, 4), false);
            yield return new TestCaseData(new ScoreResult(7, 8), false);
        }

        public static IEnumerable<TestCaseData> WinAfterDeuceGame()
        {
            yield return new TestCaseData(new ScoreResult(6, 4), true);
            yield return new TestCaseData(new ScoreResult(7, 9), true);
        }
    }
}