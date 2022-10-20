namespace Test
{
    public abstract class Mammal
    {
        private int age;
        public Mammal(int age)
        {
            this.age = age;
        }
        public int getAge() 
        { 
            return age; 
        }
        public override string ToString()
        {
            return " Age : " + age;
        }
        public abstract void move();
    }
}
