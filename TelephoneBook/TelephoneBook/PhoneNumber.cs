using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneBook
{
    public class PhoneNumber
    {
        public string number;
        public string label;

        public PhoneNumber(string number, string label)
        {
            this.number = number;
            this.label = label;
        }

        override public string ToString()
        {
            return number + " " + label;
        }
    }
}
