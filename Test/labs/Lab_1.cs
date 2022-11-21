using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net
{
    public class Lab_1
    {
        private bool isTransitive(int[][] a)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        if (a[i][j] == 1 && a[j][k] == 1 && a[i][k] != 1)
                        {
                             return false;
                        }
                    }
                }
            }
            return true;
        }
        bool isSymetric(int[][] a)
        {
            List<int> a1 = new List<int>();
            List<int> a2 = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    a1.Add(a[i][j]);
                    a2.Add(a[j][i]);
                }
            }
            return a1.Equals(a2);
        }
        bool isASymetric(int[][] a)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (a[i][j] == a[j][i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        bool isReflex(int[][] a)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == j && a[i][j] != 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        bool isAreflex(int[][] a)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == j && a[i][j] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        int[][] mass()
        {
            int[][] a;
            try
            {
                a = File.ReadAllText("C:/Projects/Visual Studio/C#/Test/labs/Lab_1.txt")
               .Split(Array.Empty<string>(), StringSplitOptions.RemoveEmptyEntries)
               .Select((s, i) => new { N = int.Parse(s), I = i })
               .GroupBy(at => at.I / 5, at => at.N, (k, g) => g.ToArray())
               .ToArray();
                return a;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());
                return new int[5][];
            }
        }
        public void start()
        {
            int[][] a = mass();
            Console.WriteLine("Imported matrix: ");
            for (int i = 0;i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    Console.Write(a[i][j]);
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("==============================");
            Console.WriteLine("Matrix is reflex? - " + isReflex(a));
            Console.WriteLine("Matrix is antireflex? -" + isAreflex(a));
            if (isSymetric(a))
            {
                Console.WriteLine("Matrix is symetric? -" + isSymetric(a));
            }
            else
            {
                Console.WriteLine("Matrix is antisymetric? -" + isASymetric(a));
                Console.WriteLine("Matrix is asymetric? -" + (isASymetric(a) && isAreflex(a)));
            }
            Console.WriteLine("Matrix is transitive? -" + isTransitive(a));
        }
    }
}
