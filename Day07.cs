using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2023;
public static class Day07
{
    private static long St2Int(this string input) => long.Parse(input);
    private static double St2Fl(this string input) => double.Parse(input);
    private static DateTime St2Dt(this string input) => DateTime.Parse(input);

    private static int DigToInt(this char input) => input - '0';

    private static bool IsD(this char input) => input >= '0' && input <= '9';
    private static bool IsLC(this char input) => input >= 'a' && input <= 'z';
    private static bool IsUC(this char input) => input >= 'A' && input <= 'Z';
    private static bool IsL(this char input) => input.IsLC() || input.IsUC();


    class compare1 : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            int rankx = GetRank(x);
            int ranky = GetRank(y);
            if(rankx == ranky)
            {
                for (int z = 0; z < 5; z++)
                {
                    if (val(x[z]) == val(y[z]))
                    {
                        continue;
                    }

                    if(val(x[z]) < val(y[z]))
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                Console.WriteLine("Fuck");
                return 0;
            }
            else
            {
                return rankx < ranky ? 1 : -1;
            }
        }

        int GetRank(string hand)
        {
            SortedList<char, int> cc = new();
            int x = 0;
            foreach(char c in hand)
            {
                if (!cc.ContainsKey(c))
                {
                    cc[c] = 1;
                }
                else
                {
                    cc[c]++;
                }
            }

            var vals = cc.Values;

            if (vals.Contains(5)) return 0;
            if (vals.Contains(4)) return 1;
            if (vals.Contains(3) && vals.Contains(2)) return 2;
            if (vals.Contains(3)) return 3;
            if (vals.Contains(2) && cc.Count == 3) return 4;
            if (vals.Contains(2) && cc.Count == 4) return 5;

            return 6;
        }

        int val(char x)
        {
            switch(x)
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
    }

    class compare2 : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            int rankx = GetBest(x);
            int ranky = GetBest(y);
            if (rankx == ranky)
            {
                for (int z = 0; z < 5; z++)
                {
                    if (val(x[z]) == val(y[z]))
                    {
                        continue;
                    }

                    if (val(x[z]) < val(y[z]))
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                Console.WriteLine("Fuck");
                return 0;
            }
            else
            {
                return rankx < ranky ? 1 : -1;
            }
        }


        int GetBest(string Hand)
        {
            int bestrank = 10;
            if (Hand.Contains("J"))
            {
                int reploc = Hand.IndexOf('J');
                foreach (char c in allsuits)
                {
                    bool done = false;
                    string newhand = "";
                    for (int z = 0; z < 5; z++)
                    {
                        if (Hand[z] == 'J' && !done)
                        {
                            newhand += c;
                        }
                        else
                        {
                            newhand += Hand[z];
                        }
                    }

                    int prank = GetBest(newhand);
                    if (prank < bestrank)
                    {
                        bestrank = prank;
                    }
                }
            }
            else
            {
                return GetRank(Hand);
            }

            return bestrank;
        }

        private List<char> allsuits = new List<char>()
        {
            'A',
            'K',
            'Q',
            'T',
            '9',
            '8',
            '7',
            '6',
            '5',
            '4',
            '3',
            '2'
            };

        int GetRank(string hand)
        {
            SortedList<char, int> cc = new();
            int x = 0;
            foreach (char c in hand)
            {
                if (!cc.ContainsKey(c))
                {
                    cc[c] = 1;
                }
                else
                {
                    cc[c]++;
                }
            }

            var vals = cc.Values;

            if (vals.Contains(5)) return 0;
            if (vals.Contains(4)) return 1;
            if (vals.Contains(3) && vals.Contains(2)) return 2;
            if (vals.Contains(3)) return 3;
            if (vals.Contains(2) && cc.Count == 3) return 4;
            if (vals.Contains(2) && cc.Count == 4) return 5;

            return 6;
        }

        int val(char x)
        {
            switch (x)
            {
                case 'A': return 14;
                case 'K': return 13;
                case 'Q': return 12;
                case 'J': return 1;
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

    }



    public static string step1()
    {
        SortedList<string, long> hands = new(new compare1());

        var input = File.ReadAllLines("data\\aoc7.txt");

        long  total = 0;
        string answer = "";

        foreach (var line in input)
        {
            //splits
            var sectionsplit = line.Split(' ');
            hands.Add(sectionsplit[0], sectionsplit[1].St2Int());
        }

        int x = 1;
        foreach (var hand in hands.Values)
        {
            total += hand * x;
            x++;
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

    //note same as 1 but uses different comparer
    public static string step2()
    {


        SortedList<string, long> hands = new(new compare2());

        var input = File.ReadAllLines("data\\aoc7.txt");

        long total = 0;
        string answer = "";

        foreach (var line in input)
        {
            //splits
            var sectionsplit = line.Split(' ');
            hands.Add(sectionsplit[0], sectionsplit[1].St2Int());
        }

        int x = 1;
        foreach (var hand in hands.Values)
        {
            total += hand * x;
            x++;
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
}
