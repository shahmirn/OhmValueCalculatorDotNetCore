using NUnit.Framework;
using FluentAssertions;
using OhmValueCalculator.Domain;
using OhmValueCalculator.Services;

namespace OhmValueCalculator.Tests
{
    [TestFixture]
    public class OhmValueCalculatorTest
    {
        [Test]
        public void ShouldCorrectlyCalculateOhmValue()
        {
            IOhmValueCalculator ohmValueCalculator = new OhmValueCalculatorImpl();
            OhmValue ohmValue = ohmValueCalculator.CalculateOhmValue("red", "violet", "green", "brown");

            ohmValue.Resistance.Should().Be(2700000);
            ohmValue.Minimum.Should().Be(2673000);
            ohmValue.Maximum.Should().Be(2727000);
        }

        [Test]
        public void ShouldReturnNullForBandColorThatHasNoSigFigs()
        {
            IOhmValueCalculator ohmValueCalculator = new OhmValueCalculatorImpl();
            OhmValue ohmValue = ohmValueCalculator.CalculateOhmValue("pink", "violet", "green", "brown");

            ohmValue.Should().BeNull();
        }

        [Test]
        public void ShouldReturnNullForBandColorThatHasNoTolerance()
        {
            IOhmValueCalculator ohmValueCalculator = new OhmValueCalculatorImpl();
            OhmValue ohmValue = ohmValueCalculator.CalculateOhmValue("red", "violet", "green", "orange");

            ohmValue.Should().BeNull();
        }

        [Test]
        public void ShouldReturnNullForInvalidColor()
        {
            IOhmValueCalculator ohmValueCalculator = new OhmValueCalculatorImpl();
            OhmValue ohmValue = ohmValueCalculator.CalculateOhmValue("red", "violet", "indigo", "brown");

            ohmValue.Should().BeNull();
        }
    }
}
