using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2023;
public static class Day11
{
    public static string step1()
    {
        var input = File.ReadAllLines("data\\aoc11.txt");

        long total = 0;

        List<string> map = new();

        foreach (var line in input)
        {
            map.Add(line);
            bool dup = true;
            foreach (var c in line)
            {
                if (c != '.')
                {
                    dup = false;
                    break;
                }
            }

            if (dup)
            {
                map.Add(line);
            }
        }

        List<string> map2 = new();
        for (int x = 0; x < 140; x++)
        {
            map2.Add("");
        }


        foreach (var line in map)
        {
            int x = 0;
           foreach(char c in line)
           {
                map2[x] += c;
                x++;
           }
        }
        List<string> map3 = new();

        foreach (var line in map2)
        {
            map3.Add(line);
            bool dup = true;
            foreach (var c in line)
            {
                if (c != '.')
                {
                    dup = false;
                    break;
                }
            }
            if (dup)
            {
                map3.Add(line);
            }
        }

        char[,] xmap = new char[map3.Count, map3[0].Length];

        for (int y = 0; y < map3[0].Length; y++)
        {
            for (int x = 0; x < map3.Count; x++)
            {
                xmap[x, y] = map3[x][y];
            }
        }

        int maxx = map3.Count;
        int maxy = map3[0].Length;

        List<(int x, int y)> gals = new();

        for (int y = 0; y < maxy; y++)
        {
            for (int x = 0; x < maxx; x++)
            {
                if (xmap[x,y] == '#')
                {
                    gals.Add((x, y));
                }

            }
        }

        Dictionary<(int g1, int g2), int> results = new();

        for (int p1 = 0; p1 < gals.Count; p1++)
        {
            for (int p2 = 0; p2 < gals.Count; p2++)
            {
                if (p1 == p2) continue;

                int res = Math.Abs(gals[p2].x - gals[p1].x) + Math.Abs(gals[p2].y - gals[p1].y);
                if (p1 < p2)
                {
                    results[(p1, p2)] = res;
                }
                else
                {
                    results[(p2, p1)] = res;
                }
            }
        }

        foreach(var item in results)
        {
            total += item.Value;
        }

        return total.ToString();
    }


    public static string step2()
    {
        var input = File.ReadAllLines("data\\aoc11.txt");

        long total = 0;

        List<string> map = new();

        List<(int x, int y)> gals = new();

        Dictionary<int, int> vexp = new();
        Dictionary<int, int> hexp = new();

        int linec = 0;
        foreach (var line in input)
        {
            map.Add(line);
            int cc = 0;
            bool exp = true;
            foreach (var c in line)
            {
                if (c == '#')
                {
                    gals.Add((cc, linec));
                    exp = false;
                }
                cc++;
            }

            if (!exp)
            {
                if (linec == 0)
                {
                    vexp[linec] = linec;
                    
                }
                else
                {
                    vexp[linec] = vexp[linec - 1] + 1;
                }

            }
            else
            {
                vexp[linec] = vexp[linec-1] + 1000000;
            }
            linec++;
        }

        List<string> map2 = new();
        for (int x = 0; x < 140; x++)
        {
            map2.Add("");
        }


        foreach (var line in map)
        {
            int x = 0;
            foreach (char c in line)
            {
                map2[x] += c;
                x++;
            }
        }

        linec = 0;
        foreach (var line in map2)
        {
            bool exp = true;
            foreach (var c in line)
            {
                if (c != '.')
                {
                    exp = false;
                    break;
                }
            }

            if (!exp)
            {
                if(linec == 0)
                {
                    hexp[linec] = linec;
                }
                else
                {
                    hexp[linec] = hexp[linec - 1] + 1;
                }
                
            }
            else
            {
                hexp[linec] = hexp[linec - 1] + 1000000;
            }
            linec++;
        }

        List<(int x, int y)> xgals = new();

        foreach(var gal in gals)
        {
            xgals.Add((hexp[gal.x], vexp[gal.y]));
        }

        Dictionary<(int g1, int g2), long> results = new();

        for (int p1 = 0; p1 < xgals.Count; p1++)
        {
            for (int p2 = 0; p2 < xgals.Count; p2++)
            {
                if (p1 == p2) continue;

                long res = Math.Abs(xgals[p2].x - xgals[p1].x) + Math.Abs(xgals[p2].y - xgals[p1].y);
                if (p1 < p2)
                {
                    results[(p1, p2)] = res;
                }
                else
                {
                    results[(p2, p1)] = res;
                }
            }
        }

        foreach (var item in results)
        {
            total += item.Value;
        }

        return total.ToString();
    }

}
