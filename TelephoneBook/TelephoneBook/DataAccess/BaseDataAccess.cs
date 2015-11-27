using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TelephoneBook.DataAccess.Models;

namespace TelephoneBook.DataAccess
{
    class BaseDataAccess
    {
        public static SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection
                           (
                           @"Data Source=NotePad;Initial Catalog=PhoneBook;Integrated Security=True"
           );

            return connection;
        }

        public static List<User> SelectFromUsers(SqlConnection connection)
        {
            List<User> users = new List<User>();

            string sql = "SELECT * FROM USERS";
            SqlCommand command1 = new SqlCommand(sql, connection);
            SqlDataReader dataReader1 = command1.ExecuteReader();


            while (dataReader1.Read())
            {
                users.Add(new User(dataReader1["Id"].ToString(), dataReader1["Name"].ToString()));
            }

            dataReader1.Close();

            return users;
        }

        public static List<Contact> SelectFromContacts(SqlConnection connection, int index)
        {
            List<Contact> contacts = new List<Contact>();

            string sql = "SELECT * FROM CONTACTS WHERE Id_user =" + index;
            SqlCommand command1 = new SqlCommand(sql, connection);
            SqlDataReader dataReader1 = command1.ExecuteReader();
            List<PhoneNumber> p = new List<PhoneNumber>();


            while (dataReader1.Read())
            {
                Contact contact = new Contact(dataReader1["Id"].ToString(), dataReader1["Name"].ToString(), dataReader1["Surname"].ToString(),
                    dataReader1["Patronymic"].ToString());

                contacts.Add(contact);

            }
            dataReader1.Close();

            return contacts;
        }
        public static void SelectFromPhoneNumbers(SqlConnection connection, User user, Contact contact)
        {
            string sql1 = "SELECT * FROM PHONENUMBER WHERE Id_contact =" + contact.id;
            SqlCommand command2 = new SqlCommand(sql1, connection);
            SqlDataReader dr = command2.ExecuteReader();

            while (dr.Read())
            {
                List<PhoneNumber> pn = new List<PhoneNumber>();
                pn.Add(new PhoneNumber(dr["Number"].ToString(), dr["Label"].ToString()));
                user.contacts[Int32.Parse(contact.id) - 1].numbers = pn;
            }

            dr.Close();
        }

        public static void InsertIntoContacts(SqlConnection connection, Contact contact, User user, int index)
        {
            string saveContact = "INSERT into CONTACTS (Name,Surname,Patronymic,Id_user) " +
                   " VALUES ('" + contact.name + "', '" + contact.surname + "', '" + contact.patronymic + "', '" + index + "');";

            SqlCommand querySaveStaff = new SqlCommand(saveContact, connection);
            querySaveStaff.ExecuteNonQuery();

            foreach (PhoneNumber p in contact.numbers)
            {
                string saveNumber = "INSERT into PHONENUMBER (Number,Label,Id_contact) " +
               " VALUES ('" + p.number + "', '" + p.label + "', '" + (contact.id + user.contacts.Count) + "');";

                SqlCommand querySaveNumber = new SqlCommand(saveNumber, connection);
                querySaveNumber.ExecuteNonQuery();
            } 
        }

        public static void UpdateContacts(SqlConnection connection, Contact contact, int index)
        {
            string sql = string.Format("Update CONTACTS Set Name = '{0}', Surname = '{1}', Patronymic = '{2}'  Where Id = '{3}'", 
                    contact.name, contact.surname, contact.patronymic, index);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }  
        }

        public static void InsertIntoUsers(SqlConnection connection, User user)
        {
            string saveUser = "INSERT into USERS (Name) " +
                   " VALUES ('" + user.name + "');";

            SqlCommand querySaveUser = new SqlCommand(saveUser, connection);
            querySaveUser.ExecuteNonQuery();
        }
    }
 }
