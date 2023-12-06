using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2023;
public static class Day05
{
    private static int St2Int(this string input) => int.Parse(input);
    private static double St2Fl(this string input) => double.Parse(input);
    private static DateTime St2Dt(this string input) => DateTime.Parse(input);

    private static int DigToInt(this char input) => input - '0';

    private static bool IsD(this char input) => input >= '0' && input <= '9';
    private static bool IsLC(this char input) => input >= 'a' && input <= 'z';
    private static bool IsUC(this char input) => input >= 'A' && input <= 'Z';
    private static bool IsL(this char input) => input.IsLC() || input.IsUC();

    public static string step1()
    {
        var input = File.ReadAllLines("data\\aoc5.txt");

        int linec = 0;

        List<long> seeds = new();
        List<List<(long dest, long source, long size)>> mappings = new();
        bool discard = false;
        bool newmap = false;
        List<(long dest, long source, long size)> currentmap = null;
        foreach (var line in input)
        {
            if (linec == 0)
            {
                var sectionsplit = line.Split(':');
                var chunksplit2 = sectionsplit[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach(var item in chunksplit2)
                {
                    seeds.Add(long.Parse(item));
                }
                linec++;
                continue;
            }

            if (discard)
            {
                discard = false;
                continue;
            }

            if (line.Trim() == "")
            {
                if (currentmap != null)
                {
                    mappings.Add(currentmap);
                }
                discard = true;
                newmap = true;
                continue;
            }

            if (newmap)
            {
                currentmap = new();
                newmap = false;
            }

            var s = line.Split(' ');
            currentmap.Add((long.Parse(s[0]), long.Parse(s[1]), long.Parse(s[2])));
        }
        mappings.Add(currentmap);

        long lowest = long.MaxValue;

        for (int x = 0; x < seeds.Count; x++)
        {
            long seed = seeds[x];

            foreach (var map in mappings)
            {
                foreach (var info in map)
                {
                    if (seed >= info.source && seed < info.source + info.size)
                    {
                        seed = info.dest + (seed - info.source);
                        break;
                    }
                }
            }

            if (seed < lowest)
            {
                lowest = seed;
            }
        }

        return lowest.ToString();
    }

    public static string step2()
    {
        long largestnumber = 0;

        var input = File.ReadAllLines("data\\aoc5.txt");

        int linec = 0;

        List<(long seed, long size)> seeds = new();
        List<List<(long dest, long source, long size)>> mappings = new();
        bool discard = false;
        bool newmap = false;
        List<(long dest, long source, long size)> currentmap = null;
        foreach (var line in input)
        {
            if (linec == 0)
            {
                var sectionsplit = line.Split(':');
                var chunksplit2 = sectionsplit[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for(int x = 0; x < chunksplit2.Length;x=x+2)
                {
                    seeds.Add((long.Parse(chunksplit2[x]), long.Parse(chunksplit2[x+1])));
                }
                linec++;
                continue;
            }

            if (discard)
            {
                discard = false;
                continue;
            }

            if (line.Trim() == "")
            {
                if (currentmap != null)
                {
                    mappings.Add(currentmap);
                }
                discard = true;
                newmap = true;
                continue;
            }

            if(newmap)
            {
                currentmap = new();
                newmap = false;
            }

            var s = line.Split(' ');
            currentmap.Add((long.Parse(s[0]), long.Parse(s[1]), long.Parse(s[2])));
        }
        mappings.Add(currentmap);

        long lowest = long.MaxValue;
        


        for (int x = 0; x < seeds.Count; x++)
        {
            Queue<(long seed, long size)> seedsC = new();
            Queue<(long seed, long size)> seedsN = new();
            seedsC.Enqueue((seeds[x].seed, seeds[x].size));
            foreach (var map in mappings)
            {
                while(seedsC.Count > 0)
                {
                    var s = seedsC.Dequeue();
                    foreach(var rng in map)
                    {
                        if(s.seed > rng.source + rng.size - 1)
                        {
                            continue;
                        }

                        if(s.seed + s.size - 1 < rng.source)
                        {
                            continue;
                        }
                        
                        if(s.seed < rng.source)
                        {
                            seedsC.Enqueue((s.seed, rng.source - s.seed));
                            s = (rng.source, s.size - (rng.source - s.seed));
                        }

                        if (s.seed + s.size > rng.source + rng.size)
                        {
                            long over = (s.seed + s.size) - (rng.source + rng.size);
                            seedsC.Enqueue((rng.source + rng.size, over));
                            s = (s.seed, s.size - over);
                        }
                        seedsN.Enqueue((rng.dest + (s.seed - rng.source), s.size));
                        s = (-1, -1);
                        break;
                    }

                    if(s != (-1, -1))
                    {
                        seedsN.Enqueue((s.seed, s.size));
                    }
                }
                seedsC = seedsN;
                seedsN = new();
            }

            while(seedsC.Count > 0)
            {
                var s = seedsC.Dequeue();
                if(s.seed < lowest)
                {
                    lowest = s.seed;
                }
            }
        }

        return lowest.ToString();
    }
}
