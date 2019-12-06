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

            result = Part2(puzzleInput, "YOU", "SAN");
            Console.WriteLine($"{nameof(Day6)} {nameof(Part2)} Result: {result}");
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

        public int Part2(IEnumerable<string> lines, string source, string target)
        {
            var parents = new Dictionary<string, List<string>>();
            var children = new Dictionary<string, string>();

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
                children[child] = parent;
            }

            var sourceRoute = GetRouteToCentreOfMass(children, source);
            var targetRoute = GetRouteToCentreOfMass(children, target);

            var nearestCommonAncester = sourceRoute
                .Intersect(targetRoute)
                .First();

            var sourceIndex = sourceRoute.IndexOf(nearestCommonAncester);
            var targetIndex = targetRoute.IndexOf(nearestCommonAncester);

            var totalTransfers = sourceIndex + targetIndex;

            return totalTransfers;
        }

        /// <summary>
        /// Gets a list of all the bodies from a target to the universal Centre of Mass (COM) by traversing up the 'tree'
        /// </summary>
        private List<string> GetRouteToCentreOfMass(Dictionary<string, string> children, string key)
        {
            var route = new List<string>();

            children.TryGetValue(key, out var parent);

            while (parent != null)
            {
                route.Add(parent);

                children.TryGetValue(parent, out parent);
            }

            return route;
        }

        /// <summary>
        /// Recursively count the children for a source key (the source key is the name of a body in the universe).
        /// </summary>
        private static int Count(IReadOnlyDictionary<string, List<string>> parents, string key)
        {
            if (!parents.TryGetValue(key, out var children))
                return 0;

            //Count the children and the children of the children (until no more children)...
            return children.Count + children.Sum(child => Count(parents, child));
        }
    }
}


