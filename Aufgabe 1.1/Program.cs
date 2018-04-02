using System;

namespace Aufgabe_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var Num = args[1];
            double d = Convert.ToDouble(Num);
            double a = 0;
            double v = 0;
            switch (args[0])
            {
                case "w":
                    Console.WriteLine("Würfeldaten werden berechnet.");
                    a = getWürfelSurface(d);
                    v = getWürfelVolumen(d);
                    Console.WriteLine("Würfel:   A=" + Math.Round(a, 2) + "  | " + " V=" + Math.Round(v, 2));
                    break;

                case "k":
                    Console.WriteLine("Kugeldaten werden berechnet.");
                    a = getKugelSurface(d);
                    v = getKugelVolumen(d);
                    Console.WriteLine("Kugel:   A=" + Math.Round(a, 2) + "  | " + " V=" + Math.Round(v, 2));
                    break;

                case "o":
                    Console.WriteLine("Oktaederdaten werden berechnet.");
                    a = getOktaederSurface(d);
                    v = getOktaederVolumen(d);
                    Console.WriteLine("Oktaeder:   A=" + Math.Round(a, 2) + "  | " + " V=" + Math.Round(v, 2));
                    break;

            }

        }

        public static double getWürfelSurface(double würfelsurface)
        {
            würfelsurface = 6 * würfelsurface * würfelsurface;
            return würfelsurface;
        }

        public static double getWürfelVolumen(double würfelvolumen)
        {
            würfelvolumen = würfelvolumen * würfelvolumen * würfelvolumen;
            return würfelvolumen;
        }

        public static double getKugelSurface(double kugelsurface)
        {
            kugelsurface = Math.PI * kugelsurface * kugelsurface;
            return kugelsurface;
        }

        public static double getKugelVolumen(double kugelvolumen)
        {
            kugelvolumen = Math.PI * kugelvolumen * kugelvolumen * kugelvolumen / 6;
            return kugelvolumen;
        }

        public static double getOktaederSurface(double oktaedersurface)
        {
            oktaedersurface = 2 * Math.Sqrt(3) * oktaedersurface * oktaedersurface;
            return oktaedersurface;
        }

        public static double getOktaederVolumen(double oktaedervolumen)
        {
            oktaedervolumen = Math.Sqrt(2) * oktaedervolumen * oktaedervolumen * oktaedervolumen / 3;
            return oktaedervolumen;
        }



    }
}

