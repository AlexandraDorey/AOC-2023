using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2023;
public static class Day04
{
    public static int step1()
    {
        var input = File.ReadAllLines("data\\aoc5.txt");

        int total = 0;

        foreach (var line in input)
        {
            var splits1 = line.Split(':');
            var splits2 = splits1[1].Split('|');
            var splitwin = splits2[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var splitnums = splits2[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int score = 0;
            foreach(var num in splitwin)
            {
                int winnum = int.Parse(num);
                foreach(var num2 in splitnums)
                {
                    int thisnum = int.Parse(num2);
                    if(winnum == thisnum)
                    {
                        if(score == 0)
                        {
                            score = 1;
                        }
                        else
                        {
                            score *= 2;
                        }
                    }
                }
            }
            total += score;

        }

        return total;
    }

    public static int step2()
    {

        var input = File.ReadAllLines("data\\aoc4.txt");

        int total = 0;

        int[] counts = new int[input.Length + 1000];
        for (int x = 0; x < input.Length; x++)
        {
            counts[x] = 1;
        }

        int cp = 0;
        foreach (var line in input)
        {
            int res = process(line); // moved here so solution is fast instead of taking like 20s.
            for (int z = 0; z < counts[cp]; z++)
            {
                //int res = process(line); // original SLOW location :facepalm: but it worked.
                for (int y = cp + 1; y < cp + res + 1; y++)
                {
                    counts[y]++;
                }
            }
            cp++;
        }

        for (int x = 0; x < input.Length; x++)
        {
            total += counts[x];
        }

        return total;

    }


    private static int process(string line)
    {
        var splits1 = line.Split(':');
        var splits2 = splits1[1].Split('|');
        var splitwin = splits2[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var splitnums = splits2[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int score = 0;
        foreach (var num in splitwin)
        {
            int winnum = int.Parse(num);
            foreach (var num2 in splitnums)
            {
                int thisnum = int.Parse(num2);
                if (winnum == thisnum)
                {
                    score++;
                }
            }
        }
        return score;
    }


}
