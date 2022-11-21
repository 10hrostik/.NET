using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net
{
    public class Lab_5
    {
        public int[][] getNewMass(int[][] mass)
        {
            int[][] newMass = new int[5][];
            int[][] tmp = new int[5][];
            for(int i=0; i<5; i++)
            {
                newMass[i] = new int[5];
                tmp[i] = new int[5];
            }
            int k = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = 0; j < mass.Length; j++)
                {
                    if (!isRawDominate(mass[i], mass[j]))
                    {
                        tmp[k] = mass[i];
                    }
                }
                k++;
            }
            k = 0;
            List<int> list = new List<int>();
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = 0; j < mass[0].Length; j++)
                {
                    list.Add(tmp[j][i]);
                }
            }
            int[][] temp = new int[5][];
            int z = 0;
            for (int i = 0; i < 5; i++)
            {
                temp[i] = new int[5];
            }
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = 0; j < mass[0].Length; j++)
                {
                    temp[i][j] = list.ElementAt(z);
                    z++;
                }
            }
            int[][] temp1 = new int[5][];
            for (int i = 0; i < 5; i++)
            {
                temp1[i] = new int[5];
            }
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = 0; j < mass.Length; j++)
                {
                    if (!isRawDominate(temp[i], temp[j]))
                    {
                        temp1[k] = temp[i];
                    }
                }
                k++;
            }
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = 0; j < mass[0].Length; j++)
                {
                    newMass[i][j] = temp1[j][i];
                }
            }
            return newMass;
        }

        public int getMinMax(int[][] mass)
        {
            try
            {
                List<int> dictionary1 = new List<int>();
                List<int> dictionary2 = new List<int>();
                List<int> dictionary3 = new List<int>();
                List<int> dictionary4 = new List<int>();
                List<int> dictionary5 = new List<int>();

                for (int i = 0; i < 5; i++)
                {
                    dictionary1.Add(mass[0][i]);
                    dictionary2.Add(mass[1][i]);
                    dictionary3.Add(mass[2][i]);
                    dictionary4.Add(mass[3][i]);
                    dictionary5.Add(mass[4][i]);
                }
                dictionary1.Sort();
                dictionary2.Sort();
                dictionary3.Sort();
                dictionary4.Sort();
                dictionary5.Sort();

                List<int> finall = new List<int>();
                finall.Add(dictionary1.First());
                finall.Add(dictionary2.First());
                finall.Add(dictionary3.First());
                finall.Add(dictionary4.First());
                finall.Add(dictionary5.First());
                finall.Sort();

                if (dictionary1.Contains(finall.Last()))
                {
                    return finall.Last();
                }
                if (dictionary2.Contains(finall.Last()))
                {
                    return finall.Last();
                }
                if (dictionary3.Contains(finall.Last()))
                {
                    return finall.Last();
                }
                if (dictionary4.Contains(finall.Last()))
                {
                    return finall.Last();
                }
                if (dictionary5.Contains(finall.Last()))
                {
                    return finall.Last();
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public int[][] getTranspMatrix(int[][] mass)
        {
            int[][] tmp = new int[mass[0].Length][];
            for (int i = 0; i < 5; i++)
            {
                tmp[i] = new int[5];
            }
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = 0; j < mass[0].Length; j++)
                {
                    tmp[i][j] = mass[j][i];
                }
            }
            return tmp;
        }

        public int getMaxMin(int[][] mass)
        {
            try
            {
                List<int> dictionary1 = new List<int>();
                List<int> dictionary2 = new List<int>();
                List<int> dictionary3 = new List<int>();
                List<int> dictionary4 = new List<int>();
                List<int> dictionary5 = new List<int>();
               
                for (int i = 0; i < 5; i++)
                {
                    dictionary1.Add(mass[0][i]);
                    dictionary2.Add(mass[1][i]);
                    dictionary3.Add(mass[2][i]);
                    dictionary4.Add(mass[3][i]);
                    dictionary5.Add(mass[4][i]);
                }
                dictionary1.Sort();
                dictionary2.Sort();
                dictionary3.Sort();
                dictionary4.Sort();
                dictionary5.Sort();

                List<int> finall = new List<int>();
                finall.Add(dictionary1.Last());
                finall.Add(dictionary2.Last());
                finall.Add(dictionary3.Last());
                finall.Add(dictionary4.Last());
                finall.Add(dictionary5.Last());
                finall.Sort();

                if (dictionary1.Contains(finall.First()))
                {
                    return finall.First();
                }
                if (dictionary2.Contains(finall.First()))
                {
                    return finall.First();
                }
                if (dictionary3.Contains(finall.First()))
                {
                    return finall.First();
                }
                if (dictionary4.Contains(finall.First()))
                {
                    return finall.First();
                }
                if (dictionary5.Contains(finall.First()))
                {
                    return finall.First();
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                return -1;
            }

        }
        public int[][] getMass()
        {
            int[][] a;
            try
            {
                a = File.ReadAllText("C:/Projects/Visual Studio/C#/Test/labs/Lab_7.txt")
               .Split(Array.Empty<string>(), StringSplitOptions.RemoveEmptyEntries)
               .Select((s, i) => new { N = int.Parse(s), I = i })
               .GroupBy(at => at.I / 5, at => at.N, (k, g) => g.ToArray())
               .ToArray();
                return a;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());
                return new int[3][];
            }
        }
        public void findStrategy(int[][] mass, char playrID)
        {
            List<double> list = new List<double>();

            int differ = 0, differ1 = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = 0; j < mass[0].Length; j++)
                {
                    if (i == j)
                    {
                        differ += mass[i][j];
                    }
                }
            }
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = 0; j < mass[0].Length; j++)
                {
                    if (mass.Length - 1 - i == j)
                    {
                        differ1 += mass[i][j];
                    }
                }
            }

            differ = Math.Abs(differ - differ1);

            double sum = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = 0; j < mass[0].Length; j++)
                {
                    sum += mass[i][j];
                }
                list.Add((sum / differ));
                sum = 0;
            }
            Console.WriteLine("Shuffled strategy for player " + playrID + " is = " + list.ElementAt(0) + " " +
                list.ElementAt(1) + " " + list.ElementAt(2) + " " + list.ElementAt(3) + " " + list.ElementAt(4));
        }
        private bool isRawDominate(int[] mass, int[] mass1)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] > mass1[i])
                {
                    return false;
                }
            }
            return true;
        }
        public void start()
        {

            int[][] a = getMass();
            Console.WriteLine("Imported matrix: ");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(a[i][j] + " ");
                }
                Console.WriteLine("\n");
            }
            int[][] b = getNewMass(a);
            Console.WriteLine("\nNew mass: ");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(b[i][j] + " ");
                }
                Console.WriteLine("\n");
            }
            if (getMaxMin(b) != getMinMax(getTranspMatrix(b)))
            {
                Console.WriteLine("\nMax-Min for player A : " + getMaxMin(b));
                Console.WriteLine("Min-Max for player B : " +
                        getMinMax(getTranspMatrix(b)));
                Console.WriteLine("Game has no saddle point!");
                findStrategy(b, 'A');
                findStrategy(getTranspMatrix(b), 'B');
            }
            else
            {
                Console.WriteLine("\nBest strategy for player A : " +
                       getMaxMin(b));
                Console.WriteLine("Best strategy for player B : " +
                        getMinMax(getTranspMatrix(b)));
                Console.WriteLine("Game has saddle point!");
            }
        }
    }
}
