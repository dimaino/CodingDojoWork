using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human h1 = new Human("Richard");
            h1.PrintAttributes();
            Human h2 = new Human("Big-Rick", 10, 10, 10, 10000);
            h2.PrintAttributes();
            h1.Attack(h2);
            h2.PrintAttributes();
            h2.Attack(h1);
            h1.PrintAttributes();
        }
    }
}
