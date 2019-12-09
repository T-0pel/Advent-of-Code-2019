using System;
using System.Linq;
using SharedLibrary;

namespace Day2
{
    class Program
    {
        private const string DirectoryName = "Day2";

        static void Main(string[] args)
        {
            //Part1();
            Part2();
        }

        private static void Part2()
        {
            var lines = FileHelper.GetLines(DirectoryName);

            FindNounAndVerb();

            void FindNounAndVerb()
            {
                for (int noun = 0; noun < 100; noun++)
                {
                    for (int verb = 0; verb < 100; verb++)
                    {
                        var inputNumbers = lines.First().Split(',').Select(int.Parse).ToList();

                        inputNumbers[1] = noun;
                        inputNumbers[2] = verb;

                        var currentIndex = 0;
                        var opcode = inputNumbers[currentIndex];

                        while (opcode != 99)
                        {
                            if (opcode == 1)
                            {
                                inputNumbers[inputNumbers[currentIndex + 3]] =
                                    inputNumbers[inputNumbers[currentIndex + 1]] + inputNumbers[inputNumbers[currentIndex + 2]];
                            }
                            else
                            {
                                inputNumbers[inputNumbers[currentIndex + 3]] =
                                    inputNumbers[inputNumbers[currentIndex + 1]] * inputNumbers[inputNumbers[currentIndex + 2]];
                            }

                            currentIndex += 4;
                            opcode = inputNumbers[currentIndex];
                        }

                        if (inputNumbers[0] == 19690720)
                        {
                            Console.WriteLine($"Noun: {noun}, verb: {verb}");
                            return;
                        }
                    }
                }
            }
        }

        private static void Part1()
        {
            var lines = FileHelper.GetLines(DirectoryName);

            var inputNumbers = lines.First().Split(',').Select(int.Parse).ToList();

            inputNumbers[1] = 12;
            inputNumbers[2] = 2;

            var currentIndex = 0;
            var opcode = inputNumbers[currentIndex];

            while (opcode != 99)
            {
                if (opcode == 1)
                {
                    inputNumbers[inputNumbers[currentIndex + 3]] =
                        inputNumbers[inputNumbers[currentIndex + 1]] + inputNumbers[inputNumbers[currentIndex + 2]];
                }
                else
                {
                    inputNumbers[inputNumbers[currentIndex + 3]] =
                        inputNumbers[inputNumbers[currentIndex + 1]] * inputNumbers[inputNumbers[currentIndex + 2]];
                }

                currentIndex += 4;
                opcode = inputNumbers[currentIndex];
            }

            Console.WriteLine($"Position 0 {inputNumbers[0]}");
        }
    }
}
