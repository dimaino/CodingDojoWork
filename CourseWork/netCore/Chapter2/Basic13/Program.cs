using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            print1to255();
            printodd1to255();
            printSum();
            int[] arr1 = {1,2,3,45,546,546,43,-50};
            ItterateArrayarr(arr1);
            int theMax = findMax(arr1);
            Console.WriteLine(theMax);
            getAverageint(arr1);
            ArrayOddNums();
            Console.WriteLine(GreaterThanY(arr1, 50));
            SquareTheVals(arr1);
            ElimNegatives(arr1);
            MinMaxAvg(arr1);
            ShiftVals(arr1);
            object[] arro = {1,2,3,45,546,546,43,-50};
            NumberToString(arro);
        }
        // Write a program (sets of instructions) that would print all the numbers from 1 to 255.
        public static void print1to255(){
            for(int i = 1; i <= 255; i++)
            {
                Console.Write(i + ", ");
            }
        }

        // Write a program (sets of instructions) that would print all the odd numbers from 1 to 255.
        public static void printodd1to255()
        {
            for(int i = 1; i <= 255; i+=2)
            {
                Console.Write(i + ", ");
            }
        }

        // Write a program that would print the numbers from 0 to 255 but this time, it would also print the sum of the numbers that have been printed so far. For example, your output should be something like this:
        public static void printSum()
        {
            int sum = 0;
            for(int i = 1; i <= 255; i++)
            {
                sum += i;
                Console.WriteLine("New Number: " + i + " Sum: " + sum);
            }
        }

        // Given an array X, say [1,3,5,7,9,13], write a program that would iterate through each member of the array and print each value on the screen. Being able to loop through each member of the array is extremely important.
        public static void ItterateArrayarr(int[] arr)
        {
            foreach(var i in arr)
            {
                Console.WriteLine(i);
            }
        }

        //Write a program (sets of instructions) that takes any array and prints the maximum value in the array. Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), or even a mix of positive numbers, negative numbers and zero.
        public static int findMax(int[] arr)
        {
            int max = arr[0];
            foreach(var i in arr)
            {
                if(i > max)
                {
                    max = i;
                }
            }
            return max;
        }

        //Write a program that takes an array, and prints the AVERAGE of the values in the array. For example for an array [2, 10, 3], your program should print an average of 5. Again, make sure you come up with a simple base case and write instructions to solve that base case first, then test your instructions for other complicated cases. You can use a count function with this assignment.
        public static void getAverageint(int[] arr)
        {
            int average = arr[0];
            foreach(var i in arr)
            {
                average += i;
            }
            average = average/arr.Length;
        }

        // Write a program that creates an array 'y' that contains all the odd numbers between 1 to 255. When the program is done, 'y' should have the value of [1, 3, 5, 7, ... 255].
        public static void ArrayOddNums()
        {
            int[] arr = new int[400];
            Console.Write("[");
            for(int i = 1; i <= 255; i++)
            {
                if(i % 2 == 1)
                {
                    arr[i] = i;
                    Console.Write(arr[i] + ",");
                }
                
            }
            Console.Write("]");
        }

        // Write a program that takes an array and returns the number of values in that array whose value is greater than a given value y. For example, if array = [1, 3, 5, 7] and y = 3. After your program is run it will print 2 (since there are two values in the array that are greater than 3).
        public static int GreaterThanY(int[] arr, int someNum)
        {
            int sum = 0;
            foreach(var i in arr)
            {
                if(someNum < i)
                {
                    sum++;
                }
            }

            return sum;
        }

        // Given any array x, say [1, 5, 10, -2], create an algorithm (sets of instructions) that multiplies each value in the array by itself. When the program is done, the array x should have values that have been squared, say [1, 25, 100, 4].
        public static void SquareTheVals(int[] arr)
        {
            int[] arr3 = new int [arr.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                arr3[i] = arr[i] * arr[i];
                Console.WriteLine(arr3[i]);
            }
        }

        //Given any array x, say [1, 5, 10, -2], create an algorithm that replaces any negative number with the value of 0. When the program is done, x should have no negative values, say [1, 5, 10, 0].
        public static void ElimNegatives(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] < 0)
                {
                    arr[i] = 0;
                }
                Console.WriteLine(arr[i]);
            }
        }

        // Given any array x, say [1, 5, 10, -2], create an algorithm that prints the maximum number in the array, the minimum value in the array, and the average of the values in the array.
        public static void MinMaxAvg(int[] arr)
        {
                int min = arr[0];
                int max = arr[0];
                int average = arr[0];
            for(int i = 1; i < arr.Length; i++)
            {
                if(arr[i] < min)
                {
                    min = arr[i];
                }
                if(arr[i] > max)
                {
                    max = arr[i];
                }
                average += arr[i];
            }
            average = average/arr.Length;
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine(average);

        }

        // Given any array x, say [1, 5, 10, 7, -2], create an algorithm that shifts each number by one to the front and adds '0' to the end. For example, when the program is done,  if the array [1, 5, 10, 7, -2] is passed to the function, it should become [5, 10, 7, -2, 0].
        public static void ShiftVals(int[] arr)
        {
            for(int i = 1; i < arr.Length; i++)
            {
                arr[i - 1] = arr[i];
            }
            arr[arr.Length - 1] = 0;
            foreach(var i in arr)
            {
                Console.Write(i + ",");
            }
        }

        // Write a program that takes an array of numbers and replaces any negative number with the string 'Dojo'. For example, if array x is initially [-1, -3, 2] your function should return an array with values ['Dojo', 'Dojo', 2].
        public static void NumberToString(object[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if((int)arr[i] < 0)
                {
                    arr[i] = "Dojo";
                }
            }
            foreach(var i in arr)
            {
                Console.Write(i + ",");
            }
        }

    }
}
