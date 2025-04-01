using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Tele2.Essences
{
    public class Call
    {
        private string _phoneNumber;
        private string _comment;
        private string _dateOfCall;
        private string _dateOfscheduledCall;

        public Call(string phoneNumber, string comment, DateTime dateOfCall, DateTime dateOfScheduledCall) 
        {
            _phoneNumber = phoneNumber;
            _comment = comment;
            _dateOfCall = dateOfCall.ToString();
            _dateOfscheduledCall = dateOfScheduledCall.ToString();
        }
    }
}
