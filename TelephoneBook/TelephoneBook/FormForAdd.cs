using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace TelephoneBook
{
    public partial class FormForAdd : Form
    {
        SqlConnection connection1 = new SqlConnection
                          (
                          @"Data Source=NotePad;Initial Catalog=PhoneBook;Integrated Security=True"
          );

        public User list = new User();
        public int index;
        private List<PhoneNumber> numbers = new List<PhoneNumber>();
        public FormForAdd(User list, int index)
        {
            foreach (Contact user in list.contacts)
            {
                this.list.AddContact(user);
            }
            InitializeComponent();
            this.index = index + 1;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "" || tbPatronymic.Text == "" || tbSurname.Text == "" || tbPhoneNumber.Text == "")
            {
                return;
            }
            else
            {
                numbers.Add(new PhoneNumber(tbPhoneNumber.Text, lbLabels.SelectedItem.ToString()));
                Contact contact = new Contact(tbName.Text, tbSurname.Text, tbPatronymic.Text, numbers);
                list.AddContact(contact);
                connection1.Open();
                string saveStaff = "INSERT into CONTACTS (Name,Surname,Patronymic,Id_user) " +
                   " VALUES ('" + contact.name + "', '" + contact.surname + "', '" + contact.patronymic + "', '" + index + "');";

                SqlCommand querySaveStaff = new SqlCommand(saveStaff, connection1);
                querySaveStaff.ExecuteNonQuery();

                foreach(PhoneNumber p in contact.numbers)
                {
                    string saveNumber = "INSERT into PHONENUMBER (Number,Label,Id_contact) " +
                   " VALUES ('" + p.number + "', '" + p.label +"', '" + (contact.id + list.contacts.Count )+ "');";

                SqlCommand querySaveNumber = new SqlCommand( saveNumber, connection1);
                querySaveNumber.ExecuteNonQuery();
                } 

                this.DialogResult = DialogResult.OK;
                connection1.Close();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbPhoneNumber.Text != "" && lbLabels.SelectedItems.Count != 0)
            {
                numbers.Add(new PhoneNumber(tbPhoneNumber.Text, lbLabels.SelectedItem.ToString()));
            }

            tbPhoneNumber.Text = "";
        }
    }
}
