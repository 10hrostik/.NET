using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net
{
    public class Lab_4
    {      
        private double[] getMass()
        {
            String[] a;
            double[] mass = new double[14];
            try
            {
                a = File.ReadAllLines("C:/Projects/Visual Studio/C#/Test/labs/Lab_4.txt");
                for (int i = 0; i < 14; i++)
                {
                    mass[i] = Double.Parse(a[i]);
                }
                return mass;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());
                return new double[14];
            }

        }
        private void buildTree(double[] mass)
        {
            List<TreeNode> list = new List<TreeNode>();
            int i = 0;
            int j = 0;
            while (i <= mass.Length - 5)
            {
                list.Add(new TreeNode(j + 1, mass[0 + i], mass[1 + i] * 5, mass[3 + i] * 5, mass[2 + i], mass[4 + i], " NOW"));
                i += 5;
                j++;
            }
            i = 0;
            j = 0;
            while (i <= mass.Length - 5)
            {
                list.Add(new TreeNode(j + 1, mass[0 + i], mass[1 + i] * 4, mass[3 + i] * 4, mass[10] * mass[12], mass[10] * mass[13], " AFTER a YEAR"));
                i += 5;
                j++;
            }
            list.Sort(new Comparator());
            foreach(TreeNode node in list)
            {
                Console.WriteLine(node.ToString());
            }
            Console.WriteLine("\nBest Choise : " + list.Last().ToString());
        }
        public void start()
        {
            double[] a = getMass();
            for (int i = 0; i < 14; i++)
            {
                Console.WriteLine(a[i] + " ");
            }
            buildTree(a);
        }
    }
    class TreeNode : IComparable<TreeNode>
    {
        private double income;
        private double loss;
        private double kef1;
        private double kef2;
        private double price;
        private int ID;
        private String deal;

        public TreeNode(int id, double price, double income, double loss, double kef1, double kef2, String deal)
        {
            this.income = income;
            this.loss = loss;
            this.price = price;
            this.kef1 = kef1;
            this.kef2 = kef2;
            this.ID = id;
            this.deal = deal;
        }
        public int CompareTo(TreeNode comp)
        {
            return diffCalc().CompareTo(comp.diffCalc());
        }
        public double diffCalc()
        {
            return this.income * this.kef1 + this.loss * this.kef2 - price;
        }      
        public override String ToString()
        {
            return " ID :" + ID + " When :" + deal + " Cost : " + price + " Possible income " + income + " with kef " + kef1 + " Possibleloss "+loss +" with kef "+kef2+" Total: "+diffCalc()+"\n";
        }

    }
    class Comparator : IComparer<TreeNode>
    {
        public int Compare(TreeNode x, TreeNode y)
        {
            if (x.diffCalc().CompareTo(y.diffCalc()) != 0)
            {
                return x.diffCalc().CompareTo(y.diffCalc());
            }
            else
            {
                return 0;
            }
        }
    }
}
