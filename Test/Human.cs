namespace Test
{
    public class Human : Mammal
    {
        private String name;
        public Human(int age, String name) : base(age)
        {
            this.name = name;
        }
        public String getName()
        {
            return name;
        }
        public override string ToString()
        {
            return "Name : "+ name + base.ToString();
        }
        public override void move()
        {
            Console.WriteLine("I'm walking");
        }
    }
}
