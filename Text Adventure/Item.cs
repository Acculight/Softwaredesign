using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Adventure
{
    public class Item
    {
        public string name;
        private bool useable;
        private bool needsItem;
        private string description;

        public Item(string _name, string _description, bool _useable)
        {
            name = _name;
            useable = _useable;
            description = _description;
        }

        public string getName
        {
            get {return name;}
        }

        public bool getUseable
        {
            get {return useable;}
        }

        public string getDescription
        {
            get {return description;}
        }
    }
}
