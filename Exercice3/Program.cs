using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Console;

namespace Exercice3
{
    class Program
    {
        /// <summary>10</summary>
        const int MESURE_PER_LINE = 10;

        static void Main(string[] args)
        {
            // get file path with verbatime string
            string fileName = @".\Mesures.txt";

            //safely open file
            StreamReader sr;
            FileStream fs;
            try
            {
                fs = File.OpenRead(fileName);
                sr = new StreamReader(fs);
            }
            catch (Exception)
            {
                WriteLine("Problem while opening file");
                return;
            }

            //read file
            ReadWithInterpolation(sr);
            sr.Close();
        }

        /// <summary>
        /// Read the given file and print it on the output using string interpolation, <inheritdoc cref="MESURE_PER_LINE"/> mesure per line
        /// </summary>
        /// <param name="sr">Filestream to read from</param>
        public static void ReadWithInterpolation(StreamReader sr)
        {
            Console.WriteLine("Reading with string interpolation ($)");

            //init values
            int countMesureOnLine = 0;
            string readMesure;

            //loop on file
            while ((readMesure = sr.ReadLine()) != null)
            {
                if (countMesureOnLine == MESURE_PER_LINE - 1)
                {
                    WriteLine($"{readMesure}");
                }
                else
                {
                    Write($"{readMesure}{(sr.EndOfStream?"":",")} ");
                }
                countMesureOnLine = (++countMesureOnLine) % MESURE_PER_LINE;
            }
        }
    }
}
