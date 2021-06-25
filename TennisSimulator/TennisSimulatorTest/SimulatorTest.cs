using AutoFixture.NUnit3;
using Moq;
using NUnit.Framework;
using Shouldly;
using TennisSimulator;
using TennisSimulator.Deciders;
using TennisSimulator.Domain;
using TennisSimulator.PointAwarders;

namespace TennisSimulatorTest
{
    public class SimulatorTest
    {
        [Test, AutoData]
        public void ShouldReturnScoreWhenOver(
            Mock<IPointAwarder> mockPointAwarder,
            Mock<IDecider> mockDecider)
        {
            mockDecider.Setup(x => x.IsOver(It.IsAny<ScoreResult>())).Returns(true);

            var sut = new Simulator(mockPointAwarder.Object, mockDecider.Object, "test");

            var result = sut.Simulate();

            result.ShouldNotBe(null);
        }
    }
}