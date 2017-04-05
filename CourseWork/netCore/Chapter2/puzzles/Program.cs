using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {

            int[] ranArr = RandomArray();
            Random rand = new Random();
            double ratio = TossMultipleCoins(10);
            Console.WriteLine(ratio);
            Name();
        }
        public static int[] RandomArray()
        {
            Random rand = new Random();
            int[] randArr = new int[10];
            int max = 0;
            int min = 30;
            int sum = 0;
            for(int i = 0; i < randArr.Length; i++)
            {
                randArr[i] = rand.Next(5,25);
            }
            Console.Write("[");
            foreach(var i in randArr)
            {
                if(i > max)
                {
                    max = i;
                }
                if(i < min)
                {
                    min = i;
                }
                sum += i;
                Console.Write(i + ",");
            }
            Console.Write("]\n");
            Console.WriteLine("Max: " + max);
            Console.WriteLine("Min: " + min);
            Console.WriteLine("Sum: " + sum);
            return randArr;
        }
        
        public static string TossCoin(Random rand)
        {
            string str = "";
            Console.WriteLine("Tossing a Coin!");
            int r = rand.Next(0,20);
            Console.WriteLine(r);
            if(r > 10)
            {
                Console.WriteLine("Heads");
                str = "Heads";
            }
            else
            {
                Console.WriteLine("Tails");
                str = "Tails";
            }
            return str;
        }
        public static double TossMultipleCoins(int num)
        {
            double heads = 0;
            Random rn = new Random();
            for(int i = 0; i < num; i++)
            {

                if(TossCoin(rn) == "Heads")
                {
                    heads++;
                }
            }
            double ratioforhvt = heads/num;
            return ratioforhvt;
        }

        public static string[] Name()
        {  
            string[] strArr = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            Random rand = new Random();
            for(int i = 0; i < strArr.Length; i++)
            {
                int ran = rand.Next(i - 1, strArr.Length);
                string temp = strArr[i];
                strArr[i] = strArr[ran];
                strArr[ran] = temp; 
            }
            foreach(var i in strArr)
            {
                Console.WriteLine(i);
            }
            return strArr;
        }
    }
}
