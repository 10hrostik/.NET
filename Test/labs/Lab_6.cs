using oop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace net
{
    public class Lab_6
    {
        public void start()
        {
            List<Amplifier> list = new List<Amplifier>();
            Amplifier amp1 = new Amplifier("Marshall", 30, "Wood", "Transistor", 5);
            Amplifier amp2 = new Amplifier("Fender", 50, "Plastic", "Bulb", 10);
            Amplifier amp3 = new Amplifier("Orange", 25, "Steel", "Transistor", 8);

            list.Add(amp1);
            list.Add(amp2);
            list.Add(amp3);

            Console.WriteLine("Best solution by Rate 1 :");
            list.Sort(new AmpComparer1());
            foreach(Amplifier amp in list)
            {
                Console.WriteLine(amp.ToString());
            }
            Console.WriteLine("\nBest solution by Rate 2 :");
            list.Sort(new AmpComparer2());
            foreach (Amplifier amp in list)
            {
                Console.WriteLine(amp.ToString());
            }
            Console.WriteLine("\nBest solution by Rate 3 :");
            list.Sort(new AmpComparer3());
            foreach (Amplifier amp in list)
            {
                Console.WriteLine(amp.ToString());
            }
        }
    }
    class Amplifier
    {
        private String name;
        private int powerWatt;
        private String material;
        private String type;
        private int effectCount;
        public double rate = 0;

        public Amplifier(String name, int powerWatt, String material, String type, int effectCount)
        {
            this.name = name;
            this.powerWatt = powerWatt;
            this.material = material;
            this.type = type;
            this.effectCount = effectCount;
        }
        public double getRate(double k1, double k2, double k3, double k4)
        {
            rate = Math.Abs(powerWatt * k1 + material.GetHashCode() * k2 / 100000 + type.GetHashCode() * k3 / 100000 + effectCount * k4)/10;
            return rate;
        }
        public override String ToString()
        {
            return name + " " + powerWatt + "W " + material + " " + type + " " + effectCount + " Rate = " + rate;
        }
    }
    class AmpComparer1 : IComparer<Amplifier> 
    {
        public int Compare(Amplifier amp1,  Amplifier amp2)
        {
            if (amp1.getRate(0.25, 0.25, 0.25, 0.25).CompareTo(amp2.getRate(0.25, 0.25, 0.25, 0.25)) != 0)
            {
                return amp1.getRate(0.25, 0.25, 0.25, 0.25).CompareTo(amp2.getRate(0.25, 0.25, 0.25, 0.25)) * -1;
            }
            else
            {
                return 0;
            }
        }
    }
    class AmpComparer2 : IComparer<Amplifier>
    {
        public int Compare(Amplifier amp1, Amplifier amp2)
        {
            if (amp1.getRate(0.5, 0.25, 0.125, 0.125).CompareTo(amp2.getRate(0.5, 0.25, 0.125, 0.125)) != 0)
            {
                return amp1.getRate(0.5, 0.25, 0.125, 0.125).CompareTo(amp2.getRate(0.5, 0.25, 0.125, 0.125)) * -1;
            }
            else
            {
                return 0;
            }
        }
    }
    class AmpComparer3 : IComparer<Amplifier>
    {
        public int Compare(Amplifier amp1, Amplifier amp2)
        {
            if (amp1.getRate(0.25, 0.25, 0.25, 0.25).CompareTo(amp2.getRate(0.25, 0.25, 0.25, 0.25)) != 0)
            {
                return amp1.getRate(0.5, 0.125, 0.25, 0.125).CompareTo(amp2.getRate(0.5, 0.125, 0.25, 0.125)) * -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
