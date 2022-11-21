namespace oop
{
    public class Human : Mammal
    {
        private string name;
        public Human(int age, string name) : base(age)
        {
            this.name = name;
        }
        public string getName()
        {
            return name;
        }
        public override string ToString()
        {
            return "Name : " + name + base.ToString();
        }
        public override void move()
        {
            Console.WriteLine("I'm walking");
        }
    }
}
