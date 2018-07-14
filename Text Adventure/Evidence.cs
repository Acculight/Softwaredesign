using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Adventure
{
    public class Evidence
    {
        public string name;
        private string description;

        public Evidence(string _name, string _description)
        {
            name = _name;
            description = _description;
        }

        public string Name
        {
            get {return name;}
        }

        public string Description
        {
            get {return description;}
        }
    }
}
