using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneBook
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

        public User()
        {
            contacts = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void EditContact(Contact contact, Contact newUser)
        {
            if (contacts.Contains(contact))
            {
                contacts.Remove(contact);
                contacts.Add(contact);
            }

            contacts.Sort();
        }

        public User Find(string find)
        {
            User foundContacts = new User();

            String[] result = find.Split(' ' );

            if (result.Length == 1)
            {
                foreach (Contact contact in contacts)
                {
                    if (contact.surname == find || contact.name == find || contact.patronymic == find)
                    {
                        foundContacts.AddContact(contact);
                    }
                }
            }
            else if (result.Length == 2)
            {
                 foreach (Contact contact in contacts)
                 {
                     if (contact.name == result[0] && contact.surname == result[1] || contact.name == result[1] && contact.surname == result[0] ||
                       contact.name == result [0] && contact.patronymic == result[1] )
                     {
                         foundContacts.AddContact(contact);
                     }
                 }
            }
            else if (result.Length == 3)
            {
                foreach (Contact contact in contacts)
                {
                    if (contact.name == result[0] && contact.surname == result[1] && contact.patronymic == result[2] || contact.name == result[1] && contact.surname == result[0] && contact.patronymic == result[2])
                    {
                        foundContacts.AddContact(contact);
                    }
                }
            }
            return foundContacts;
        }

        public string ShowList()
        {
            contacts.Sort();

            StringBuilder sb = new StringBuilder();

            foreach (Contact contact in contacts)
            {
                sb.Append(contact.ToString());
            }
            return sb.ToString();
        }
    }
}
