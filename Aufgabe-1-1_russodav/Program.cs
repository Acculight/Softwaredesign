using System;

namespace Aufgabe_1_1
{
    class Program
    {
        static void Main(string[] args)
       {
            var eingb = args[1]; // Liest Eingabe (Durhcmesser)
            double d = Convert.ToDouble(eingb); // Eingabe konvertieren
            
            
            // Eingabe erkennen und nach cases sortieren
            switch (args[0])
            {
                case "w":
                    getCubeInfo(d);
                    break;

                case "k":
                    getSphereInfo(d);
                    break;

                case "o":
                    getOctaInfo(d);
                    break;
            }
        }
        public static double getCubeSurface(double wd)
        {
            double a = 6 * (wd * wd);
            return a;
        }
        public static double getCubeVolume(double wd)
        {
            double v = Math.Pow(wd, 3);
            return v;
        }
        public static double getSphereSurface(double sd)
        {
            double a = (Math.PI * (sd * sd));
            return a;
        }
        public static double getSphereVolume(double sd)
        {
            double v = (Math.PI * (Math.Pow(sd, 3) / 6));
            return v;
        }
        public static double getOctaSurface(double od)
        {
            double a = 2 * (Math.Sqrt(3) * (od * od));
            return a;
        }
        public static double getOctaVolume(double od)
        {
            double v = (Math.Sqrt(2) * (Math.Pow(od, 3) / 3));
            return v;
        }
        public static void getCubeInfo(double d)
        {
            double a = getCubeSurface(d);
            double v = getCubeVolume(d);

            Console.WriteLine("Würfel : A = " + a + "V = " + v);

        }
        public static void getSphereInfo(double d)
        {
            double a = getSphereSurface(d);
            double v = getSphereVolume(d);

            Console.WriteLine("Kugel: A = " + a + "V = " + v);

        }
        public static void getOctaInfo(double d)
        {
            double a = getOctaSurface(d);
            double v = getOctaVolume(d);

            Console.WriteLine("Oktaeder: A = " + a + "V = " + v);
        }
    }

}
