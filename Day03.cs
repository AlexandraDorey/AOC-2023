using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adent_of_Code;
public static class Day03
{
    public static int step1()
    {
        var input = File.ReadAllLines("data\\aoc3.txt");

        int runningtotal = 0;


        List<(int line, int pos, int size, int num)> nums = new();
        List<(int line, int pos)> syms = new();


        int linec = 0;
        int linecp = 0;
        foreach (var line in input)
        {
            int cp = 0;
            while(cp < line.Length)
            {
                if (line[cp] == '.')
                {
                    cp++;
                    continue;
                }
                int numsize = 0;
                int numbstart = cp;
            
                while (cp < line.Length && line[cp] >= 48 && line[cp] < 58)
                {
                    numsize++;
                    cp++;
                }

                if (numsize > 0)
                {
                    nums.Add((linec, numbstart, numsize, int.Parse(line.Substring(numbstart, numsize))));
                    continue;
                }
                    
                syms.Add((linec, cp));
                cp++;
            }
            linec++;
        }

        int total = 0;
        foreach(var number in nums)
        {
            for (int x = 0; x < number.size + 2; x++)
            {
                if (syms.Contains((number.line - 1, number.pos + x - 1)) ||
                    syms.Contains((number.line, number.pos + x - 1)) ||
                    syms.Contains((number.line + 1, number.pos + x - 1)))
                {
                    total += number.num;
                    continue;
                }
            }
        }


        return total;
    }

    public static int step2()
    {
        var input = File.ReadAllLines("data\\aoc3.txt");

        int runningtotal = 0;


        List<(int line, int pos, int size, int num)> nums = new();
        List<(int line, int pos, char sym)> syms = new();


        int linec = 0;
        int linecp = 0;
        foreach (var line in input)
        {
            int cp = 0;
            while (cp < line.Length)
            {
                if (line[cp] == '.')
                {
                    cp++;
                    continue;
                }
                int numsize = 0;
                int numbstart = cp;

                while (cp < line.Length && line[cp] >= 48 && line[cp] < 58)
                {
                    numsize++;
                    cp++;
                }

                if (numsize > 0)
                {
                    nums.Add((linec, numbstart, numsize, int.Parse(line.Substring(numbstart, numsize))));
                    continue;
                }

                syms.Add((linec, cp, line[cp]));
                cp++;
            }
            linec++;
        }

        int total = 0;
        Dictionary<(int line, int pos, char sym), List<(int line, int pos, int size, int num)>> numsinc = new();


        foreach (var number in nums)
        {
            for (int x = 0; x < number.size + 2; x++)
            {

                for (int z = -1; z < 2; z++)
                {
                    if (syms.Contains((number.line + z, number.pos + x - 1, '*')))
                    {
                        if (!numsinc.ContainsKey((number.line + z, number.pos + x - 1, '*')))
                        {
                            numsinc.Add((number.line + z, number.pos + x - 1, '*'), new());
                        }
                        numsinc[(number.line + z, number.pos + x - 1, '*')].Add(number);
                    }
                }
            }
        }
        
        foreach(var kvp in numsinc)
        {
            if(kvp.Value.Count > 1)
            {
                total += kvp.Value[0].num * kvp.Value[1].num;
            }
        }

        return total;
    }


}
