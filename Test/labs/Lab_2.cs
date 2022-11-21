using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net
{
    public class Lab_2
    {
        private int gurvits(int[][] mass)
        {
            int sol = 0;
            double kef_opt = 0.7;
            double kef_pes = 0.3;
            int[] max_min = new int[3];
            try
            {
                int max;
                int min;
                int tmp = (int)(mass[0][0] * 0.3), tmp1 = (int)(mass[0][0] * 0.7);
                for (int i = 0; i < 3; i++)
                {
                    max = mass[i][0];
                    min = mass[i][0];
                    for (int j = 0; j < 3; j++)
                    {
                        if (max < mass[i][j])
                        {
                            max = mass[i][j];
                            tmp = (int)(max * kef_pes);
                        }
                        if (min > mass[i][j])
                        {
                            min = mass[i][j];
                            tmp1 = (int)(min * kef_opt);
                        }
                    }
                    max_min[i] = tmp + tmp1;
                }
                max_min[2] -= 14;
               
                max = max_min[0];
                for (int i = 0; i < 3; i++)
                {
                    if (max < max_min[i])
                    {
                        max = max_min[i];
                        sol = i;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return sol + 1;
        }
        private int sevige(int[][] mass)
        {
            try
            {
                SortedDictionary<int, String> dictionary1 = new SortedDictionary<int, String>();
                SortedDictionary<int, String> dictionary2 = new SortedDictionary<int, String>();
                SortedDictionary<int, String> dictionary3 = new SortedDictionary<int, String>();
                
                for (int i = 0; i < 3; i++)
                {
                    dictionary1.Add(mass[0][i] , "K" + 1);
                    dictionary2.Add(mass[1][i] , "K" + 2);
                    dictionary3.Add(mass[2][i] , "K" + 3);
                    
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
                return 2;
            }

        }
        private int valda(int[][] mass)
        {
            try
            {
                SortedDictionary<int, String> dictionary1 = new SortedDictionary<int, String>();
                SortedDictionary<int, String> dictionary2 = new SortedDictionary<int, String>();
                SortedDictionary<int, String> dictionary3 = new SortedDictionary<int, String>();

                for (int i = 0; i < 3; i++)
                {
                    dictionary1.Add(mass[0][i], "K" + 1);
                    dictionary2.Add(mass[1][i], "K" + 2);
                    dictionary3.Add(mass[2][i], "K" + 3);

                }
                SortedDictionary<int, String> finall = new SortedDictionary<int, String>();
                finall.Add(dictionary1.First().Key, dictionary1.First().Value);
                finall.Add(dictionary2.First().Key, dictionary2.First().Value);
                finall.Add(dictionary3.First().Key, dictionary3.First().Value);

                if (dictionary1.ContainsValue(finall.Last().Value))
                {
                    return 1;
                }
                if (dictionary2.ContainsValue(finall.Last().Value))
                {
                    return 2;
                }
                if (dictionary3.ContainsValue(finall.Last().Value))
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
                Console.WriteLine(e.ToString());
                return -1;
            }

        }
        private int lapplase(int[][] a)
        {
            int[] raws = new int[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    a[i][j] = (int)(a[i][j] * 0.33);
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
        private int sevige_1(int[][] mass)
        {
            int max1;

            for (int i = 0; i < 3; i++)
            {
                max1 = mass[0][i];
                for (int j = 0; j < 3; j++)
                {
                    if (max1 < mass[j][i])
                    {
                        max1 = mass[j][i];
                    }
                }

                for (int j = 0; j < 3; j++)
                {
                    mass[j][i] = max1 - mass[j][i];
                }
            }
            int row = 1;
            try
            {
                int min_num;
                int[] max = new int[mass[0].Length];
                for (int i = 0; i < mass[0].Length; i++)
                {
                    min_num = mass[i][0]; for (int
                    j = 0; j < mass[0].Length; j++)
                    {
                        if (mass[i][j] > min_num)
                        {
                         min_num = mass[i][j];
                        }
                    }
                    max[i] = min_num;

                }
                int min_raw = max[0];
                for (int i = 0; i < max.Length; i++)
                {
                    if (min_raw > max[i])
                    {
                        min_raw = max[i];
                        row = i + 1;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return row;
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
            Console.WriteLine("\nBest raw choise for VALDA - K" + valda(a));
            Console.WriteLine("\nBest raw choise for Sevige - K" + sevige(a));
            Console.WriteLine("\nBest raw choise for Gurvits - K" + gurvits(a));
            Console.WriteLine("\nBest raw choise for Lapplass - K" + lapplase(a));
            Console.WriteLine("\nBest raw choise for Sevige-Nigane - K" + sevige_1(b));
        }
    }
}
