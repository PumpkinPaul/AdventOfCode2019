using NUnit.Framework;

namespace AdventOfCode2019.Tests.Unit
{
    [TestFixture]
    public class Day4Tests
    {
        [TestCase(111111)]
        [TestCase(22)]
        [TestCase(122345)]
        [TestCase(1134)]
        [TestCase(166456)]
        [TestCase(13356)]
        [TestCase(523996)]
        [TestCase(923377)]
        [TestCase(887)]
        public void RuleAdjacentDigits_WhenAdjacentDigits_ReturnsTrue(int value)
        {
            var rule = new Day4.RuleAdjacentDigits();
            var result = rule.IsValid(value);
            Assert.IsTrue(result);
        }

        [TestCase(123789)]
        [TestCase(1)]
        [TestCase(654321)]
        [TestCase(123456)]
        [TestCase(9898989)]
        public void RuleAdjacentDigits_WhenNoAdjacentDigits_ReturnsFalse(int value)
        {
            var rule = new Day4.RuleAdjacentDigits();
            var result = rule.IsValid(value);
            Assert.IsFalse(result);
        }

        [TestCase(111111)]
        [TestCase(111123)]
        [TestCase(135679)]
        [TestCase(11)]
        [TestCase(123456)]
        [TestCase(445666)]
        [TestCase(999999)]
        public void RuleSameOrIncreasingDigits_WhenDigitsSameOrIncreasing_ReturnsTrue(int value)
        {
            var rule = new Day4.RuleSameOrIncreasingDigits();
            var result = rule.IsValid(value);
            Assert.IsTrue(result);
        }

        [TestCase(223450)]
        [TestCase(65)]
        [TestCase(987654)]
        [TestCase(123454)]
        [TestCase(213456)]
        public void RuleSameOrIncreasingDigits_WhenDigitsDecreasing_ReturnsFalse(int value)
        {
            var rule = new Day4.RuleSameOrIncreasingDigits();
            var result = rule.IsValid(value);
            Assert.IsFalse(result);
        }

        [TestCase(112233)]
        [TestCase(111122)]
        [TestCase(112222)]
        [TestCase(122333)]
        [TestCase(123445)]
        public void RuleContainsIsolatedDoubleDigits_WhenContainsIsolatedDouble_ReturnsTrue(int value)
        {
            var rule = new Day4.RuleContainsIsolatedDoubleDigits();
            var result = rule.IsValid(value);
            Assert.IsTrue(result);
        }
        
        [TestCase(123444)]
        [TestCase(111456)]
        [TestCase(122226)]
        [TestCase(233336)]
        public void RuleContainsIsolatedDoubleDigits_WhenDoesNotContainsIsolatedDouble_ReturnsFalse(int value)
        {
            var rule = new Day4.RuleContainsIsolatedDoubleDigits();
            var result = rule.IsValid(value);
            Assert.IsFalse(result);
        }
    }
}
