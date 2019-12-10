using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Day3
{
    class Program
    {
        private static HashSet<Vector2> PositionsWire1 = new HashSet<Vector2>();
        private static HashSet<Vector2> PositionsWire2 = new HashSet<Vector2>();

        private static HashSet<Point> Points1 = new HashSet<Point>();
        private static HashSet<Point> Points2 = new HashSet<Point>();

        private const string DirectoryName = "Day3";

        static void Main(string[] args)
        {
            //Part2();
            OptimizedSolution.Solve(FileHelper.GetLines(DirectoryName).ToList());
        }

        private static void Part2()
        {
            var lines = FileHelper.GetLines(DirectoryName).ToList();

            FillPositionsPart2(lines[0], Points1);
            FillPositionsPart2(lines[1], Points2);

            Points1.IntersectWith(Points2);
            var combinedSteps = new HashSet<int>();
            foreach (var point in Points1)
            {
                Points2.TryGetValue(point, out var point2);
                combinedSteps.Add(point.StepCount + point2.StepCount);
            }

            var closestIntersection = combinedSteps.Min();

            Console.WriteLine($"Minimum combined steps are: {closestIntersection}");
        }

        private static void FillPositionsPart2(string line, HashSet<Point> positions)
        {
            var instructions = line.Split(',');
            var currentPosition = new Vector2(0, 0);
            var stepCount = 0;
            foreach (var instruction in instructions)
            {
                var direction = instruction[0];
                var count = int.Parse(instruction.Substring(1));

                for (int i = 1; i <= count; i++)
                {
                    stepCount++;
                    Vector2 newPosition = default;

                    switch (direction)
                    {
                        case 'R':
                            newPosition = new Vector2(currentPosition.X + i, currentPosition.Y);
                            break;
                        case 'U':
                            newPosition = new Vector2(currentPosition.X, currentPosition.Y + i);
                            break;
                        case 'L':
                            newPosition = new Vector2(currentPosition.X - i, currentPosition.Y);
                            break;
                        case 'D':
                            newPosition = new Vector2(currentPosition.X, currentPosition.Y - i);
                            break;
                    }

                    positions.Add(new Point { Position = newPosition, StepCount = stepCount });
                    if (i == count) currentPosition = newPosition;
                }
            }
        }

        private static void Part1()
        {
            var lines = FileHelper.GetLines(DirectoryName).ToList();

            FillPositions(lines[0], PositionsWire1);
            FillPositions(lines[1], PositionsWire2);

            PositionsWire1.IntersectWith(PositionsWire2);

            var closestIntersection = PositionsWire1.Min(p => Math.Abs(p.X) + Math.Abs(p.Y));

            Console.WriteLine($"Closest intersection is: {closestIntersection}");
        }

        private static void FillPositions(string line, HashSet<Vector2> positions)
        {
            var instructions = line.Split(',');
            var currentPosition = new Vector2(0, 0);
            foreach (var instruction in instructions)
            {
                var direction = instruction[0];
                var count = int.Parse(instruction.Substring(1));

                for (int i = 1; i <= count; i++)
                {
                    Vector2 newPosition = default;

                    switch (direction)
                    {
                        case 'R':
                            newPosition = new Vector2(currentPosition.X + i, currentPosition.Y);
                            break;
                        case 'U':
                            newPosition = new Vector2(currentPosition.X, currentPosition.Y + i);
                            break;
                        case 'L':
                            newPosition = new Vector2(currentPosition.X - i, currentPosition.Y);
                            break;
                        case 'D':
                            newPosition = new Vector2(currentPosition.X, currentPosition.Y - i);
                            break;
                    }

                    positions.Add(newPosition);
                    if (i == count) currentPosition = newPosition;
                }
            }
        }


        //private static void Part2()
        //{
        //    var lines = FileHelper.GetLines(DirectoryName).ToList();

        //    var intersectionFound = false;
        //    var step = 0;
        //    var positionWire1 = new Vector2(0, 0);
        //    var positionWire2 = new Vector2(0, 0);

        //    var instructions1 = lines[0].Split(',');
        //    var instructions2 = lines[1].Split(',');

        //    var currentInstruction1Index = 0;
        //    var currentInstruction2Index = 0;

        //    var instruction1StepsLeft = instructions1[currentInstruction1Index].Substring(1);
        //    var instruction1StepsLeft = instructions1[currentInstruction1Index].Substring(1);

        //    while (!intersectionFound)
        //    {
        //        step++;

        //        positionWire1 = GetNewPosition(positionWire1, )
        //    }
        //}

        //private static Vector2 GetNewPosition(Vector2 currentPosition, char direction)
        //{
        //    var newPosition = new Vector2();
        //    switch (direction)
        //    {
        //        case 'R':
        //            newPosition = new Vector2(currentPosition.X + 1, currentPosition.Y);
        //            break;
        //        case 'U':
        //            newPosition = new Vector2(currentPosition.X, currentPosition.Y + 1);
        //            break;
        //        case 'L':
        //            newPosition = new Vector2(currentPosition.X - 1, currentPosition.Y);
        //            break;
        //        case 'D':
        //            newPosition = new Vector2(currentPosition.X, currentPosition.Y - 1);
        //            break;
        //    }

        //    return newPosition;
        //}
    }
}
