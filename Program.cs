using System.Text.RegularExpressions;

namespace AOC2025Day4
{
    public class Program
    {
        public static string PartOne(string data)
        {
            int movableRolls = 0;
            bool[,] rolls = new bool[Regex.Matches(data, Environment.NewLine).Count + 1, Regex.Matches(data, Environment.NewLine).Count + 1];
            int loading_y = 0;
            foreach (string line in data.Split(Environment.NewLine))
            {
                int loading_x = 0;
                foreach (char spot in line)
                {
                    if (spot == '@')
                    {
                        rolls[loading_x, loading_y] = true;
                    }
                    loading_x++;
                }
                loading_y++;
            }
            for (int x = 0; x < Regex.Matches(data, Environment.NewLine).Count + 1; x++)
            {
                for (int y = 0; y < Regex.Matches(data, Environment.NewLine).Count + 1; y++)
                {
                    if (rolls[x, y])
                    {
                        int neighbours = 0;
                        for (int x_offset = -1; x_offset <= 1; x_offset++)
                        {
                            for (int y_offset = -1; y_offset <= 1; y_offset++)
                            {
                                if (0 <= x + x_offset && x + x_offset < Regex.Matches(data, Environment.NewLine).Count + 1 && 0 <= y + y_offset && y + y_offset < Regex.Matches(data, Environment.NewLine).Count + 1)
                                {
                                    if (rolls[x + x_offset, y + y_offset])
                                    {
                                        neighbours++;
                                    }
                                }
                            }
                        }
                        if (neighbours < 4)
                        {
                            movableRolls++;
                        }
                    }
                }
            }
            return Convert.ToString(movableRolls);
        }
        public static string PartTwo(string data)
        {
            return "";
        }
        static void Main()
        {
            string file = File.ReadAllText(@"../../../input.txt");
            Console.WriteLine(PartOne(@"..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@."));
            Console.WriteLine(PartOne(file));
            Console.WriteLine(PartTwo(file));
        }
    }
}
