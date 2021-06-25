using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using TennisSimulator;

namespace TennisSimulatorTest
{
    public class Tests
    {
        [Test]
        [TestCaseSource("TestCaseSourceData")]
        public void Test1(GameScore gameScore, bool expected)
        {
            var sut = new GameDecider();

            var result = sut.IsGameOver(gameScore);

            result.ShouldBe(expected);
        }

        public static IEnumerable<TestCaseData> TestCaseSourceData()
        {
            // 0 - 0
            yield return new TestCaseData(new GameScore(), false);

            // Mid game
            yield return new TestCaseData(new GameScore(3, 2), false);
            yield return new TestCaseData(new GameScore(2, 3), false);

            // Won game
            yield return new TestCaseData(new GameScore(4, 2), true);
            yield return new TestCaseData(new GameScore(2, 4), true);
            yield return new TestCaseData(new GameScore(4, 0), true);
            yield return new TestCaseData(new GameScore(0, 4), true);

            // Deuce
            yield return new TestCaseData(new GameScore(4, 4), false);
            yield return new TestCaseData(new GameScore(7, 7), false);

            // Deuce with Adv
            yield return new TestCaseData(new GameScore(5, 4), false);
            yield return new TestCaseData(new GameScore(7, 8), false);

            // Win after deuce
            yield return new TestCaseData(new GameScore(6, 4), true);
            yield return new TestCaseData(new GameScore(7, 9), true);
        }
    }
}