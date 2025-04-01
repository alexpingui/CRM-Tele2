using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Tele2
{
    public struct Person
    {
        public string PhoneNumber;
        public string Name;
        public string Address;
        
        public Person(string phoneNumber, string name, string address)
        {
            PhoneNumber = phoneNumber;
            Name = name;
            Address = address;
        }
    }
}
