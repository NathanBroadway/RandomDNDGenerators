using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringFilter
{
    public class DiceRoller
    {
        public static string RollDice(string line, Random random=null)
        {
            if (random == null) random = new Random();
            foreach (var word in line.Split(" "))
            {
                if (!new Regex(@"\d+d\d+").IsMatch(word)) continue;

                var excess = "";
                var splitDice = word.Split("d");
                var result = 0;

                for (var i = 0; i < int.Parse(splitDice[0]); i++)
                {
                    if (!int.TryParse(splitDice[1], out var highRoll))
                    {
                        excess = splitDice[1].Last().ToString();
                        int.TryParse(splitDice[1][..(splitDice.Length - 1)], out highRoll);
                    }

                    result += random.Next(1, highRoll + 1);
                }

                line = line.Replace(word, result + excess);
            }

            return line;
        }

        public static int Roll(int bot, int top)
        {
            return new Random().Next(bot, top + 1);
        }
    }
}