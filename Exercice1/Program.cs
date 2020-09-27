using System;

namespace Exercice1
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3D p1 = new Point3D(2, 3, 4);
            Point3D p2 = new Point3D(10, 15, 20);

            Console.WriteLine(string.Format("P1 : {0} d = {1}, P2 : {2} d = {3}", p1, p1.DistanceToOrigin(), p2, p2.DistanceToOrigin()));

            Point3D.SwapPoint(ref p1, ref p2);

            Console.WriteLine(string.Format("P1 : {0} d = {1}, P2 : {2} d = {3}", p1, p1.DistanceToOrigin(), p2, p2.DistanceToOrigin()));
        }
    }

    /// <summary>
    /// A simple data class
    /// 
    /// </summary>
    struct Point3D
    {
        public double x, y, z;

        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// calculate the distance from point to origin as the amplitude of the vector - euclidian definition
        /// </summary>
        /// <returns>distance as a double</returns>
        public double DistanceToOrigin()
        {
            return Math.Sqrt(Math.Pow(x,2)+Math.Pow(y,2)+Math.Pow(y,2));
        }

        public override string ToString()
        {
            return string.Format("Point ({0},{1},{2})", x, y, z);
        }

        /// <summary>
        /// swap the coordinates of 2 points<br></br>
        /// points are structure - references are there to ensure they are not copied into the function
        /// </summary>
        /// <param name="p1">first point to swap</param>
        /// <param name="p2">second point to swap</param>
        public static void SwapPoint(ref Point3D p1, ref Point3D p2)
        {
            double tempX = p1.x, tempY = p1.y, tempZ = p1.z;
            p1.x = p2.x;
            p1.y = p2.y;
            p1.z = p2.z;
            p2.x = tempX;
            p2.y = tempY;
            p2.z = tempZ;
        }

    }
}
