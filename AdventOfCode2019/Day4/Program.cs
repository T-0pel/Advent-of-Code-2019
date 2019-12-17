using System;

namespace Day4
{
    internal class Program
    {
        //private const int Start = 147981;
        //private const int End = 691423;

        private const int Start = 0;
        private const int End = int.MaxValue;

        private static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        private static void Part2()
        {
            var meetsCriteria = 0;
            for (var password = Start; password < End; password++)
            {
                var passwordString = password.ToString();
                var hasDouble = false;
                var isValid = true;
                for (var i = 0; i < passwordString.Length - 1; i++)
                {
                    if (passwordString[i + 1] < passwordString[i]) isValid = false;

                    if (!hasDouble)
                    {
                        var repeat = 0;
                        for (var j = i + 1; j < passwordString.Length; j++)
                        {
                            if (passwordString[i] == passwordString[j])
                            {
                                repeat++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (repeat == 1) hasDouble = true;

                        if (repeat > 1)
                        {
                            i += repeat - 1;
                        }
                    }
                }

                if (isValid && hasDouble)
                {
                    meetsCriteria++;
                }
            }

            Console.WriteLine(meetsCriteria);
        }

        private static void Part1()
        {
            var meetsCriteria = 0;
            for (var password = Start; password < End; password++)
            {
                var passwordString = password.ToString();
                var hasDouble = false;
                var isValid = true;
                for (int i = 0; i < passwordString.Length - 1; i++)
                {
                    if (!hasDouble)
                    {
                        if (passwordString[i] == passwordString[i + 1]) hasDouble = true;
                    }

                    if (passwordString[i + 1] < passwordString[i])
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid && hasDouble) meetsCriteria++;
            }

            Console.WriteLine(meetsCriteria);
        }
    }
}
