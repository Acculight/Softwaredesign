using System;

namespace Aufgabe1_2
{
    class Program
    {
        static strig[] subjects = { "Harry", "Hermine", "Ron", "Hagrid", "Snape", "Dumbledore" };
        static string[] verbs = { "braut", "liebt", "studiert", "hasst", "zaubert", "zerstört" };
        static string[] objects = { "Zaubertränke", "den Grimm", "Lupin", "Hogwards", "die Karte des Rumtreibers", "Dementoren" };
        static int länge = subjects.Length;
        static string wort1;
        static string wort2;
        static string wort3;
        static void Main(string[] args)
        {
            string[] verse = new string[länge];

            for (int i = 0; i < länge; i++)
            {
                GetVerse();
                verse[i] = wort1 + " " + wort2 + " " + wort3;
            }

            for (int j = 0; j < länge; j++)
            {
                Console.WriteLine(verse[j]);
            }
        }

        public static void GetVerse()
        {
            Random rnd = new Random();
            int numbersubjects = rnd.Next(0, länge);
            int numberverbs = rnd.Next(0, länge);
            int numberobjects = rnd.Next(0, länge);

            while (subjects[numbersubjects] == "used")
            {
                numbersubjects = rnd.Next(0, länge);
            }
            while (verbs[numberverbs] == "used")
            {
                numberverbs = rnd.Next(0, länge);
            }
            while (objects[numberobjects] == "used")
            {
                numberobjects = rnd.Next(0, länge);
            }

            wort1 = subjects[numbersubjects];
            wort2 = verbs[numberverbs];
            wort3 = objects[numberobjects];

            subjects[numbersubjects] = "used";
            verbs[numberverbs] = "used";
            objects[numberobjects] = "used";
        }
    }
}