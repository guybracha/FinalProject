using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Classes
{
    public class Staff : Person
    {
        public Staff(string name, string password, string email, int age, string id, string phoneNumber)
            : base(name, password, email, age, id, phoneNumber)
        {
        }
    }
}
