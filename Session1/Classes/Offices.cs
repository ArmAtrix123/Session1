using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1.Classes
{
    class Offices
    {
        public int ID { get; set; }
        public int CountryID { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }


        public Offices(int id, int countryID, string title, string phone, string contact)
        {
            ID = id;
            CountryID = countryID;
            Title = title;
            Phone = phone;
            Contact = contact;
        }
    }
}
