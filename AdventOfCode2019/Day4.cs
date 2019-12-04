using System;
using System.Linq;

namespace AdventOfCode2019
{
    public class Day4
    {
        //Paul
        private const int StartRange = 123257;
        private const int EndRange = 647015;

        //Dave
        //private const int StartRange = 147981;
        //private const int EndRange = 691423;

        public void Execute()
        {
            ExecutePart1();
            ExecutePart2();
        }

        public void ExecutePart1()
        {
            var rules = new IRule[]
            {
                new RuleAdjacentDigits(),
                new RuleSameOrIncreasingDigits()
            };

            var validPasswordCount = 0;

            //Simply brute force through all of the values and check against all the rules.
            //Only values where all the rules pass are considered potential passwords
            for (var i = StartRange; i <= EndRange; i++)
            {
                if (rules.Any(r => !r.IsValid(i)))
                    continue;

                validPasswordCount++;
            }

            Console.WriteLine($"Day4 Part1 = {validPasswordCount}");
        }

        public void ExecutePart2()
        {
            var rules = new IRule[]
            {
                new RuleContainsIsolatedDoubleDigits(),
                new RuleSameOrIncreasingDigits()
            };

            //Using Linq instead
            const int count = EndRange - StartRange + 1;
            var invalidCount = Enumerable
                .Range(StartRange, count)
                .Count(value => rules.Any(rule => !rule.IsValid(value)));

            Console.WriteLine($"Day4 Part2 = {count - invalidCount}");
        }

        public interface IRule
        {
            bool IsValid(int value);
        }

        //Rule - Two adjacent digits are the same (like 22 in 122345).
        public class RuleAdjacentDigits : IRule
        {
            public bool IsValid(int value)
            {
                var input = value.ToString();

                for (var i = 0; i < input.Length - 1; i += 1)
                {
                    if (input[i] == input[i + 1])
                        return true;
                }

                return false;
            }
        }

        //Going from left to right, the digits never decrease; they only ever increase or stay the same(like 111123 or 135679).
        public class RuleSameOrIncreasingDigits : IRule
        {
            public bool IsValid(int value)
            {
                var input = value.ToString();

                for (var i = 0; i < input.Length - 1; i += 1)
                {
                    var digit1 = input[i];
                    var digit2 = input[i + 1];
                    if (digit2 < digit1)
                        return false;
                }

                return true;
            }
        }

        //The two adjacent matching digits are not part of a larger group of matching digits.
        //e.g.
        //112233 meets these criteria because the digits never decrease and all repeated digits are exactly two digits long.
        //123444 no longer meets the criteria(the repeated 44 is part of a larger group of 444).
        //111122 meets the criteria(even though 1 is repeated more than twice, it still contains a double 22).
        public class RuleContainsIsolatedDoubleDigits : IRule
        {
            public bool IsValid(int value)
            {
                var input = $"X{value}X"; //pad start and end to simplify checks at beginning and end of input

                for (var i = 0; i < input.Length - 3; i++)
                {
                    var digit1 = input[i];
                    var digit2 = input[i + 1];
                    var digit3 = input[i + 2];
                    var digit4 = input[i + 3];

                    if (digit1 != digit2 && digit2 == digit3 && digit3 != digit4)
                        return true;
                }

                return false;
            }
        }
    }
}
