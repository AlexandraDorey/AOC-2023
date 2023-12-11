using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2023;
public static class Day10
{

    public static string step1()
    {
        Dictionary<(int x, int y), char> gridDict = new();
        Dictionary<(int x, int y), char> loopDict = new();

        var input = File.ReadAllLines("data\\aoc10.txt");
        int linec = 0;

        (int x, int y) start = (0,0);

        foreach (var line in input)
        {
            int cc = 0;
            foreach (var c in line)
            {
                gridDict[(cc, linec)] = c;
                

                if(c == 'S')
                {
                    start = (cc, linec);
                }
                cc++;
            }

            linec++;
        }

        
        (int x, int y, int lastx, int lasty, int steps) walker1 = (start.x, start.y - 1, start.x, start.y, 1);
        (int x, int y, int lastx, int lasty, int steps) walker2 = (start.x - 1, start.y, start.x, start.y, 1);

        while(true)
        {
            step(ref walker1);
            if (walker1.x == walker2.x && walker1.y == walker2.y) break;
            step(ref walker2);
            if (walker1.x == walker2.x && walker1.y == walker2.y) break;
        }

        return Math.Max(walker1.steps, walker2.steps).ToString();

        void step(ref (int x, int y, int lastx, int lasty, int steps) w)
        {

            int savex = w.x;
            int savey = w.y;
            switch (gridDict[(w.x, w.y)])
            {
                case '|':
                    if (w.y + 1 == w.lasty)
                    {
                        w.y--;
                    }
                    else
                    {
                        w.y++;
                    }
                    break;
                case '-':
                    if (w.x + 1 == w.lastx)
                    {
                        w.x--;
                    }
                    else
                    {
                        w.x++;
                    }
                    break;
                case 'L':
                    if (w.y - 1 == w.lasty)
                    {
                        w.x++;
                    }
                    else
                    {
                        w.y--;
                    }
                    break;
                case 'J':
                    if (w.y - 1 == w.lasty)
                    {
                        w.x--;
                    }
                    else
                    {
                        w.y--;
                    }
                    break;
                case '7':
                    if (w.y + 1 == w.lasty)
                    {
                        w.x--;
                    }
                    else
                    {
                        w.y++;
                    }
                    break;
                case 'F':
                    if (w.y + 1 == w.lasty)
                    {
                        w.x++;
                    }
                    else
                    {
                        w.y++;
                    }
                    break;
                default:
                    Console.WriteLine(gridDict[(savex, savey)]);
                    break;

            }
            
            w.lastx = savex;
            w.lasty = savey;
            w.steps++;
        }
    }

    public static string step2()
    {

        Dictionary<(int x, int y), char> gridDict = new();
        Dictionary<(int x, int y), char> gridDictT = new();

        var input = File.ReadAllLines("data\\aoc10.txt");

        int linec = 0;

        (int x, int y) start = (0, 0);
        int maxx = 0;
        foreach (var line in input)
        {
            int cc = 0;
            foreach (var c in line)
            {
                gridDict[(cc, linec)] = c;
                gridDictT[(cc, linec)] = c;

                if (c == 'S')
                {
                    start = (cc, linec);
                    gridDict[start] = 'J';
                }
                cc++;
            } 
            maxx = cc;
            linec++;
        }

        (int x, int y, int lastx, int lasty, int steps) walker1 = (start.x, start.y, start.x, start.y, 1);

        while (true)
        {
            step(ref walker1);
            if (walker1.x == start.x && walker1.y == start.y) break;
        }

        char[,] gridDictBig = new char[maxx * 3, linec * 3];

        for (int y = 0; y < linec; y++)
        {
            for (int x = 0; x < maxx; x++)
            {
                char[,] conv = new char[3, 3]
                        {
                            {' ',' ',' '},
                            {' ','.',' '},
                            {' ',' ',' '},
                        };
                
                if (gridDictT[(x, y)] == '#')
                {
                    switch (gridDict[(x, y)])
                    {
                        case '|':
                            conv = new char[3, 3]
                            {
                            {' ','#',' '},
                            {' ','#',' '},
                            {' ','#',' '},
                            };
                            break;
                        case '-':
                            conv = new char[3, 3]
                             {
                            {' ',' ',' '},
                            {'#','#','#'},
                            {' ',' ',' '},
                             };
                            break;
                        case 'L':
                            conv = new char[3, 3]
                             {
                            {' ','#',' '},
                            {' ','#','#'},
                            {' ',' ',' '},
                             };
                            break;
                        case 'J':
                            conv = new char[3, 3]
                             {
                            {' ','#',' '},
                            {'#','#',' '},
                            {' ',' ',' '},
                             };
                            break;
                        case '7':
                            conv = new char[3, 3]
                             {
                            {' ',' ',' '},
                            {'#','#',' '},
                            {' ','#',' '},
                             };
                            break;
                        case 'F':
                            conv = new char[3, 3]
                                 {
                            {' ',' ',' '},
                            {' ','#','#'},
                            {' ','#',' '},
                                 };
                            break;
                    }
                }

                for(int x1 = 0; x1< 3;x1++)
                {
                    for(int y1 = 0; y1 < 3; y1++)
                    {
                        gridDictBig[(x * 3) + x1, (y * 3) + y1] = conv[y1, x1];
                    }
                }
            }
        }
        
        string output = "";
        for (int y = 0; y < linec * 3; y++)
        {
            for (int x = 0; x < maxx * 3; x++)
            {
                output += gridDictBig[x, y];
            }
            output += "\n";
        }

        File.WriteAllText("d:\\source\\whatever.txt", output);

        int changed = 1;
        gridDictBig[0, 0] = '*';
        while (changed > 0)
        {
            changed = 0;
            for (int y = 0; y < linec * 3; y++)
            {
                for (int x = 0; x < maxx * 3; x++)
                {
                    if (gridDictBig[x, y] == '*')
                    {
                        if (x + 1 < maxx * 3 && (gridDictBig[x + 1, y] == ' ' || gridDictBig[x + 1, y] == '.'))
                        {
                            gridDictBig[x + 1, y] = '*';
                            changed++;
                        }

                        if (x - 1 >= 0 && (gridDictBig[x - 1, y] == ' ' || gridDictBig[x - 1, y] == '.'))
                        {
                            gridDictBig[x - 1, y] = '*';
                            changed++;
                        }

                        if (y + 1 < linec * 3 && (gridDictBig[x, y + 1] == ' ' || gridDictBig[x, y + 1] == '.'))
                        {
                            gridDictBig[x, y + 1] = '*';
                            changed++;
                        }

                        if (y - 1 >= 0 && (gridDictBig[x, y - 1] == ' ' || gridDictBig[x, y - 1] == '.'))
                        {
                            gridDictBig[x, y - 1] = '*';
                            changed++;
                        }
                    }
                }
            }
        }

        int total = 0;
        output = "";
        for (int y = 0; y < linec * 3; y++)
        {
            for (int x = 0; x < maxx * 3; x++)
            {
                if (gridDictBig[x, y] == '.')
                {
                    total++;
                }
                output += gridDictBig[x, y];
            }
            output += "\n";
        }

        File.WriteAllText("d:\\source\\whatever1.txt", output);

        return total.ToString();

        void step(ref (int x, int y, int lastx, int lasty, int steps) w)
        {
            int savex = w.x;
            int savey = w.y;
            switch (gridDict[(w.x, w.y)])
            {
                case '|':
                    if (w.y + 1 == w.lasty)
                    {
                        w.y--;
                    }
                    else
                    {
                        w.y++;
                    }
                    break;
                case '-':
                    if (w.x + 1 == w.lastx)
                    {
                        w.x--;
                    }
                    else
                    {
                        w.x++;
                    }
                    break;
                case 'L':
                    if (w.y - 1 == w.lasty)
                    {
                        w.x++;
                    }
                    else
                    {
                        w.y--;
                    }
                    break;
                case 'J':
                    if (w.y - 1 == w.lasty)
                    {
                        w.x--;
                    }
                    else
                    {
                        w.y--;
                    }
                    break;
                case '7':
                    if (w.y + 1 == w.lasty)
                    {
                        w.x--;
                    }
                    else
                    {
                        w.y++;
                    }
                    break;
                case 'F':
                    if (w.y + 1 == w.lasty)
                    {
                        w.x++;
                    }
                    else
                    {
                        w.y++;
                    }
                    break;
                default:
                    Console.WriteLine(gridDict[(savex, savey)]);
                    break;

            }
            
            w.lastx = savex;
            w.lasty = savey;
            gridDictT[(w.lastx, w.lasty)] = '#';
            w.steps++;
        }
    }
}
