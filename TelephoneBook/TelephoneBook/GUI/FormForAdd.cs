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
using TelephoneBook.DataAccess;
using TelephoneBook.DataAccess.Models;
using TelephoneBook.BusinessLogic;

namespace TelephoneBook.GUI
{
    public partial class FormForAdd : Form
    {
        SqlConnection connection1; 

        public User list = new User();
        public int index;
        private List<PhoneNumber> numbers;

        public FormForAdd(User list, int index)
        {
            connection1 = BaseDataAccess.CreateConnection();
            numbers = new List<PhoneNumber>();

            foreach (Contact user in list.contacts)
            {
                UserContactsProcessing.AddContact(user, this.list);
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
                UserContactsProcessing.AddContact(contact, list);
                connection1.Open();

                BaseDataAccess.InsertIntoContacts(connection1, contact, list, index);

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
