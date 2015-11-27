using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneBook.DataAccess.Models
{
    public class User
    {
        public string id;
        public string name;
        public List<Contact> contacts;

        public User(User contacts, String name)
        {
            this.name = name;
            this.contacts = new List<Contact>();
            if (contacts.contacts.Count != 0)
            {
                foreach (Contact user in contacts.contacts)
                {
                    this.contacts.Add(user);
                }
            }
        }

        public User(String name)
        {
            this.name = name;
            contacts = new List<Contact>();
        }

        public User(String id, String name)
        {
            this.id = id;
            this.name = name;
            contacts = new List<Contact>();
        }

        public User()
        {
            contacts = new List<Contact>();
        }
    }
}
