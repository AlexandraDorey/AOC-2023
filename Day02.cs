using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2023;
public static class Day02
{
    public static int step1()
    {
        var input = File.ReadAllLines("data\\aco2.txt");

        int red = 12;
        int green = 13;
        int blue = 14;

        int runningtotal = 0;

        foreach (var game in input)
        {
            int id = 0;
            switch(game.IndexOf(':')) 
            {
                case 6:
                    id = game[5] - 48;
                    break;
                case 7:
                    id += ((game[5] - 48) * 10) + (game[6] - 48);
                    break;
                case 8:
                    id = 100;
                    break;
            }
            var splits = game.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            bool fail = false;
            for (int x = 0; x < splits.Length; x++)
            {
                if (splits[x].StartsWith("red"))
                {
                    var res = Int32.Parse(splits[x - 1]);
                    if (res > red)
                    {
                        fail = true;
                        break;
                    }
                }
                if (splits[x].StartsWith("green"))
                {
                    var res = Int32.Parse(splits[x - 1]);
                    if (res > green)
                    {
                        fail = true;
                        break;
                    }
                }
                if (splits[x].StartsWith("blue"))
                {
                    var res = Int32.Parse(splits[x - 1]);
                    if (res > blue)
                    {
                        fail = true;
                        break;
                    }
                }
            }

            if(!fail)
            {
                runningtotal += id;
            }
        }

        return runningtotal;
    }

    public static int step2()
    {

        var input = File.ReadAllLines("data\\aco2.txt");
        int runningtotal = 0;

        foreach (var game in input)
        {
            var splits = game.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int red = 0;
            int green = 0;
            int blue = 0;

            for (int x = 0; x < splits.Length; x++)
            {
                if (splits[x].StartsWith("red"))
                {
                    var res = Int32.Parse(splits[x - 1]);
                    if (res > red)
                    {
                        red = res;
                    }
                }
                if (splits[x].StartsWith("green"))
                {
                    var res = Int32.Parse(splits[x - 1]);
                    if (res > green)
                    {
                        green = res;
                    }
                }

                if (splits[x].StartsWith("blue"))
                {
                    var res = Int32.Parse(splits[x - 1]);
                    if (res > blue)
                    {
                        blue = res;
                    }
                }
            }

            runningtotal += red*blue*green;
        }

        return runningtotal;
    }


}
