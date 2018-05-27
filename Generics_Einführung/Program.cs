using System;

    public class Auto<PLATZHALTER>
    {
        public double PS;

        public int Zylinder;

        public double Hubraum;

        public PLATZHALTER Farbe;
    }




namespace Generics_Einführung
{


    class Program
    {
        static void Main(string[] args)
        {
            int[] meinIntegerArray = new int[10];
            meinIntegerArray[0] = 1;
            meinIntegerArray[1] = 1;
            meinIntegerArray[2] = 1;
            meinIntegerArray[3] = 1;
            meinIntegerArray[4] = 1;
            meinIntegerArray[5] = 1;
            meinIntegerArray[6] = 1;
            meinIntegerArray[7] = 1;
            meinIntegerArray[8] = 1;
            meinIntegerArray[9] = 1;




            //Bestellwesen
            Auto<string> meinAuto = new Auto<string>();

            meinAuto.Farbe = "grau";
            meinAuto.PS = 100;
            meinAuto.Zylinder = 4;
            meinAuto.Hubraum = 2.8;


            //Produktion
            Auto<int> einAnderesAuto = new Auto<int>();
            einAnderesAuto.Farbe = 1;
            einAnderesAuto.PS = 100;
            einAnderesAuto.Zylinder = 4;
            einAnderesAuto.Hubraum = 2.8;



        }
    }
}
