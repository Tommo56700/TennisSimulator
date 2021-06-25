using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using TennisSimulator.Deciders;
using TennisSimulator.Domain;

namespace TennisSimulatorTest
{
    public class SetDeciderTest
    {
        [Test]
        [TestCaseSource(nameof(MidSet))]
        [TestCaseSource(nameof(WonSet))]
        [TestCaseSource(nameof(DrawingSet))]
        [TestCaseSource(nameof(AdvantageSet))]
        [TestCaseSource(nameof(WinAfterDrawingSet))]
        public void ShouldCorrectlyScoreSet(ScoreResult scoreResult, bool expected)
        {
            var sut = new SetDecider();

            var result = sut.IsOver(scoreResult);

            result.ShouldBe(expected);
        }

        public static IEnumerable<TestCaseData> MidSet()
        {
            yield return new TestCaseData(new ScoreResult(), false);
            yield return new TestCaseData(new ScoreResult(3, 2), false);
            yield return new TestCaseData(new ScoreResult(2, 3), false);
            yield return new TestCaseData(new ScoreResult(5, 0), false);
            yield return new TestCaseData(new ScoreResult(0, 5), false);
        }

        public static IEnumerable<TestCaseData> WonSet()
        {
            yield return new TestCaseData(new ScoreResult(6, 2), true);
            yield return new TestCaseData(new ScoreResult(2, 6), true);
            yield return new TestCaseData(new ScoreResult(6, 0), true);
            yield return new TestCaseData(new ScoreResult(0, 6), true);
        }

        public static IEnumerable<TestCaseData> DrawingSet()
        {
            yield return new TestCaseData(new ScoreResult(4, 4), false);
            yield return new TestCaseData(new ScoreResult(7, 7), false);
        }

        public static IEnumerable<TestCaseData> AdvantageSet()
        {
            yield return new TestCaseData(new ScoreResult(6, 7), false);
            yield return new TestCaseData(new ScoreResult(7, 6), false);
        }

        public static IEnumerable<TestCaseData> WinAfterDrawingSet()
        {
            yield return new TestCaseData(new ScoreResult(6, 8), true);
            yield return new TestCaseData(new ScoreResult(8, 6), true);
        }
    }
}