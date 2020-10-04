using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercice4
{
    /// <summary>
    /// From the exercise sheet :
    /// "The pairImpair function accept 1 tab in"
    /// I took it as "accepts ONE AND ONLY ONE tab of int", so i worked around that limitation to build my function
    /// that's why i don't juste use 2 "out int[] pair, out int[] impair" in the function. I return on as the input, one as the return
    /// maybe i didn't understand it well and it wasn't a hard limitation ?
    /// EDIT : changed input as output to a more elegent tuple output (A,B)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] randomTab = new int[20];
            FillRandom(randomTab, 100);

            Console.WriteLine("Initial array");
            PrintTab(randomTab);

            //call pair/impair : Randomtab is now composed of the "pair" part, we get impar back from the function
            (int[] pairTab,int[] impairTab) = PairImpair(randomTab);
            //standard output
            Console.WriteLine($"pair : [{string.Join(", ", pairTab)}]");
            Console.WriteLine($"impair : [{string.Join(", ", impairTab)}]");
        }

        /// <summary>
        /// Fill a given array with random number [0-max]
        /// </summary>
        /// <param name="tab">The array to fill</param>
        /// <param name="max">The max value of the random numbers to insert</param>
        public static void FillRandom(int[] tab, int max)
        {
            var rand = new Random();

            foreach (int i in Enumerable.Range(0, tab.Length))
            {
                tab[i] = rand.Next() % 100;
            }
        }

        /// <summary>
        /// print an array on console
        /// </summary>
        /// <param name="tab">The array to print</param>
        public static void PrintTab(int[] tab)
        {
            Console.WriteLine("Array : [{0}]", string.Join(", ", tab));
        }

        /// <summary>
        /// Take an array, and separates it into two arrays of pair/impair numbers<br></br>
        /// Time efficient, but not in place (will create 2 list, size(l1+l2) = sizeof input tab
        /// </summary>
        /// <param name="tabToPair">The original array to separate</param>
        /// <returns>The "pair/impair" part of the original array as an array</returns>
        public static (int[], int[]) PairImpair(int[] tabToPair)
        {
            //create two list : We will do a process akin to a reverse "merge sort" where we append our number to one of the two lists
            List<int>[] mappedList = { new List<int>(), new List<int>() };
            foreach (int nb in tabToPair)
            {
                mappedList[nb % 2].Add(nb); //index 0 = pair list, 1 = impair list (elegant, one line)
            }
            //pair/mpair list-to-array
            return (mappedList[0].ToArray(), mappedList[1].ToArray()) ;         
        }
    }
}
