using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2023;
public static class Day0x
{
    private static long asI(this string input) => long.Parse(input);
    private static double asF(this string input) => double.Parse(input);
    private static DateTime asDt(this string input) => DateTime.Parse(input);

    private static long Dig2I(this char input) => input - '0';

    private static bool IsD(this char input) => input >= '0' && input <= '9';
    private static bool IsLC(this char input) => input >= 'a' && input <= 'z';
    private static bool IsUC(this char input) => input >= 'A' && input <= 'Z';
    private static bool IsL(this char input) => input.IsLC() || input.IsUC();

    private static int CardC2Val(char x)
    {
        switch (x)
        {
            case 'A': return 14;
            case 'K': return 13;
            case 'Q': return 12;
            case 'J': return 11;
            case 'T': return 10;
            case '9': return 9;
            case '8': return 8;
            case '7': return 7;
            case '6': return 6;
            case '5': return 5;
            case '4': return 4;
            case '3': return 3;
            case '2': return 2;
        }
        return 0;
    }


    public static string step1()
    {

        Dictionary<(long line, long pos), string> gridDict = new();
        List<(long line, long pos)> gridList = new();
        List<char> charList = new();
        List<long> longList = new();
        List<string> stringList = new();

        Stack<(long line, long pos)> gridStack = new();
        Stack<long> longStack = new();
        Stack<char> charStack = new();
        Stack<string> stringStack = new();
        
        Queue<(long line, long pos)> gridQueue = new();
        Queue<long> longQueue = new();
        Queue<char> charQueue = new();
        Queue<string> stringQueue = new();

        var input = File.ReadAllLines("data\\aoc5.txt");

        long total = 0;
        string answer = "";
        string pad = "";
        long counter = 0;
        long marker1 = -1;

        long linec = 0;

        foreach (var line in input)
        {
            //splits
            var ssp = line.Split(':');
            var csp1 = ssp[0].Split('|');
            var csp2 = ssp[1].Split('|');
            var isp1 = csp1[0].Split(" ");
            var isp2 = csp1[1].Split(" ");
            var isp3 = csp2[0].Split(" ");
            var isp4 = csp2[1].Split(" ");

            string pad1 = "";
            long counter2 = 0;
            long marker2 = -1;

            foreach (var item in ssp)
            {
                string pad3 = "";

                long reslong = pad3.asI();
                double resflt = pad3.asF();
                DateTime resdt = pad3.asDt();
            }

            foreach (var item in csp1)
            {
                string pad3 = "";

            }

            // by char parsing.
            long cp = 0;
            foreach (var c in line)
            {
                if(c.IsD() || c.IsL() || c.IsUC() || c.IsLC())
                {
                    c.Dig2I();

                }

                long cp2 = cp;
                while (c.IsD())
                {


                    cp2++;
                }

                if (c == '?')
                {

                }

                cp++;
            }


            linec++;
        }

        for (long x = 0; x < 100; x++)
        {

        }

        for (long y = 0; y < 100; y++)
        {

        }

        for (long z = 0; z < 100; z++)
        {

        }



        if (total != 0)
        {
            return total.ToString();
        }
        else
        {
            return answer;
        }
    }

    public static string step2()
    {
        return "";

    }
}
