using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
