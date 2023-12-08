using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2023;
public static class Day08
{
    private static long asI(this string input) => long.Parse(input);
    private static double asF(this string input) => double.Parse(input);
    private static DateTime asDt(this string input) => DateTime.Parse(input);

    private static long Dig2I(this char input) => input - '0';

    private static bool IsD(this char input) => input >= '0' && input <= '9';
    private static bool IsLC(this char input) => input >= 'a' && input <= 'z';
    private static bool IsUC(this char input) => input >= 'A' && input <= 'Z';
    private static bool IsL(this char input) => input.IsLC() || input.IsUC();

    private static Dictionary<char, int> Cards = new()
    {
        { '1', 1 },
        { '2', 2 },
        { '3', 3 },
        { '4', 4 },
        { '5', 5 },
        { '6', 6 },
        { '7', 7 },
        { '8', 8 },
        { '9', 9 },
        { '0', 10 },
        { 'T', 10 },
        { 'J', 11 },
        { 'Q', 12 },
        { 'K', 13 },
        { 'A', 14 },
    };



    public static string step2rage()
    {
        DateTime StartTime = DateTime.Now;
        Dictionary<string, (string l, string r)> map = new();
        var input = File.ReadAllLines("data\\aoc8.txt");
        string pad = "";
        long lc = 0;
        foreach (var line in input)
        {
            if (lc == 0)
            {
                pad = line;
                lc++;
                continue;
            }

            if(lc == 1)
            {
                lc++;
                continue;
            }

            var ssp = line.Split('=', StringSplitOptions.RemoveEmptyEntries);
            var csp2 = ssp[1].Trim('(', ')', ' ').Split(',', StringSplitOptions.RemoveEmptyEntries);

            map.Add(ssp[0].Trim(), (csp2[0].Trim(), csp2[1].Trim()));

            lc++;
        }

        bool done = false;
        List<string> snodes = new();
        List<string> next = new();
        Dictionary<(int, int), long> steps = new();

        foreach (var item in map)
        {
            if (item.Key[2] == 'A')
            {
                snodes.Add(item.Key);
                next.Add(item.Key);
            }
        }

        for (int x = 0; x < snodes.Count; x++)
        {
            next[x] = snodes[x];
        }


        long thissteps = 0;
        done = false;

        // this is what happens when you think that your missing 
        // a suble thing but you're just dum so you calculate lots of
        // extra things that really result in the SAME DAMN answer
        for (int z = 0; z < snodes.Count; z++)
        {
            for (int y = 0; y < snodes.Count; y++)
            {
                if(y == z)
                {
                    continue;
                }
                done = false;
                thissteps = 0;
                while (!done)
                {
                    foreach (var c in pad)
                    {
                        // thissteps++; WHERE IT SHOULD BEEE so much range.
                        for (int x = 0; x < snodes.Count; x++)
                        {
                            thissteps++; // OMG THIS DOES NOT FUCKING GO HERE. 3 hrs and I couldn't see that 3 hrs!!!.

                            if (c == 'R')
                            {
                                next[x] = map[next[x]].r;
                            }
                            else
                            {
                                next[x] = map[next[x]].l;
                            }
                        }

                        if (next[y][2] == 'Z' && next[z][2] == 'Z')
                        {
                            steps[(y, z)] = thissteps;
                            done = true;
                            break;
                        }
                    }
                }
            }
        }

        Dictionary<(int, int), long> muls = new();
        foreach(var stepinter in steps)
        {
            muls[stepinter.Key] = 1;
        }
         
        // this is a dumb/slow way of doing this, that's not as fast at the one in 
        // the actual step2. I was just at my wits and tried coding it a differnt
        // way in case... well I got nothing... you think this is wild... some
        // of my interim solutiosn along the way are hareraising. The one
        // this is bruteforcy, but probably only 20mins? 
        // it's much quicker if you just go from one to the next,
        // isntead of all at once
        while (true)
        {
            long lowest = long.MaxValue;
            (int, int) currentm = (0, 0);
            foreach(var stepiner in steps)
            {
                if(steps[stepiner.Key] * muls[stepiner.Key] < lowest)
                {
                    lowest = steps[stepiner.Key] * muls[stepiner.Key];
                    currentm = stepiner.Key;
                }
            }

            muls[currentm]++;

            long totalSteps = long.MaxValue;
            done = true;
            foreach (var stepiner in steps)
            {
                if(totalSteps == long.MaxValue)
                {
                    totalSteps = steps[stepiner.Key] * muls[stepiner.Key];
                }
                if(totalSteps != steps[stepiner.Key] * muls[stepiner.Key])
                {
                    done = false;
                    break;
                }
            }

            if (done)
            {
                break;
            }
        }

        long totalSteps1 = 0;
        foreach (var stepiner in steps)
        {
            totalSteps1 = steps[stepiner.Key] * muls[stepiner.Key];
        }

        DateTime EndTime = DateTime.Now;
        return totalSteps1.ToString() + $"                  {EndTime - StartTime}";
    }

    public static string step2()
    {
        DateTime StartTime = DateTime.Now;
        Dictionary<string, (string l, string r)> map = new();
        var input = File.ReadAllLines("data\\aoc8.txt");

        long total = 0;
        string answer = "";
        string pad = "";
        long counter = 0;
        long m = -1;

        long lc = 0;

        string start = "";
        foreach (var line in input)
        {
            if (lc == 0)
            {
                pad = line;
                lc++;
                continue;
            }

            if (lc == 1)
            {
                lc++;
                continue;
            }

            var ssp = line.Split('=', StringSplitOptions.RemoveEmptyEntries);
            var csp2 = ssp[1].Trim('(', ')', ' ').Split(',', StringSplitOptions.RemoveEmptyEntries);

            map.Add(ssp[0].Trim(), (csp2[0].Trim(), csp2[1].Trim()));

            lc++;
        }

        List<string> snodes = new();
        List<string> pathnodes = new();
        List<long> steps = new();

        foreach (string s in map.Keys)
        {
            if(s.EndsWith('A'))
            {
                snodes.Add(s);
            }
        }

        for (int cn = 1; cn < snodes.Count; cn++)
        {
            bool done = false;
            pathnodes.Clear();
            pathnodes.AddRange(snodes);
            long currentSteps = 0;
            while (!done)
            {
                foreach (char c in pad)
                {
                    currentSteps++;
                    for (int i = 0; i < snodes.Count; i++)
                    {
                        if (c == 'L')
                        {
                            pathnodes[i] = map[pathnodes[i]].l;
                        }
                        else
                        {
                            pathnodes[i] = map[pathnodes[i]].r;
                        }
                    }

                    if (pathnodes[0].EndsWith('Z') && pathnodes[cn].EndsWith('Z'))
                    {
                        steps.Add(currentSteps);
                        done = true;
                        break;
                    }
                }
            }
        }


        int m1 = 1;
        int m2 = 1;
        long totalSteps = steps[0];
        for (int csync = 1; csync <  steps.Count; csync++)
        {
            while (totalSteps * m1 != steps[csync] * m2)
            {
                if(totalSteps * m1 < steps[csync] * m2)
                {
                    m1++;
                }
                else
                {
                    m2++;
                }
            }
            totalSteps = totalSteps * m1;
            m1 = 1;
            m2 = 1;
        }

        DateTime EndTime = DateTime.Now;
        return totalSteps.ToString() + $"                  {EndTime - StartTime}";
    }
}

