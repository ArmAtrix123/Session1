using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1.Classes
{
    public class Countries
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Countries(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public Countries()
        {

        }
    }
}
