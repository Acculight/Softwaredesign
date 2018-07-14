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

        public string GetName()
        {
            return name;
        }

        public bool GetUseable()
        {
            return useable;
        }

        public string GetDescription()
        {
            return description;
        }
    }
}
