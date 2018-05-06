using System;

namespace Aufgabe1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double size = Convert.ToDouble(args[1]);

            switch (args[0])
            {
                case "w":
                    Console.WriteLine(getCubeInfo(size));
                    break;
                case "k":
                    Console.WriteLine(getSphereInfo(size));
                    break;
                case "o":
                    Console.WriteLine(getOctahedronInfo(size));
                    break;
                default:
                    Console.WriteLine("Verstehe ich nicht");
                    break;
            }

        }
        //Methoden Würfel
        public static double getCubeSurface(double size)
        {
            return Math.Round(6 * (size * size),2);
        }
        public static double getCubeVolume(double size)
        {
            return Math.Round((size * size * size),2);
        }
        public static string getCubeInfo(double size)
        {
            return "A=" + getCubeSurface(size) + " | " + "V=" + getCubeVolume(size);
        }

        //Methoden Kugel
        public static double getSphereSurface(double size)
        {
            return Math.Round(Math.PI * (size * size),2);
        }
        public static double getSphereVolume(double size)
        {
            return Math.Round((Math.PI * (size * size * size)) / 6,2);;
        }
        public static string getSphereInfo(double size)
        {
            return "A=" + getSphereSurface(size) + " | " + "V=" + getSphereVolume(size);
        }

        //Method Oktaeder
        public static double getOctahedronSurface(double size)
        {
            return Math.Round(2 * Math.Sqrt(3) * (size * size),2);
        }
        public static double getOctahedronVolume(double size)
        {
            return Math.Round((Math.Sqrt(2) * (size * size * size)) / 3,2);
        }
        public static string getOctahedronInfo(double size)
        {
            return "A=" + getOctahedronSurface(size) + " | " + "V=" + getOctahedronVolume(size);
        }
    }
}