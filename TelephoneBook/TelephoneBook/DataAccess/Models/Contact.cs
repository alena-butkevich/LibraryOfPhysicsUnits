using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneBook.DataAccess.Models
{
    public class Contact : IComparable
    {
        public string id;
        public string name;
        public string surname;
        public string patronymic;
        public List<PhoneNumber> numbers;

        public Contact(string name, string surname, string patronymic, List<PhoneNumber> numbers)
        {
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.numbers = numbers;
        }

        public Contact(string id, string name, string surname, string patronymic)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
        }
        public Contact()
        {

        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Contact otherUser = obj as Contact;
            if (otherUser != null)
                return this.surname.CompareTo(otherUser.surname);
            else
                throw new ArgumentException("Object is not a User");
        }


        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (PhoneNumber phonenumber in numbers)
            {
                sb.Append(phonenumber.ToString() + ' ');
            }
            return surname + " " + name + " " + patronymic + " " + sb;
        }
    }
}
