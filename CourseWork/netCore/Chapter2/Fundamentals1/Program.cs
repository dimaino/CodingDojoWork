using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for(int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }
            for(int i = 1; i <= 100; i++)
            {
                if(!(i % 15 == 0))
                {
                    if(i % 3 == 0)
                    {
                        Console.WriteLine(i);
                    }
                    if(i % 5 == 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            for(int i = 1; i <= 100; i++)
            {
                if(i % 5 == 0 && i % 3 == 0)
                {
                    Console.WriteLine("FizzBuzz" + i);
                }
                else if(i % 3 == 0)
                {
                    Console.WriteLine("Fizz: " + i);
                }
                else if(i % 5 == 0)
                {
                    Console.WriteLine("Buzz: " + i);
                }
            }
            
            int num1 = 3;
            int num2 = 5;

            for(int i = 1; i <= 100; i++)
            {
                num1--;
                num2--;
                if(num1 == 0 && num2 == 0)
                {
                    Console.WriteLine("FizzBuzz" + i);
                }
                else if(num1 == 0)
                {
                    Console.WriteLine("Fizz: " + i);
                    num1 = 3;
                }
                else if(num2 == 0)
                {
                    Console.WriteLine("Buzz: " + i);
                    num2 = 5;
                }
            }

            Random rand = new Random();
            for(int i = 1; i <= 100; i++)
            {
                int r = rand.Next(1, 100);
                string str = "For attempt " + i + " the value is " + r;

                if(r % 3 == 0 && r % 5 == 0)
                {
                    str += " FizzBuzz";
                }
                else if(r % 3 == 0)
                {
                    str += " Fizz";
                }
                else if(r % 5 == 0)
                {
                    str += " Buzz";
                }
                Console.WriteLine(str);
            }
        }
    }
}