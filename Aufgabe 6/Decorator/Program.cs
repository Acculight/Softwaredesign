using System;
using System.Collections.Generic;

namespace DesPatternDecorator
{
    class Spielfigur
    {
        public virtual void Drohe()
        {
            Console.WriteLine("Grrrrr!Test");
        }  
    }

    class Monster : Spielfigur
    {
        public override void Drohe()
        {
              base.Drohe();
              Console.WriteLine("Grrrrrrrrrr!");
        }
    } 


    class Held : Spielfigur
    {
        public override void Drohe()
        {
            base.Drohe();
            Console.Write("Weiche zurück!");
        }        
    }

    // Decorator
    class ErkaelteteFigur : Spielfigur
    {
        private Spielfigur _original;

        public ErkaelteteFigur(Spielfigur original)
        {
            _original = original; 
        }
        public override void Drohe()
        {
            _original.Drohe();
            base.Drohe();
            Console.Write(" Hust!");
        }
    }

    class HeisereFigur : Spielfigur
    {
        private Spielfigur _original;

        public HeisereFigur(Spielfigur original)
        {
            _original = original; 
        }
        public override void Drohe()
        {
            Console.Write("Räusper...");
            _original.Drohe();
            base.Drohe();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Spielfigur> figuren = new List<Spielfigur>();

            figuren.Add(new Monster());
            figuren.Add(new Held());
            figuren.Add(new ErkaelteteFigur(new Held()));
            figuren.Add(new ErkaelteteFigur(new ErkaelteteFigur(new Monster())));
            figuren.Add(new HeisereFigur(new Monster()));
            figuren.Add(new ErkaelteteFigur(new HeisereFigur(new Held())));

            foreach(var spielfigur in figuren)
            {
                spielfigur.Drohe();
                Console.WriteLine();
            }

        }
    }
}