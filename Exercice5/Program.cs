using System;

namespace Exercice5
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Hello World"; 
            string s2 = "Hello World"; 
            string s3 = s1;

            TestStrings(s1, s2, s3);

            s3 += "!";
            Console.WriteLine("Changing s3 with !");

            TestStrings(s1, s2, s3);
        }

        /// <summary>
        /// Test 3 string using PrintDiff
        /// </summary>
        /// <param name="s1">String 1</param>
        /// <param name="s2">String 2</param>
        /// <param name="s3">String 3</param>
        public static void TestStrings(string s1, string s2, string s3)
        {
            Console.WriteLine($"testing s1={s1} and s2={s2}");
            PrintDiff(s1, s2);
            Console.WriteLine($"\ntesting s1={s1} and s3={s3}");
            PrintDiff(s1, s3);
            Console.WriteLine($"\ntesting s2={s2} and s3={s3}");
            PrintDiff(s2, s3);
            Console.Write("\n\n");
        }

        /// <summary>
        /// Print the result of operations '==', 'compareTo' and 'referenceequals' from string
        /// </summary>
        /// <param name="s1">First string to compare</param>
        /// <param name="s2">Second string to compare</param>
        public static void PrintDiff(string s1, string s2)
        {
            Console.WriteLine($"{s1} = {s2} : {s1 == s2}");
            Console.WriteLine($"{s1} compareto {s2} : {s1.CompareTo(s2)}");
            Console.WriteLine($"{s1} reference equal {s2} : {string.ReferenceEquals(s1, s2)}");
        }
    }

    ///results : there seem to be a pool of string akin to the python gestion :
    ///s1 is equal to s2, all the time, despite beeing created apart (s1=hello world and s2=hello world).
    ///s1=s3 gives s3 the same reference, but upon changing s3, s1 stays the same and s3!=s1 : changing
    ///a string seems to create another instance of string and doesnt change the s1 string
    ///Conclusion : Probably a pool of shared strings, "string" seems immutable (create another instance upon change)
    ///-> think stringbuilder if we want to assemble a long string would be smart
}
