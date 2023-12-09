using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2023;
public static class Day09
{
    private static long asI(this string input) => long.Parse(input);

    public static string step1()
    {
        var input = File.ReadAllLines("data\\aoc9.txt");

        long total = 0;

        foreach (var line in input)
        {
            var ssp = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<long> nums = new();
            foreach (var num in ssp)
            {
                nums.Add(num.asI());
            }

            res(nums);
            total += nums.Last();
        }

        return total.ToString();
    }

    public static string step2()
    {
        var input = File.ReadAllLines("data\\aoc9.txt");

        long total = 0;

        foreach (var line in input)
        {
            var ssp = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<long> nums = new();
            foreach (var num in ssp)
            {
                nums.Add(num.asI());
            }

            nums.Reverse();

            res(nums);
            total += nums.Last();
        }

        return total.ToString();
    }

    static void res(List<long> nums)
    {
        bool allzero = true;
        for (int x = 0; x < nums.Count; x++)
        {
            if (nums[x] != 0)
            {
                allzero = false;
                break;
            }
        }

        if (allzero == true)
        {
            nums.Add(0);
        }
        else
        {
            List<long> newnums = new();
            for (int x = 0; x < nums.Count - 1; x++)
            {
                newnums.Add(nums[x+1] - nums[x]);
            }
            res(newnums);
            nums.Add(nums.Last() + newnums.Last());
        }
    }
}
 