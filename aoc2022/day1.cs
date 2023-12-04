using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2022;
internal static class day1
{
    public static string part1()
    {
        var lines = File.ReadAllLines("data\\day1.txt");

        int current = 0;

        List<int> elves = new();
        foreach(var line in lines)
        {
            if(line.Trim() == string.Empty)
            {
                elves.Add(current);
                current = 0;
                continue;
            }

            current += int.Parse(line.Trim());
        }
        int total = 0;
        int loc = 0;

        for(int x = 0; x< 3; x++)
        {
            int best = 0;
            int cp = 0;
            foreach(var num in elves)
            {
                if(num > best)
                {
                    best = num;
                    loc = cp;
                }
                cp++;
            }
            elves.RemoveAt(loc);
            total += best;
            
        }

        return total.ToString();

    }

}
