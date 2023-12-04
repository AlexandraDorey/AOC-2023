using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2022;
internal static class day4
{


    public static string part1()
    {
        var lines = File.ReadAllLines("data\\day4.txt");

        int total = 0;

        foreach(var line in lines)
        {
            var s1 = line.Split(',');
            var s2 = s1[0].Split("-");
            var s3 = s1[1].Split("-");

            int e1l = int.Parse(s2[0]);
            int e1h = int.Parse(s2[1]);

            int e2l = int.Parse(s3[0]);
            int e2h = int.Parse(s3[1]);

            if ((e1l <= e2l && e1h >= e2l) || (e2l < e1l && e2h >= e1l))
            {
                total++;
            }
        }


        return total.ToString();
        

    }
    

}
