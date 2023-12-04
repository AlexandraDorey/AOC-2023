using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2022;
internal static class day2
{
    public static string part1()
    {
        var lines = File.ReadAllLines("data\\day2.txt");

        int r = 1;
        int p = 2;
        int s = 3;

        int total = 0;
        foreach(var line in lines)
        {
            var splits = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            switch (splits[0][0])
            {
                case 'A':
                    switch (splits[1][0])
                    {
                        case 'X': total += 3; break;
                        case 'Y': total += 1+3; break;
                        case 'Z': total += 2+6; break;
                    }
                    break;
                case 'B':
                    switch (splits[1][0])
                    {
                        case 'X': total += 1+0; break;
                        case 'Y': total += 2+3; break;
                        case 'Z': total += 3+6; break;
                    }
                    break;
                case 'C':
                    switch (splits[1][0])
                    {
                        case 'X': total += 2; break;
                        case 'Y': total += 6; break;
                        case 'Z': total += 1+6; break;
                    }
                    break;
            }
        }

     

        return total.ToString();

    }

}
