using System;
using System.Collections.Generic;

namespace Text_Adventure
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainGame game = new MainGame();

            while(game.running)
            {
                game.Update();
            }
        }

    }
}
