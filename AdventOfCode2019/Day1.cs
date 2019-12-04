using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2019
{
    public class Day1
    {
        public void Execute()
        {
            var masses = File.ReadAllLines("Day1Input.txt").Select(m => Convert.ToInt32(m));

            Part1(masses);
            Part2(masses);
        }

        public void Part1(IEnumerable<int> masses)
        {
            var fuelCalculator = new FuelCalculator();
            var fuel = masses.Sum(mass => fuelCalculator.Calculate(mass));
            
            Console.WriteLine($"{nameof(Day1)} {nameof(Part1)} = {fuel}");
        }

        public void Part2(IEnumerable<int> masses)
        {
            var compoundFuelCalculator = new CompoundFuelCalculator();
            var fuel = masses.Sum(mass => compoundFuelCalculator.Calculate(mass));

            Console.WriteLine($"{nameof(Day1)} {nameof(Part2)} = {fuel}");
        }

        public class FuelCalculator
        {
            public int Calculate(int mass) => (mass / 3) - 2;
        }

        public class CompoundFuelCalculator
        {
            public int Calculate(int mass)
            {
                var totalFuel = 0;

                var fuelCalculator = new FuelCalculator();
                var fuel = fuelCalculator.Calculate(mass);

                while (fuel > 0)
                {
                    totalFuel += fuel;
                    fuel = fuelCalculator.Calculate(fuel);
                }

                return totalFuel;
            }
        }
    }
}
