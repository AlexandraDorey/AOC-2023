using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2023;
public static class Day06
{
    private static long S2I(this string input) => long.Parse(input);
    private static double S2F(this string input) => double.Parse(input);
    private static DateTime St2Dt(this string input) => DateTime.Parse(input);

    private static long D2I(this char input) => input - '0';

    private static bool IsD(this char input) => input >= '0' && input <= '9';
    private static bool IsLC(this char input) => input >= 'a' && input <= 'z';
    private static bool IsUC(this char input) => input >= 'A' && input <= 'Z';
    private static bool IsL(this char input) => input.IsLC() || input.IsUC();

    public static string step1()
    {

        var input = File.ReadAllLines("data\\aoc6.txt");

        int total = 1;

        List<long> times = new();
        List<long> bestDist = new();
        
        var sectionsplit = input[0].Split(':');
        var chunksplit1 = sectionsplit[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach(string t in chunksplit1)
        {
            times.Add(t.Trim().S2I());
        }

        sectionsplit = input[1].Split(':');
        chunksplit1 = sectionsplit[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string t in chunksplit1)
        {
            bestDist.Add(t.Trim().S2I());
        }

        for(int x = 0; x< times.Count;x++)
        {
            int wins = 0;
            for (int speed = 0; speed < times[x]; speed++)
            {
                if ((times[x] - speed) * speed > bestDist[x])
                {
                    wins++;
                }   
            }
            total *= wins;
        }

            return total.ToString();
    }

    // note just manually moded to remove the spaces in the input file and ran my step one again.
    public static string step2()
    {
        var input = File.ReadAllLines("data\\aoc6-mod.txt");

        int total = 1;

        List<long> times = new();
        List<long> bestDist = new();

        var sectionsplit = input[0].Split(':');
        var chunksplit1 = sectionsplit[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string t in chunksplit1)
        {
            times.Add(t.Trim().S2I());
        }

        sectionsplit = input[1].Split(':');
        chunksplit1 = sectionsplit[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string t in chunksplit1)
        {
            bestDist.Add(t.Trim().S2I());
        }

        for (int x = 0; x < times.Count; x++)
        {
            int wins = 0;
            for (int speed = 0; speed < times[x]; speed++)
            {
                if ((times[x] - speed) * speed > bestDist[x])
                {
                    wins++;
                }
            }
            total *= wins;
        }

        return total.ToString();

    }
}
