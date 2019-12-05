using System;

namespace AdventOfCode2019
{
    public class Day2
    {
        public void Execute()
        {
            var input = new [] {1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 1, 13, 19, 2, 9, 19, 23, 1, 23, 6, 27, 1, 13, 27, 31,
                1, 31, 10, 35, 1, 9, 35, 39, 1, 39, 9, 43, 2, 6, 43, 47, 1, 47, 5, 51, 2, 10, 51, 55, 1, 6, 55, 59, 2,
                13, 59, 63, 2, 13, 63, 67, 1, 6, 67, 71, 1, 71, 5, 75, 2, 75, 6, 79, 1, 5, 79, 83, 1, 83, 6, 87, 2, 10,
                87, 91, 1, 9, 91, 95, 1, 6, 95, 99, 1, 99, 6, 103, 2, 103, 9, 107, 2, 107, 10, 111, 1, 5, 111, 115, 1,
                115, 6, 119, 2, 6, 119, 123, 1, 10, 123, 127, 1, 127, 5, 131, 1, 131, 2, 135, 1, 135, 5, 0, 99, 2, 0,
                14, 0};

            Part1(input);
            Part2(input);
        }

        public void Part1(int[] input)
        {
            var program = new IntcodeProgram();

            input[1] = 12;
            input[2] = 2;

            var output = program.Execute(input);
            Console.WriteLine($"{nameof(Day2)} {nameof(Part1)} = {output[0]}");
        }

        public void Part2(int[] input)
        {
            var program = new IntcodeProgram();

            for (var noun = 0; noun <= 99; noun++)
            {
                for (var verb = 0; verb <= 99; verb++)
                {
                    input[1] = noun;
                    input[2] = verb;

                    var output = program.Execute(input);

                    if (output[0] == 19690720)
                    {
                        Console.WriteLine($"{nameof(Day2)} {nameof(Part2)} = {100 * noun + verb}");
                        return;
                    }
                }
            }

            Console.WriteLine($"{nameof(Day2)} {nameof(Part2)} = NO ANSWER FOUND");
        }

        public static class Opcode
        {
            public const int Add = 1;
            public const int Multiply = 2;
            public const int Exit = 99;
        }

        public class IntcodeProgram
        {
            public int[] Execute(int[] input)
            {
                var memory = (int[])input.Clone();
                var instructionPointer = 0;

                while (instructionPointer < memory.Length)
                {
                    var opcode = memory[instructionPointer];
                    switch (opcode)
                    {
                        case Opcode.Add:
                            memory[memory[instructionPointer + 3]] = memory[memory[instructionPointer + 1]] + memory[memory[instructionPointer + 2]];
                            break;

                        case Opcode.Multiply:
                            memory[memory[instructionPointer + 3]] = memory[memory[instructionPointer + 1]] * memory[memory[instructionPointer + 2]];
                            break;

                        case Opcode.Exit:
                            instructionPointer = memory.Length;
                            break;

                        default:
                            throw new InvalidOperationException($"Unknown opcode {opcode}");
                    }

                    instructionPointer += 4;
                }

                return memory;
            }
        }
    }
}
