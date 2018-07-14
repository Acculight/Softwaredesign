using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Adventure
{
    public class Door
    {
        public enum Directions
        {
            North, East, South, West
        }

        public static string[] moveShortcuts = {"Null", "N", "E", "S", "W"};

        private Room leadsTo;
        private Directions direction;
        private string directionName;
        private bool locked;

        public Door(Directions _direction, Room newLeadsTo, string _directionName, bool _locked)
        {
            direction = _direction;
            leadsTo = newLeadsTo;
            directionName = _directionName;
            locked = _locked;
        }

        public bool getLocked()
        {
            return locked;
        }

        public void setLocked(bool _locked)
        {
            locked = _locked;
        }

        public void setDirection(Directions _direction)
        {
            direction = _direction;
        }

        public Directions getDirections()
        {
            return direction;
        }

        public string getmoveShortcuts()
        {
            return moveShortcuts[(int)direction].ToLower();
        }

        public void setleadsTo(Room _leadsTo)
        {
            leadsTo = _leadsTo;
        }

        public Room getLeadsTo()
        {
            return leadsTo;
        }

        public string getdirectionName()
        {
            return directionName;
        }
    }
}
