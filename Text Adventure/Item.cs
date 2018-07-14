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
        private string description;

        public Item(string _name, string _description, bool _useable)
        {
            name = _name;
            useable = _useable;
            description = _description;
        }

        public string getName()
        {
            return name;
        }

        public bool getUseable()
        {
            return useable;
        }

        public string getDescription()
        {
            return description;
        }
    }
}
