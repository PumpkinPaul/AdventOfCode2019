using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AdventOfCode2019.Tests.Unit
{
    [TestFixture]
    public class Day5Tests
    {
        [TestCase(1002, typeof(Day5.IntcodeProgram.MultiplyInstruction))]
        [TestCase(1301, typeof(Day5.IntcodeProgram.AddInstruction))]
        [TestCase(131303, typeof(Day5.IntcodeProgram.SaveInstruction))]
        [TestCase(10104, typeof(Day5.IntcodeProgram.OutputInstruction))]
        [TestCase(99, typeof(Day5.IntcodeProgram.ExitInstruction))]

        public void InstructionParse_WhenGivenInput_ReturnsInstruction(int instructionCode, Type expectedInstruction)
        {
            var instruction = Day5.IntcodeProgram.Instruction.Parse(instructionCode, 1, new List<int>());

            Assert.AreEqual(expectedInstruction, instruction.GetType());
        }

        [TestCase(new [] {1002, 4, 3, 4, 33}, new []{ 1002, 4, 3, 4, 99})]
        public void IntcodeProgramExecute_WhenRunWithInput_ReturnsMemory(int[] program, int[] expectedMemory)
        {
            var target = new Day5.IntcodeProgram();
            var memory = target.Execute(program, 1);

            Assert.AreEqual(expectedMemory, memory);
        }

        //Position mode
        [TestCase(new[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, 7, 0)]
        [TestCase(new[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, 8, 1)]
        [TestCase(new[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, 9, 0)]
        //Immediate mode
        [TestCase(new[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 }, 7, 0)]
        [TestCase(new[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 }, 8, 1)]
        [TestCase(new[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 }, 9, 0)]
        public void IntcodeProgramExecute_IsEqualTest(int[] program, int input, int expectedResult)
        {
            var target = new Day5.IntcodeProgram();
            target.Execute(program, input);

            Assert.AreEqual(expectedResult, target.Output[0]);
        }

        //Position mode
        [TestCase(new[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 }, 7, 1)]
        [TestCase(new[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 }, 8, 0)]
        [TestCase(new[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 }, 9, 0)]
        //Immediate mode
        [TestCase(new[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 }, 7, 1)]
        [TestCase(new[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 }, 8, 0)]
        [TestCase(new[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 }, 9, 0)]
        public void IntcodeProgramExecute_IsLessThanTest(int[] program, int input, int expectedResult)
        {
            var target = new Day5.IntcodeProgram();
            target.Execute(program, input);

            Assert.AreEqual(expectedResult, target.Output[0]);
        }

        //Position mode
        [TestCase(new[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 }, 0, 0)]
        [TestCase(new[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 }, 1, 1)]
        [TestCase(new[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 }, 2, 1)]
        //Immediate mode
        [TestCase(new[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 }, 0, 0)]
        [TestCase(new[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 }, 1, 1)]
        [TestCase(new[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 }, 2, 1)]
        public void IntcodeProgramExecute_JumpTest(int[] program, int input, int expectedResult)
        {
            var target = new Day5.IntcodeProgram();
            target.Execute(program, input);

            Assert.AreEqual(expectedResult, target.Output[0]);
        }
    }
}
