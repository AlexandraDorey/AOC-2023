using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2023;
public static class Day0X
{
    private static int St2Int(this string input) => int.Parse(input);
    private static double St2Fl(this string input) => double.Parse(input);
    private static DateTime St2Dt(this string input) => DateTime.Parse(input);

    private static int DigToInt(this char input) => input - '0';

    private static bool IsD(this char input) => input >= '0' && input <= '9';
    private static bool IsLC(this char input) => input >= 'a' && input <= 'z';
    private static bool IsUC(this char input) => input >= 'A' && input <= 'Z';
    private static bool IsL(this char input) => input.IsLC() || input.IsUC();

    public static string step1()
    {

        Dictionary<(int line, int pos), string> gridDict = new();
        List<(int line, int pos)> gridList = new();
        List<char> charList = new();
        List<int> intList = new();
        List<string> stringList = new();

        Stack<(int line, int pos)> gridStack = new();
        Stack<int> intStack = new();
        Stack<char> charStack = new();
        Stack<string> stringStack = new();
        
        Queue<(int line, int pos)> gridQueue = new();
        Queue<int> intQueue = new();
        Queue<char> charQueue = new();
        Queue<string> stringQueue = new();

        var input = File.ReadAllLines("data\\aoc5.txt");

        int total = 0;
        string answer = "";
        string pad = "";
        int counter = 0;
        int marker1 = -1;

        int linec = 0;

        foreach (var line in input)
        {
            //splits

            var sectionsplit = line.Split(':');
            var chunksplit1 = sectionsplit[0].Split('|');
            var chunksplit2 = sectionsplit[1].Split('|');
            var itemsplit1 = chunksplit1[0].Split(" ");
            var itemsplit2 = chunksplit1[1].Split(" ");
            var itemsplit3 = chunksplit2[0].Split(" ");
            var itemsplit4 = chunksplit2[1].Split(" ");

            string pad1= "";
            int counter2 = 0;
            int marker2 = -1;
            
            foreach (var item in sectionsplit)
            {
                string pad3 = "";

                int resint = pad3.St2Int();
                double resflt = pad3.St2Fl();
                DateTime resdt = pad3.St2Dt();
            }

            foreach (var item in chunksplit1)
            {
                string pad3 = "";

            }

            // by char parsing.
            int cp = 0;
            foreach (var c in line)
            {
                if(c.IsD() || c.IsL() || c.IsUC() || c.IsLC())
                {
                    c.DigToInt();

                }

                int cp2 = cp;
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

        for (int x = 0; x < 100; x++)
        {

        }

        for (int y = 0; y < 100; y++)
        {

        }

        for (int z = 0; z < 100; z++)
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
