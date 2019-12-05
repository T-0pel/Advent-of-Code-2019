using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day1
{
    internal class Program
    {
        private const string DirectoryName = "Day1";

        private static void Main(string[] args)
        {
            var lines = FileHelper.GetLines(DirectoryName);

            var masses = lines.Select(int.Parse).ToList();

            Console.WriteLine(CalculateFuel(masses));

            var totalFuel = 0;
            foreach (var mass in masses)
            {
                totalFuel += CalculateFuelRecursively(mass, 0);
            }

            Console.WriteLine(totalFuel);
        }

        private static int CalculateFuel(List<int> masses)
        {
            var totalFuel = 0;

            foreach (var mass in masses)
            {
                var fuel = mass / 3 - 2;
                totalFuel += fuel;
            }

            return totalFuel;
        }

        private static int CalculateFuelRecursively(int mass, int fuelCost)
        {
            var fuel = mass / 3 - 2;
            if (fuel <= 0)
            {
                return fuelCost;
            }
            else
            {
                return CalculateFuelRecursively(fuel, fuelCost + fuel);
            }
        }

        private static int CalculateFuelWithCycle(int mass, int fuelCost)
        {
            while (true)
            {
                var fuel = mass / 3 - 2;
                if (fuel <= 0)
                {
                    return fuelCost;
                }
                else
                {
                    mass = fuel;
                    fuelCost += fuel;
                }
            }
        }
    }
}
