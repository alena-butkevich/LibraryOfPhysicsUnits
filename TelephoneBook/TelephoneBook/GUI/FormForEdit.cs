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
    public partial class FormForEdit : Form
    {
        SqlConnection connection1 = BaseDataAccess.CreateConnection();

        public User list;
        public Contact contact;
        public int index;

        public FormForEdit(User list, Contact contact)
        {
            list = new User();
            this.contact = new Contact();

            foreach (Contact us in list.contacts)
            {
                UserContactsProcessing.AddContact(us, this.list);
            }

            this.contact = contact;
            this.index = Int32.Parse(contact.id);
           
            InitializeComponent();

            tbName.Text = contact.name;
            tbSurname.Text = contact.surname;
            tbPatronymic.Text = contact.patronymic;

            foreach (PhoneNumber number in contact.numbers)
            {
                lbNumbers.Items.Add(number.ToString());
            }

        }

        private void btOK_Click(object sender, EventArgs e)
        {
   
            if (tbName.Text == "" || tbPatronymic.Text == "" || tbSurname.Text == "")
            {
                return;
            }
            else
            {
                connection1.Open();

                List<PhoneNumber> numbers = new List<PhoneNumber>();
                StringBuilder sbr = new StringBuilder();
                foreach (String str in lbNumbers.Items)
                {
                    String[] result = str.Split(' '); 
                    numbers.Add(new PhoneNumber(result[0], result[1]));
                }


                list.contacts.RemoveAt(Int32.Parse(contact.id) - 1);
                
                Contact ct = new Contact(tbName.Text, tbSurname.Text, tbPatronymic.Text, numbers);
                ct.id = index.ToString();
                UserContactsProcessing.AddContact(ct, list);

                BaseDataAccess.UpdateContacts(connection1, ct, index);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btEditNumber_Click(object sender, EventArgs e)
        {
            if (tbEditNumber.Text == "" || lbNumbers.SelectedItems.Count == 0)
            {
                return;
            }
            String phonenumber = lbNumbers.SelectedItem.ToString();
            if (lbLabels.SelectedItems.Count == 0)
            {
                return;
            }
            lbNumbers.Items.RemoveAt(lbNumbers.SelectedIndex);
            PhoneNumber newNumber = new PhoneNumber(tbEditNumber.Text, lbLabels.SelectedItem.ToString());
            lbNumbers.Items.Add(newNumber.ToString());
            tbEditNumber.Text = "";
        }

        private void btAddPhoneNumber_Click(object sender, EventArgs e)
        {
            if (tbEditNumber.Text == "")
            {
                return;
            }
            PhoneNumber newNumber = new PhoneNumber(tbEditNumber.Text, lbLabels.SelectedItem.ToString());
            lbNumbers.Items.Add(newNumber.ToString());
            tbEditNumber.Text = "";
        }
    }
}
