using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<object> BoxedData = new List<object>();
            BoxedData.Add(7);
            BoxedData.Add(28);
            BoxedData.Add(-1);
            BoxedData.Add(true);
            BoxedData.Add("chair");
            int sum = 0;
            foreach(var somestuff in BoxedData)
            {
                if(somestuff is int)
                {
                    sum += (int)somestuff;
                    //Console.WriteLine(BoxedData)
                }
                if(somestuff is string)
                {
                    Console.WriteLine("String value!");
                }
                if(somestuff is bool)
                {
                    Console.WriteLine("Bool value!");
                }
                
            }
            Console.WriteLine(sum);
        }
    }
}
