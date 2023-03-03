using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1.Classes
{
    public class Users
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OfficeID { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Active { get; set; }
        public string Office { get; set; }
        public string Role { get; set; }
        public Users(int id, int roleID, string email, string password, string firstName, string lastName, int officeID, DateTime birthdate, bool active)
        {
            ID = id;
            RoleID = roleID;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            OfficeID = officeID;
            Birthdate = birthdate;
            Active = active;

        }
        public Users()
        {

        }
    }
}
