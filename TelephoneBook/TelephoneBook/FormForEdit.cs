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
    public partial class FormForEdit : Form
    {
        SqlConnection connection1 = new SqlConnection
                         (
                         @"Data Source=NotePad;Initial Catalog=PhoneBook;Integrated Security=True"
         );

        public User list = new User();
        public Contact contact = new Contact();
        public int index;

        public FormForEdit(User list, Contact contact)
        {
            foreach (Contact us in list.contacts)
            {
                this.list.AddContact(us);
            }

            this.contact = contact;
            MessageBox.Show(contact.ToString());
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
                MessageBox.Show(ct.ToString());
                ct.id = index.ToString();
                list.AddContact(ct);
                string sql = string.Format("Update CONTACTS Set Name = '{0}', Surname = '{1}', Patronymic = '{2}'  Where Id = '{3}'", 
                    ct.name, ct.surname, ct.patronymic, index);
                using (SqlCommand cmd = new SqlCommand(sql, this.connection1))
                {
                    cmd.ExecuteNonQuery();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btEditNumber_Click(object sender, EventArgs e)
        {
            String phonenumber = lbNumbers.SelectedItem.ToString();
            lbNumbers.Items.RemoveAt(lbNumbers.SelectedIndex);
            PhoneNumber newNumber = new PhoneNumber(tbEditNumber.Text, lbLabels.SelectedItem.ToString());
            lbNumbers.Items.Add(newNumber.ToString());
            tbEditNumber.Text = "";
        }

        private void btAddPhoneNumber_Click(object sender, EventArgs e)
        {
            PhoneNumber newNumber = new PhoneNumber(tbEditNumber.Text, lbLabels.SelectedItem.ToString());
            lbNumbers.Items.Add(newNumber.ToString());
            tbEditNumber.Text = "";
        }
    }
}
