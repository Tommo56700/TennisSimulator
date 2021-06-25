using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using TennisSimulator.Deciders;
using TennisSimulator.Domain;

namespace TennisSimulatorTest
{
    public class MatchDeciderTests
    {
        [Test]
        [TestCaseSource(nameof(MidMatch))]
        [TestCaseSource(nameof(WonMatch))]
        [TestCaseSource(nameof(DrawingMatch))]
        public void ShouldCorrectlyScoreMatch(ScoreResult scoreResult, bool expected)
        {
            var sut = new MatchDecider();

            var result = sut.IsOver(scoreResult);

            result.ShouldBe(expected);
        }

        public static IEnumerable<TestCaseData> MidMatch()
        {
            yield return new TestCaseData(new ScoreResult(), false);
            yield return new TestCaseData(new ScoreResult(1, 0), false);
            yield return new TestCaseData(new ScoreResult(1, 0), false);
        }

        public static IEnumerable<TestCaseData> WonMatch()
        {
            yield return new TestCaseData(new ScoreResult(2, 0), true);
            yield return new TestCaseData(new ScoreResult(0, 2), true);
            yield return new TestCaseData(new ScoreResult(2, 1), true);
            yield return new TestCaseData(new ScoreResult(1, 2), true);
        }

        public static IEnumerable<TestCaseData> DrawingMatch()
        {
            yield return new TestCaseData(new ScoreResult(1, 1), false);
        }
    }
}