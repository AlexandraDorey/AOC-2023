using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adent_of_Code;
public static class Day01
{
    public static int step1()
    {
        var input = File.ReadAllLines("data\\aoc1.txt");

        int runningtotal = 0;

        foreach (string s in input)
        {
            char first = 'A';
            char last = 'A';
            
            foreach (char c in s)
            {
                if (c <= '9' && c >= '0')
                {
                    if (first == 'A')
                    {
                        first = c;
                    }

                    last = c;
                }
            }

            int calval = 0;
            if (first != 'A')
            {
                calval = (first - 48) * 10;
                calval += last - 48;
            }

            runningtotal += calval;
        }

        return runningtotal;
    }

    public static int step2()
    {
        var input = File.ReadAllLines("data\\aoc1.txt");

        int runningtotal = 0;

        foreach (string s in input)
        {
            char first = 'A';
            char last = 'A';

            int cp = 0;

            char digit = 'A';
            foreach (char c in s)
            {
                if (c <= '9' && c >= '0')
                {
                    digit = c;
                }
                else
                {
                    string checkfornum = s.Substring(cp);
                    if (checkfornum.StartsWith("one")) digit = '1';
                    if (checkfornum.StartsWith("two")) digit = '2';
                    if (checkfornum.StartsWith("three")) digit = '3';
                    if (checkfornum.StartsWith("four")) digit = '4';
                    if (checkfornum.StartsWith("five")) digit = '5';
                    if (checkfornum.StartsWith("six")) digit = '6';
                    if (checkfornum.StartsWith("seven")) digit = '7';
                    if (checkfornum.StartsWith("eight")) digit = '8';
                    if (checkfornum.StartsWith("nine")) digit = '9';
                }

                if (digit != 'A')
                {
                    if (first == 'A')
                    {
                        first = digit;
                    }
                    last = digit;
                }

                cp++;
            }

            int calval = 0;
            if (first != 'A')
            {
                calval = (first - 48) * 10;
                calval += last - 48;
            }

            runningtotal += calval;
        }

        return runningtotal;
    }


}
