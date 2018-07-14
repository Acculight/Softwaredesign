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

        public bool SetLocked()
        {
            return locked;
        }

        public void SetLocked(bool _locked)
        {
            locked = _locked;
        }

        public bool GetLocked()
        {
            return locked;
        }

        public Directions GetDirections()
        {
            return direction;
        }

        public void SetleadsTo(Room _leadsTo)
        {
            leadsTo = _leadsTo;
        }

        public Room GetLeadsTo()
        {
            return leadsTo;
        }

        public string GetdirectionName()
        {
            return directionName;
        }
    }
}
