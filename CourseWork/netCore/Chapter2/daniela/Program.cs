using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create an array to hold integer values 0 through 9
            int[] array0Through9 = new int[10] {0,1,2,3,4,5,6,7,8,9};

            // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            string[] arrayNames = new string[4] {"Tim", "Martin", "Nikki", "Sara"};

            // Create an array of length 10 that alternates between true and false values, starting with true
            bool[] boolTo10 = new bool[10] {true, false, true, false, true, false, true, false, true, false};

            // With the values 1-10, use code to generate a multiplication table like the one below.
            int[][] multiarray = {
                new int[] {1,2,3,4,5,6,7,8,9,10},
                new int[] {2,4,6,8,10,12,14,16,18,20},
                new int[] {3,6,9,12,15,18,21,24,27,30},
                new int[] {4,8,12,16,20,24,28,32,36,40},
                new int[] {5,10,15,20,25,30,35,40,45,50},
                new int[] {6,12,18,24,30,36,42,48,54,60},
                new int[] {7,14,21,28,35,42,49,56,63,70},
                new int[] {8,16,24,32,40,48,56,64,72,80},
                new int[] {9,18,27,36,45,54,63,72,81,90},
                new int[] {10,20,30,40,50,60,70,80,90,100}
            };

            int[,] newArrayLOL = new int [10,10];
            int[][] someArray = new int[10][];



            for(int i = 0; i <  10; i++)
            {

                for(int x = 0; x < 10; x++)
                {
                    newArrayLOL[i,x] = (i + 1) * (x + 1);
                }
            }

            for(int i = 0; i <  10; i++)
            {
                Console.Write("[");
                for(int x = 0; x < 10; x++)
                {
                    Console.Write(newArrayLOL[i,x] + ",");
                    if(newArrayLOL[i,x] < 10)
                    {
                        Console.Write(" ");
                    }
                    else if(!(x == 9 && i == 9) && x == 9)
                    {
                        Console.Write(" ");
                    }
                }
                
                Console.Write("]");
                Console.WriteLine(" ");
            }

            // Create a list of 5 ice creams, print the length, print 3rd flavor, remove it and print the length again.
            List<string> icecreams = new List<string>();
            icecreams.Add("Vanilla");
            icecreams.Add("Chocolate");
            icecreams.Add("StrawBerry");
            icecreams.Add("Cookies & Cream");
            icecreams.Add("Chocolate Chip");

            Console.WriteLine(icecreams.Count);
            Console.WriteLine(icecreams[2]);
            icecreams.RemoveAt(2);
            Console.WriteLine(icecreams.Count);

            // dictionary with string key and values, 
            Dictionary<string,string> mydic = new Dictionary<string,string>();
            mydic.Add("Tim", null);
            mydic.Add("Martin", null);
            mydic.Add("Nikki", null);
            mydic.Add("Sara", null);

            Console.WriteLine("Print the dictionary part!");

            Random rand = new Random();
            foreach(var something in arrayNames){
                mydic[something] = icecreams[rand.Next(icecreams.Count)];
            }
            foreach(KeyValuePair<string, string> entry in mydic)
            {
                Console.WriteLine(entry.Key + " " + entry.Value);
            }
        }
    }
}
