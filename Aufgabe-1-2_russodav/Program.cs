using System;

namespace Aufgabe_1_2
{
     class Program{
        static string[] subjects = { "Harry", "Hermine", "Ron", "Hagrid", "Snape", "Dumbledore" };
        static string[] verbs = { "braut", "liebt", "studiert", "hasst", "zaubert", "zerstört" };
        static string[] objects = { "Zaubertränke", "den Grimm", "Lupin", "Hogwards", "die Karte des Rumtreibers", "Dementoren" };
        static string subject;
        static string verb;
        static string object_1;
        static int laenge = subjects.Length;        
        static void Main(string[] args){

        string[] verse = new string[laenge];

            for (int i = 0; i < laenge; i++)
            {
                VerseCreator();
                verse[i] = subject + " "+ verb + " " + object_1;
            }

            for (int i = 0; i < subjects.Length; i++){
                Console.WriteLine(verse[i]);
            }

        }
        public static void VerseCreator()
        {
            Random randomNumber = new Random();
            int subjectsNumber = randomNumber.Next(0, laenge);
            int verbsNumber = randomNumber.Next(0, laenge);
            int objectsNumber = randomNumber.Next(0, laenge);


            while (subjects[subjectsNumber] == "assigned")
            {
                subjectsNumber = randomNumber.Next(0, laenge);
            }
            subject = subjects[subjectsNumber];
            subjects[subjectsNumber] = "assigned";


            while (verbs[verbsNumber] == "assigned")
            {
                verbsNumber = randomNumber.Next(0, laenge);
            }
            verb = verbs[verbsNumber];
            verbs[verbsNumber] = "assigned";
            

            while (objects[objectsNumber] == "assigned")
            {
                objectsNumber = randomNumber.Next(0, laenge);
            }
            object_1 = objects[objectsNumber];
            objects[objectsNumber] = "assigned";

        }
    }
}