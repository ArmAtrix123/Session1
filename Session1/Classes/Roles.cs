using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1.Classes
{
    class Roles
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Roles(int id, string title)
        {
            ID = id;
            Title = title;
        }
    }

}
