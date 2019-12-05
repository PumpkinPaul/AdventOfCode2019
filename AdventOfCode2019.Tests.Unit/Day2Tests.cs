using NUnit.Framework;

namespace AdventOfCode2019.Tests.Unit
{
    [TestFixture]
    public class Day2Tests
    {
        [TestCase(new[] { 1,9,10,3,2,3,11,0,99,30,40,50 }, new[] { 3500,9,10,70,2,3,11,0,99,30,40,50 })]
        [TestCase(new [] {1,0,0,0,99}, new[] {2,0,0,0,99})]
        [TestCase(new[] {2,3,0,3,99}, new [] {2,3,0,6,99})]
        [TestCase(new [] {2,4,4,5,99,0}, new [] {2,4,4,5,99,9801})]
        [TestCase(new [] {1,1,1,4,99,5,6,0,99}, new [] {30,1,1,4,2,5,6,0,99})]
        public void IntcodeProgram_WhenGivenInput_ExecutesAndReturnsOutput(int[] input, int[] expectedOutput)
        {
            var target = new Day2.IntcodeProgram();

            var output = target.Execute(input);

            Assert.AreEqual(expectedOutput, output);
        }
    }
}
