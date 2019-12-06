using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2019
{
    public class Day6
    {
        public void Execute()
        {
            var puzzleInput = File.ReadLines("Day6Input.txt");

            var result = Part1(puzzleInput);
            Console.WriteLine($"{nameof(Day6)} {nameof(Part1)} Result: {result}");
        }

        public int Part1(IEnumerable<string> lines)
        {
            var parents = new Dictionary<string, List<string>>();
            
            //Parse the file
            foreach (var line in lines)
            {
                var items = line.Split(')');
                var parent = items[0];
                var child = items[1];

                if (!parents.ContainsKey(parent))
                {
                    parents.Add(parent, new List<string>());
                }
                parents[parent].Add(child);
                
                Console.WriteLine($"{parent}->{child}");
            }

            //Count the tree
            return parents.Keys.Sum(key => Count(parents, key));
        }

        private static int Count(IReadOnlyDictionary<string, List<string>> parents, string key)
        {
            var count = 0;
            
            //If this is a leaf node it's not a parent so we can bail
            if (!parents.ContainsKey(key))
                return count;

            //Get children for this parent...
            var children = parents[key];
            //...count them...
            count += children.Count;
            //...recurse into this child's' children so we can also count them...
            count += children.Sum(child => Count(parents, child));

            return count;
        }
    }
}


