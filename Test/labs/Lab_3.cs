using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net
{
    public class Lab_3
    {
        int lapplase(int[][] a)
        {
            int[] raws = new int[3];
            double[] kefs = { 0.5, 0.3, 0.2 };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    a[i][j] = (int)(a[i][j] * kefs[j]);
                    raws[i] += a[i][j];
                }
            }
            int raw = 0;
            int max = raws[0];

            for (int i = 0; i < 3; i++)
            {
                if (max < raws[i])
                {
                    max = raws[i];
                    raw = i;
                }
            }
            return raw + 1;
        }
        int lemmanne(int[][] a)
        {
            int[] raws = new int[3];
            double[] kefs = { 0.5, 0.3, 0.2 };
            int min;
            for (int i = 0; i < 3; i++)
            {
                min = a[i][0];
                for (int j = 0; j < 3; j++)
                {
                    if (min > a[i][j])
                    {
                        min = a[i][j];
                    }
                    a[i][j] = (int)(a[i][j] * kefs[j]);
                    raws[i] += a[i][j];
                }
                raws[i] += min;
                raws[i] /= 2;
            }
            int raw = 0;
            int max = raws[0];

            for (int i = 0; i < 3; i++)
            {
                if (max < raws[i])
                {
                    max = raws[i];
                    raw = i;
                }
            }
            return raw + 1;
        }
        int germeira(int[][] mass)
        {
            double[] kefs = { 0.5, 0.3, 0.2 };
            try
            {
                SortedDictionary<int, String> dictionary1 = new SortedDictionary<int, String>();
                SortedDictionary<int, String> dictionary2 = new SortedDictionary<int, String>();
                SortedDictionary<int, String> dictionary3 = new SortedDictionary<int, String>();
                
                for (int i = 0; i < 3; i++)
                {
                    dictionary1.Add((int)(mass[0][i] / kefs[i]), "K" + 1);
                    dictionary2.Add((int)(mass[1][i] / kefs[i]), "K" + 2);
                    dictionary3.Add((int)(mass[2][i] / kefs[i]), "K" + 3);

                }
                SortedDictionary<int, String> finall = new SortedDictionary<int, String>();
                finall.Add(dictionary1.Last().Key, dictionary1.Last().Value);
                finall.Add(dictionary2.Last().Key, dictionary2.Last().Value);
                finall.Add(dictionary3.Last().Key, dictionary3.Last().Value);

                if (dictionary1.ContainsValue(finall.First().Value))
                {
                    return 1;
                }
                if (dictionary2.ContainsValue(finall.First().Value))
                {
                    return 2;
                }
                if (dictionary3.ContainsValue(finall.First().Value))
                {
                    return 3;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                return 3;
            }
        }

        int[][] mass()
        {
            int[][] a;
            try
            {
                a = File.ReadAllText("C:/Projects/Visual Studio/C#/Test/labs/Lab_2.txt")
               .Split(Array.Empty<string>(), StringSplitOptions.RemoveEmptyEntries)
               .Select((s, i) => new { N = int.Parse(s), I = i })
               .GroupBy(at => at.I / 3, at => at.N, (k, g) => g.ToArray())
               .ToArray();
                return a;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());
                return new int[3][];
            }
        }
        public void start()
        {
            int[][] a = mass();
            int[][] b = mass();
            Console.WriteLine("Imported matrix: ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(a[i][j] + " ");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("\nBest raw choise for lemmanne - K" + lemmanne(a));
            Console.WriteLine("\nBest raw choise for germeir - K" + germeira(a));
            Console.WriteLine("\nBest raw choise for lapplase - K" + lapplase(a));
        }
    }
}
