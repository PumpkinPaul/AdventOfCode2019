using NUnit.Framework;

namespace AdventOfCode2019.Tests.Unit
{
    [TestFixture]
    public class Day1Tests
    {
        [TestCase(12, 2)]
        [TestCase(14, 2)]
        [TestCase(1969, 654)]
        [TestCase(100756, 33583)]

        public void FuelCalculator_WhenGivenMass_ReturnsFuelRequirements(int mass, int expectedFuel)
        {
            var target = new Day1.FuelCalculator();

            var result = target.Calculate(mass);
            Assert.AreEqual(expectedFuel, result);
        }

        [TestCase(14, 2)]
        [TestCase(1969, 966)]
        [TestCase(100756, 50346)]

        public void CompoundFuelCalculator_WhenGivenMass_ReturnsFuelRequirements(int mass, int expectedFuel)
        {
            var target = new Day1.CompoundFuelCalculator();

            var result = target.Calculate(mass);
            Assert.AreEqual(expectedFuel, result);
        }
    }
}
