using System;
using System.Collections.Generic;

namespace uml_aufgabe
{
    public class CoursesList<C>
    {

        class Person
        {
            public string FirstName;
            public string LastName;
            public int Age;
        }

        class Teilnehmer : Person
        {
            public int MatriculationNumber;
            public List<CoursesList<C>> course = new List<CoursesList<C>>();
        }

        class Dozent : Person 
        {
            public string Room;
            public DateTime OfficeDays;
            public DateTime OfficeHours;
            public List<CoursesList<C>> course = new List<CoursesList<C>>();

            public void OutputCourse(){
                foreach (C course in Kurs)
                {
                    Console.WriteLine(Kurs.Title);
                }
            }c
            public Participiant<C> Outputparticipants()
            {
                List<Participiant> participants = new List<Participiant>();
                foreach (C course in Kurs)
                {
                    foreach(Participiant participiant in Teilnehmer.Participiant)
                    {
                        if(!participants.Contains(participiant))
                        {
                            participants.Add(participiant);
                        }
                    }
                }
                return participants;
            }


        }

        class Kurs
        {

            public string Titel;
            public DateTime Day;
            public DateTime Time;
            public string CourseRoom;

            public Dozent Dozent;
            List<Participiant> participantsT;
            public void OutputInformation(){
                Console.WriteLine("Kurs: " + Titel + " Tag: " + Day + " Uhrzeit:  " + Time + " Raum: " + CourseRoom);
            }
        }
    }
}