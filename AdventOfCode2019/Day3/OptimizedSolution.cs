using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public static class OptimizedSolution
    {
        private static Dictionary<(int x, int y), int> GetPath(string input)
        {
            var r = new Dictionary<(int, int), int>();
            int x = 0, y = 0, pathLength = 0;
            foreach (var p in input.Split(","))
            {
                var dir = p[0];
                var dist = int.Parse(p[1..]);
                for (var d = 0; d < dist; d++)
                {
                    var newPoint = dir switch
                    {
                        'R' => (++x, y),
                        'D' => (x, --y),
                        'L' => (--x, y),
                        'U' => (x, ++y),
                        _ => throw new Exception()
                    };
                    r.TryAdd(newPoint, ++pathLength);
                }
            }

            return r;
        }

        public static void Solve(List<string> input)
        {
            var path1 = GetPath(input[0]);
            var path2 = GetPath(input[1]);

            var intersections = path1.Keys.Intersect(path2.Keys).ToArray();
            Console.WriteLine(intersections.Min(p => Math.Abs(p.x) + Math.Abs(p.y)));
            Console.WriteLine(intersections.Min(x => path1[x] + path2[x]));
        }
    }
}