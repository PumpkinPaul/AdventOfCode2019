using System;
using NUnit.Framework;

namespace AdventOfCode2019.Tests.Unit
{
    [TestFixture]
    public class Day6Tests
    {
        //     G - H          J - K - L
        //    /              /
        //COM - B - C - D - E - F
        //               \
        //                I

        [TestCase("COM)B,B)C,C)D,D)E,E)F,B)G,G)H,D)I,E)J,J)K,K)L", 42)]
        public void Part1_WhenGivenInput_ReturnsOutput(string puzzleInput, int expectedValue)
        {
            var target = new Day6();
            var result = target.Part1(puzzleInput.Split(new [] {','}, StringSplitOptions.None));

            Assert.AreEqual(expectedValue, result);
        }

        //                          YOU
        //                         /
        //        G - H       J - K - L
        //       /           /
        //COM - B - C - D - E - F
        //               \
        //                I - SAN

        [TestCase("COM)B,B)C,C)D,D)E,E)F,B)G,G)H,D)I,E)J,J)K,K)L,K)YOU,I)SAN", 4)]
        public void Part2_WhenGivenInput_ReturnsOutput(string puzzleInput, int expectedValue)
        {
            var input = puzzleInput.Split(new[] { ',' }, StringSplitOptions.None);
            var target = new Day6();
            var result = target.Part2(input, "YOU", "SAN");

            Assert.AreEqual(expectedValue, result);
        }
    }
}
