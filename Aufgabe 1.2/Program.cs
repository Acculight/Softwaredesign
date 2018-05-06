using System;

namespace Aufgabe1_2
{
    class Program
    {
        static string[] subjects = { "Harry", "Hermine", "Ron", "Hagrid", "Snape", "Dumbledore" };
        static string[] verbs = { "braut", "liebt", "studiert", "hasst", "zaubert", "zerstört" };
        static string[] objects = { "Zaubertränke", "den Grimm", "Lupin", "Hogwards", "die Karte des Rumtreibers", "Dementoren" };
        static string Subject;
        static string Verb;
        static string Object;
        static void Main(string[] args)
        {
            string[] verse = new string[subjects.Length];
            for (int i = 0; i < subjects.Length; i++)
            {
                GetVerse();
                verse[i] = Subject + " " + Verb + " " + Object;
            }
            for (int j = 0; j < subjects.Length; j++)
            {
                Console.WriteLine(verse[j]);
            }
        }
        public static void GetVerse()
        {
            Random random = new Random();
            int randomSubject = random.Next(0, subjects.Length);
            int randomVerb = random.Next(0, verbs.Length);
            int randomObject = random.Next(0, objects.Length);
            
            while (subjects[randomSubject] == "used")
            {
                randomSubject = random.Next(0, subjects.Length);
            }
            while (verbs[randomVerb] == "used")
            {
                randomVerb = random.Next(0, verbs.Length);
            }
            while (objects[randomObject] == "used")
            {
                randomObject = random.Next(0, objects.Length);
            }
            Subject = subjects[randomSubject];
            Verb = verbs[randomVerb];
            Object = objects[randomObject];

            subjects[randomSubject] = "used";
            verbs[randomVerb] = "used";
            objects[randomObject] = "used";
        }
    }
}