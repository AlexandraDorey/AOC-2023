using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2022;
internal static class day3
{


    public static string part1()
    {
        var lines = File.ReadAllLines("data\\day3.txt");
        int total = 0;
        foreach(var line in lines)
        {
            foreach (var item in line.Substring(0, line.Length / 2))
            {
                if(line.Substring(line.Length/2).Contains(item))
                {
                    if(item >= 'A' && item <= 'Z')
                    {
                        total += item - 65 + 27;
                    }
                    if(item >= 'a' && item <= 'z')
                    {
                        total += item - 97 + 1;
                    }
                    break;
                }
            }
        }

        return total.ToString();
        

    }

    public static string part2()
    {
        var lines = File.ReadAllLines("data\\day3.txt");
        int total = 0;

        string l1 = "";
        string l2 = "";
        string l3 = "";
        int c = 0;
        foreach (var line in lines)
        {
            if (c == 0) l1 = line;
            if (c == 1) l2 = line;
            if (c == 2)
            {
                l3 = line;
                foreach(var item in l1)
                {
                    if(l2.Contains(item) && l3.Contains(item))
                    {
                        if (item >= 'A' && item <= 'Z')
                        {
                            total += item - 65 + 27;
                        }
                        if (item >= 'a' && item <= 'z')
                        {
                            total += item - 97 + 1;
                        }
                        break;
                    } 
                }
                c = -1;
            }
            c++;
        }
        return total.ToString();


    }

}
