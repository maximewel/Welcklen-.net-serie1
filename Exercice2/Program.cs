using System;
using System.Diagnostics;
using static System.Console;

namespace Exercice2
{
    class Program
    {
        static void Main(string[] args)
        {
            double A;
            WriteLine("Please enter a number : ");

            //try to safely read a double
            try
            {
                A = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                WriteLine("Could not read/convert your input");
                return;
            }

            //stopwatch to calculate the time
            var watch = System.Diagnostics.Stopwatch.StartNew();
            double root = ApproximateRoot(A, out int count);
            watch.Stop();

            double residualError = Math.Abs(Math.Sqrt(A) - root);

            WriteLine(string.Format("Loops : {0}, time taken : {1}s, residual error : {2}", count, ((double)watch.ElapsedMilliseconds / 1000000), residualError));
        }

        /// <summary>
        /// Approximare the square root of a number through a looping algorithm<br></br>
        /// Stops with precision epsilon = A*10^-9 
        /// </summary>
        /// <param name="A">The number to calculate the root on</param>
        /// <param name="iterationCount">Counter for the iterations made by the loop</param>
        /// <returns>the approximation of the square root of A</returns>
        public static double ApproximateRoot(double A, out int iterationCount)
        {
            //error init
            double error = double.MaxValue;
            double epsilon = A * Math.Pow(10, -9);

            //values init
            double approx = A;
            double lastApprox;
            iterationCount = 0;

            //loop
            while (error >= epsilon)
            {
                lastApprox = approx;
                approx = (approx + A) / (2 * approx);
                error = Math.Abs(approx - lastApprox);
                WriteLine(string.Format("Approximation of sqrt of {0} is {1}", A, approx));
                iterationCount++;
            }

            return approx;
        }
    }
}
