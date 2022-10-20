namespace Test
{
    public static class Program
    {
        public static void Main()
        {
            Mammal man = new Human(20, "Rostik");
            Mammal child = new Child(4, "Anya", 1);

            Console.WriteLine(allToString(man,child));

            man.move();
            child.move();
        }
        private static string allToString(Mammal mammal1, Mammal mammal2)
        {
            return mammal1.ToString() + "\n" + mammal2.ToString();
        }
    }
}

