using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneBook.DataAccess.Models;

namespace TelephoneBook.BusinessLogic
{
    class UserContactsProcessing
    {
        public static void AddContact(Contact contact, User user)
        {
            user.contacts.Add(contact);
        }

        public static void EditContact(Contact contact, Contact newContact, User user)
        {
            if (user.contacts.Contains(contact))
            {
                user.contacts.Remove(contact);
                user.contacts.Add(contact);
            }

            user.contacts.Sort();
        }

        public static User Find(User user, string find)
        {
            User foundContacts = new User();

            String[] result = find.Split(' ' );

            if (result.Length == 1)
            {
                foreach (Contact contact in user.contacts)
                {
                    if (contact.surname == find || contact.name == find || contact.patronymic == find)
                    {
                       AddContact(contact, foundContacts);
                    }
                }
            }
            else if (result.Length == 2)
            {
                 foreach (Contact contact in user.contacts)
                 {
                     if (contact.name == result[0] && contact.surname == result[1] || contact.name == result[1] && contact.surname == result[0] ||
                       contact.name == result [0] && contact.patronymic == result[1] )
                     {
                         AddContact(contact, foundContacts);
                     }
                 }
            }
            else if (result.Length == 3)
            {
                foreach (Contact contact in user.contacts)
                {
                    if (contact.name == result[0] && contact.surname == result[1] && contact.patronymic == result[2] || contact.name == result[1] && contact.surname == result[0] && contact.patronymic == result[2])
                    {
                        AddContact(contact, foundContacts);
                    }
                }
            }
            return foundContacts;
        }
    }
}
