using oop;

namespace Test
{
    public class Child : Human
    {
        private int grade;
        public Child(int age, String name, int grade) : base(age, name)
        {
            this.grade = grade;
        }
        public int getGrade()
        {
            return grade;
        }
        public override string ToString()
        {
            return base.ToString() + " Grade : "+grade;
        }
        public override void move()
        {
            Console.WriteLine("I'm crawling");
        }
    }
}
