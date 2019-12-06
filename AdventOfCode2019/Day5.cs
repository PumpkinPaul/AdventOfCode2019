using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    public class Day5
    {
        public void Execute()
        {
            var input = new[]
            {
                3, 225, 1, 225, 6, 6, 1100, 1, 238, 225, 104, 0, 1, 191, 196, 224, 1001, 224, -85, 224, 4, 224, 1002,
                223, 8, 223, 1001,
                224, 4, 224, 1, 223, 224, 223, 1101, 45, 50, 225, 1102, 61, 82, 225, 101, 44, 39, 224, 101, -105, 224,
                224, 4, 224, 102, 8, 223, 223, 101,
                5, 224, 224, 1, 224, 223, 223, 102, 14, 187, 224, 101, -784, 224, 224, 4, 224, 102, 8, 223, 223, 101, 7,
                224, 224, 1, 224, 223, 223, 1001,
                184, 31, 224, 1001, 224, -118, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 2, 224, 1, 223, 224, 223, 1102,
                91, 18, 225, 2, 35, 110, 224, 101,
                -810, 224, 224, 4, 224, 102, 8, 223, 223, 101, 3, 224, 224, 1, 223, 224, 223, 1101, 76, 71, 224, 1001,
                224, -147, 224, 4, 224, 102, 8, 223,
                223, 101, 2, 224, 224, 1, 224, 223, 223, 1101, 7, 16, 225, 1102, 71, 76, 224, 101, -5396, 224, 224, 4,
                224, 1002, 223, 8, 223, 101, 5, 224,
                224, 1, 224, 223, 223, 1101, 72, 87, 225, 1101, 56, 77, 225, 1102, 70, 31, 225, 1102, 29, 15, 225, 1002,
                158, 14, 224, 1001, 224, -224, 224,
                4, 224, 102, 8, 223, 223, 101, 1, 224, 224, 1, 223, 224, 223, 4, 223, 99, 0, 0, 0, 677, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 1105, 0, 99999,
                1105, 227, 247, 1105, 1, 99999, 1005, 227, 99999, 1005, 0, 256, 1105, 1, 99999, 1106, 227, 99999, 1106,
                0, 265, 1105, 1, 99999, 1006, 0,
                99999, 1006, 227, 274, 1105, 1, 99999, 1105, 1, 280, 1105, 1, 99999, 1, 225, 225, 225, 1101, 294, 0, 0,
                105, 1, 0, 1105, 1, 99999, 1106, 0,
                300, 1105, 1, 99999, 1, 225, 225, 225, 1101, 314, 0, 0, 106, 0, 0, 1105, 1, 99999, 1007, 226, 226, 224,
                1002, 223, 2, 223, 1006, 224, 329,
                1001, 223, 1, 223, 8, 226, 677, 224, 1002, 223, 2, 223, 1005, 224, 344, 1001, 223, 1, 223, 107, 226,
                677, 224, 1002, 223, 2, 223, 1006, 224,
                359, 1001, 223, 1, 223, 8, 677, 677, 224, 1002, 223, 2, 223, 1005, 224, 374, 1001, 223, 1, 223, 1108,
                226, 226, 224, 1002, 223, 2, 223, 1005,
                224, 389, 1001, 223, 1, 223, 7, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 404, 101, 1, 223, 223, 7,
                226, 226, 224, 102, 2, 223, 223, 1006,
                224, 419, 1001, 223, 1, 223, 1108, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 434, 1001, 223, 1, 223,
                1107, 226, 226, 224, 1002, 223, 2, 223,
                1006, 224, 449, 1001, 223, 1, 223, 1007, 677, 677, 224, 102, 2, 223, 223, 1006, 224, 464, 1001, 223, 1,
                223, 107, 226, 226, 224, 1002, 223, 2,
                223, 1005, 224, 479, 101, 1, 223, 223, 1107, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 494, 1001,
                223, 1, 223, 1008, 677, 677, 224, 102, 2,
                223, 223, 1005, 224, 509, 101, 1, 223, 223, 107, 677, 677, 224, 102, 2, 223, 223, 1005, 224, 524, 1001,
                223, 1, 223, 1108, 677, 226, 224, 1002,
                223, 2, 223, 1005, 224, 539, 1001, 223, 1, 223, 7, 226, 677, 224, 102, 2, 223, 223, 1006, 224, 554,
                1001, 223, 1, 223, 8, 677, 226, 224, 1002,
                223, 2, 223, 1006, 224, 569, 101, 1, 223, 223, 108, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 584,
                1001, 223, 1, 223, 1107, 226, 677, 224,
                1002, 223, 2, 223, 1006, 224, 599, 101, 1, 223, 223, 1008, 226, 226, 224, 102, 2, 223, 223, 1005, 224,
                614, 1001, 223, 1, 223, 1007, 226, 677,
                224, 1002, 223, 2, 223, 1006, 224, 629, 1001, 223, 1, 223, 108, 677, 226, 224, 102, 2, 223, 223, 1005,
                224, 644, 101, 1, 223, 223, 1008, 226,
                677, 224, 1002, 223, 2, 223, 1005, 224, 659, 101, 1, 223, 223, 108, 677, 677, 224, 1002, 223, 2, 223,
                1006, 224, 674, 1001, 223, 1, 223, 4, 223, 99, 226
            };

            Part1(input);
            Part2(input);
        }

        public void Part1(int[] instructions)
        {
            const int airconditioningUnitId = 1;

            var program = new IntcodeProgram();
            program.Execute(instructions, airconditioningUnitId);

            Console.WriteLine($"{nameof(Day5)} {nameof(Part1)}");
            foreach (var item in program.Output)
                Console.WriteLine($"{item}");
        }

        public void Part2(int[] instructions)
        {
            const int thermalRadiatorControllerUnitId = 5;

            var program = new IntcodeProgram();
            program.Execute(instructions, thermalRadiatorControllerUnitId);

            Console.WriteLine($"{nameof(Day5)} {nameof(Part1)}");
            foreach (var item in program.Output)
                Console.WriteLine($"{item}");
        }

        public class IntcodeProgram
        {
            public abstract class Instruction
            {
                private readonly IReadOnlyList<int> _modes;

                public abstract int InstructionCount { get; }

                protected Instruction(IReadOnlyList<int> modes)
                {
                    _modes = modes;
                }

                public abstract int Execute(int[] memory, int instructionPointer);

                public int EvaluateParameter(int[] memory, int instructionPointer, int parameterOffset)
                {
                    const int positionMode = 0;
                    const int immediateMode = 1;

                    //Take off one for the actual instruction (e.g. Multiply, Add, etc)
                    var modeIndex = parameterOffset - 1;
                    var mode = modeIndex < _modes.Count
                        ? _modes[modeIndex]
                        : 0;

                    switch (mode)
                    {
                        case positionMode:  return memory[instructionPointer + parameterOffset];
                        case immediateMode: return instructionPointer + parameterOffset;
                        default:
                            throw new InvalidOperationException($"Unknown ParameterMode: {mode}");
                    }
                }

                private static int GetOpcodeLength(string instruction) => Math.Min(2, instruction.Length);

                private static int ParseOpcode(string instruction)
                {
                    var opcodeLength = GetOpcodeLength(instruction);

                    var parametersLength = instruction.Length - opcodeLength;
                    var op = instruction.Substring(parametersLength, opcodeLength);
                    return Convert.ToInt32(op);
                }

                private static IReadOnlyList<int> ParseModes(string instruction)
                {
                    var parametersLength = instruction.Length - GetOpcodeLength(instruction);
                    
                    var modesValues = instruction.Substring(0, parametersLength);
                    return Array.AsReadOnly(modesValues
                        .ToCharArray()
                        .Reverse()
                        .Select(c => (int)char.GetNumericValue(c)).ToArray());
                }

                public static Instruction Parse(int instruction, int input, List<int> output)
                {
                    var s = instruction.ToString();
                    var opcode = ParseOpcode(s);
                    var modes = ParseModes(s);

                    switch (opcode)
                    {
                        case  1: return new AddInstruction(modes);
                        case  2: return new MultiplyInstruction(modes);
                        case  3: return new SaveInstruction(modes, input);
                        case  4: return new OutputInstruction(modes, output);
                        case  5: return new JumpIfTrueInstruction(modes);
                        case  6: return new JumpIfFalseInstruction(modes);
                        case  7: return new IsLessThanInstruction(modes);
                        case  8: return new IsEqualInstruction(modes);
                        case 99: return new ExitInstruction(modes);
                        default:
                            throw new InvalidOperationException($"Unknown opcode {opcode}");
                    }
                }
            }

            public class AddInstruction : Instruction
            {
                public override int InstructionCount => 4;

                public AddInstruction(IReadOnlyList<int> modes) : base(modes)
                {
                }

                public override int Execute(int[] memory, int instructionPointer)
                {
                    var locationAddress = EvaluateParameter(memory, instructionPointer, parameterOffset: 3);
                    var parameter1Address = EvaluateParameter(memory, instructionPointer, parameterOffset: 1);
                    var parameter2Address = EvaluateParameter(memory, instructionPointer, parameterOffset: 2);
                    
                    memory[locationAddress] = memory[parameter1Address] + memory[parameter2Address];

                    return instructionPointer + InstructionCount;
                }
            }

            public class MultiplyInstruction : Instruction
            {
                public override int InstructionCount => 4;

                public MultiplyInstruction(IReadOnlyList<int> modes) : base(modes)
                {
                }

                public override int Execute(int[] memory, int instructionPointer)
                {
                    var locationAddress = EvaluateParameter(memory, instructionPointer, parameterOffset: 3);
                    var parameter1Address = EvaluateParameter(memory, instructionPointer, parameterOffset: 1);
                    var parameter2Address = EvaluateParameter(memory, instructionPointer, parameterOffset: 2);

                    memory[locationAddress] = memory[parameter1Address] * memory[parameter2Address];

                    return instructionPointer + InstructionCount;
                }
            }

            public class SaveInstruction : Instruction
            {
                private readonly int _input;

                public override int InstructionCount => 2;

                public SaveInstruction(IReadOnlyList<int> modes, int input) : base(modes)
                {
                    _input = input;
                }

                public override int Execute(int[] memory, int instructionPointer)
                {
                    var locationAddress = EvaluateParameter(memory, instructionPointer, parameterOffset: 1);

                    memory[locationAddress] = _input;

                    return instructionPointer + InstructionCount;
                }
            }

            public class OutputInstruction : Instruction
            {
                private List<int> _output;

                public override int InstructionCount => 2;

                public OutputInstruction(IReadOnlyList<int> modes, List<int> output) : base(modes)
                {
                    _output = output;
                }

                public override int Execute(int[] memory, int instructionPointer)
                {
                    var locationAddress = EvaluateParameter(memory, instructionPointer, parameterOffset: 1);

                    _output.Add(memory[locationAddress]);

                    return instructionPointer + InstructionCount;
                }
            }

            public class JumpIfTrueInstruction : Instruction
            {
                public override int InstructionCount => 3;

                public JumpIfTrueInstruction(IReadOnlyList<int> modes) : base(modes)
                {
                }

                public override int Execute(int[] memory, int instructionPointer)
                {
                    var parameter1 = EvaluateParameter(memory, instructionPointer, parameterOffset: 1);
                    var parameter2 = EvaluateParameter(memory, instructionPointer, parameterOffset: 2);

                    if (memory[parameter1] != 0)
                        return memory[parameter2];

                    return instructionPointer + InstructionCount;
                }
            }

            public class JumpIfFalseInstruction : Instruction
            {
                public override int InstructionCount => 3;

                public JumpIfFalseInstruction(IReadOnlyList<int> modes) : base(modes)
                {
                }

                public override int Execute(int[] memory, int instructionPointer)
                {
                    var parameter1 = EvaluateParameter(memory, instructionPointer, parameterOffset: 1);
                    var parameter2 = EvaluateParameter(memory, instructionPointer, parameterOffset: 2);

                    if (memory[parameter1] == 0)
                        return memory[parameter2];

                    return instructionPointer + InstructionCount;
                }
            }

            public class IsLessThanInstruction : Instruction
            {
                public override int InstructionCount => 4;

                public IsLessThanInstruction(IReadOnlyList<int> modes) : base(modes)
                {
                }

                public override int Execute(int[] memory, int instructionPointer)
                {
                    var parameter1 = EvaluateParameter(memory, instructionPointer, parameterOffset: 1);
                    var parameter2 = EvaluateParameter(memory, instructionPointer, parameterOffset: 2);
                    var parameter3 = EvaluateParameter(memory, instructionPointer, parameterOffset: 3);

                    if (memory[parameter1] < memory[parameter2])
                        memory[parameter3] = 1;
                    else
                        memory[parameter3] = 0;

                    return instructionPointer + InstructionCount;
                }
            }

            public class IsEqualInstruction : Instruction
            {
                public override int InstructionCount => 4;

                public IsEqualInstruction(IReadOnlyList<int> modes) : base(modes)
                {
                }

                public override int Execute(int[] memory, int instructionPointer)
                {
                    var parameter1 = EvaluateParameter(memory, instructionPointer, parameterOffset: 1);
                    var parameter2 = EvaluateParameter(memory, instructionPointer, parameterOffset: 2);
                    var parameter3 = EvaluateParameter(memory, instructionPointer, parameterOffset: 3);

                    if (memory[parameter1] == memory[parameter2])
                        memory[parameter3] = 1;
                    else
                        memory[parameter3] = 0;

                    return instructionPointer + InstructionCount;
                }
            }
            
            public class ExitInstruction : Instruction
            {
                public override int InstructionCount => 1;

                public ExitInstruction(IReadOnlyList<int> modes) : base(modes)
                {
                }

                public override int Execute(int[] memory, int instructionPointer)
                {
                    return memory.Length;
                }
            }

            public List<int> Output { get; } = new List<int>();

            public int[] Execute(IEnumerable<int> program, int input)
            {
                var memory = program.ToArray();
                Output.Clear();

                var instructionPointer = 0;

                while (instructionPointer < memory.Length)
                {
                    var instructionCode = memory[instructionPointer];
                    var instruction = Instruction.Parse(instructionCode, input, Output);

                    instructionPointer = instruction.Execute(memory, instructionPointer);
                }

                return memory;
            }
        }
    }
}


